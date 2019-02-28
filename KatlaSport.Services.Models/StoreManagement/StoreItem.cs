namespace KatlaSport.Services.StoreManagement
{
    public class StoreItem
    {
        /// <summary>
        /// Gets or sets a product store item ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a product ID.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets a product name.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets a product.
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// Gets or sets a category code.
        /// </summary>
        public string ProductCategoryCode { get; set; }

        /// <summary>
        /// Gets or sets a quantity of items of certain product in the location.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a store item is confirmed.
        /// </summary>
        public bool IsConfirmed { get; set; }
    }
}
