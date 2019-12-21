using System;
using System.Threading.Tasks;
using HandMadeShop.Dtos.Product;
using HandMadeShop.Infrastrucutre.Utils.Decorators;
using HandMadeShop.Logic.Interfaces;
using HandMadeShop.Logic.Utils;
using Raven.Client.Documents.Session;

namespace HandMadeShop.Logic.Domain.Product.Commands
{
    public sealed class UpdateProductCommand : ICommand
    {
        public UpdateProductCommand(string id, UpdateProductDto productDto)
        {
            Name = productDto.Name;
            Description = productDto.Description;
            Category = productDto.Category;
            Measure = productDto.Measure;
            Price = productDto.Price;
            SpecialPrice = productDto.SpecialPrice;
            SpecialPriceStart = productDto.SpecialPriceStart;
            SpecialPriceEnd = productDto.SpecialPriceEnd;
            HasOptions = productDto.HasOptions;
            IsAllowToOrder = productDto.IsAllowToOrder;
            StockQuantity = productDto.StockQuantity;
            IsHidden = productDto.IsHidden;
            IsAvailable = productDto.IsAvailable;
            DisplayOrder = productDto.DisplayOrder;
            Vendor = productDto.Vendor;
            PhotoUrl = productDto.PhotoUrl;
            ThumbnailImage = productDto.ThumbnailImage;
            ReviewsCount = productDto.ReviewsCount;
            RatingAverage = productDto.RatingAverage;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Measure { get; set; }
        public double Price { get; set; }
        public double? SpecialPrice { get; set; }
        public DateTimeOffset? SpecialPriceStart { get; set; }
        public DateTimeOffset? SpecialPriceEnd { get; set; }
        public bool HasOptions { get; set; }
        public bool IsAllowToOrder { get; set; }
        public int StockQuantity { get; set; }
        public bool IsHidden { get; set; }
        public bool IsAvailable { get; set; }
        public int DisplayOrder { get; set; }
        public string Vendor { get; set; }

        //TODO handle these properties
        public string PhotoUrl { get; set; }
        public string ThumbnailImage { get; set; }
        public int ReviewsCount { get; set; }
        public double? RatingAverage { get; set; }

        [AuditLog]
        public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
        {
            private readonly IAsyncDocumentSession _session;

            public UpdateProductCommandHandler(IAsyncDocumentSession session)
            {
                _session = session;
            }

            public async Task<CommandResult> Handle(UpdateProductCommand command)
            {
                await _session.SaveChangesAsync();

                return CommandResult.Ok();
            }
        }
    }
}