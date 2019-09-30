using System;
using CSharpFunctionalExtensions;
using HandMadeShop.Domain.Interfaces;
using HandMadeShop.Domain.RepositoryAbstractions;

namespace HandMadeShop.Domain.Entities.DeliveryMethod.Commands
{
    public class CreateDeliveryMethodHandler: ICommandHandler<CreateDeliveryMethodCommand>
    {
        private readonly IDeliveryMethodRepository _repository;

        public CreateDeliveryMethodHandler(IDeliveryMethodRepository repository)
        {
            _repository = repository;
        }

        public Result Handle(CreateDeliveryMethodCommand command)
        {
            var deliveryMethod = new DeliveryMethod
            {
                Name = command.Name,
                Position = command.Position,
                CreatedBy = 1,
                ModifiedBy = 1,
            };
            _repository.Insert(deliveryMethod).Save();
            return Result.Ok();
        }
    }
}