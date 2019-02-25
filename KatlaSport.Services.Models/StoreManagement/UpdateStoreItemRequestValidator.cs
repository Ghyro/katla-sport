using FluentValidation;

namespace KatlaSport.Services.StoreManagement
{
    /// <summary>
    /// Represents a validator for <see cref="UpdateStoreItemRequest"/>.
    /// </summary>
    public class UpdateStoreItemRequestValidator : AbstractValidator<UpdateStoreItemRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateStoreItemRequestValidator"/> class.
        /// </summary>
        public UpdateStoreItemRequestValidator()
        {
            RuleFor(r => r.ProductId).GreaterThan(0);
            RuleFor(r => r.HiveSectionId).GreaterThan(0);
            RuleFor(r => r.Quantity).GreaterThan(0);
        }
    }
}
