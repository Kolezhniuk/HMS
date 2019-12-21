using System;
using System.Threading.Tasks;
using HandMadeShop.Dtos.Product;
using HandMadeShop.Logic.Interfaces;
using HandMadeShop.Logic.Utils;
using HandMadeShop.Logic.Utils.Decorators;
using Raven.Client.Documents.Session;

namespace HandMadeShop.Logic.Domain.Product.Commands
{
    public sealed class AddProductCommand : ICommand
    {
        public AddProductCommand(AddProductDto productDto)
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
        public string PhotoUrl { get; set; }
        public string ThumbnailImage { get; set; }
        public int ReviewsCount { get; set; }
        public double? RatingAverage { get; set; }

        [AuditLog]
        public class AddProductCommandHandler : ICommandHandler<AddProductCommand>
        {
            private readonly EventBus _eventBus;
            private readonly IAsyncDocumentSession _session;

            public AddProductCommandHandler(IAsyncDocumentSession session, EventBus eventBus)
            {
                _session = session;
                _eventBus = eventBus;
            }

            public async Task<CommandResult> Handle(AddProductCommand command)
            {
                var product = new Core.DomainEntities.Product
                {
                    Name = command.Name,
                    Description = command.Description,
                    Category = command.Category,
                    Measure = command.Measure,
                    Price = command.Price,
                    SpecialPrice = command.SpecialPrice,
                    SpecialPriceStart = command.SpecialPriceStart,
                    SpecialPriceEnd = command.SpecialPriceEnd,
                    HasOptions = command.HasOptions,
                    IsAllowToOrder = command.IsAllowToOrder,
                    StockQuantity = command.StockQuantity,
                    IsHidden = command.IsHidden,
                    IsAvailable = command.IsAvailable,
                    DisplayOrder = command.DisplayOrder,
                    Vendor = command.Vendor,
                    PhotoUrl = command.PhotoUrl,
                    ThumbnailImage = command.ThumbnailImage,
                    ReviewsCount = command.ReviewsCount,
                    RatingAverage = command.RatingAverage
                };

                await _session.StoreAsync(product);
                await _session.SaveChangesAsync();

                _eventBus.PublishEvent(new ProductCreatedEvent {Id = product.Id, Name = "Product Created"});

                return CommandResult.Ok(product.Id);
            }
        }
    }
}