namespace KatlaSport.Services.StoreManagement
{
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
