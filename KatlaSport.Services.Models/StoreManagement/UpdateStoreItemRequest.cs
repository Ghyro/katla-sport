using FluentValidation.Attributes;

namespace KatlaSport.Services.StoreManagement
{
    [Validator(typeof(UpdateStoreItemRequestValidator))]
    public class UpdateStoreItemRequest
    {
        /// <summary>
        /// Gets or sets a product ID.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets a hive section ID.
        /// </summary>
        public int HiveSectionId { get; set; }

        /// <summary>
        /// Gets or sets a store item quantity.
        /// </summary>
        public int Quantity { get; set; }
    }
}
