namespace KatlaSport.Services.StoreManagement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using KatlaSport.DataAccess;
    using KatlaSport.DataAccess.ProductStore;

    public class StoreItemServices : IStoreItemService
    {
        private readonly IProductStoreContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreItemServices"/> class with specified <see cref="IProductStoreContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="IProductStoreContext"/>.</param>
        public StoreItemServices(IProductStoreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task<StoreItem> CreateStoreItemAsync(UpdateStoreItemRequest createRequest)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<List<StoreItem>> GetStoreItemsAsync(int hiveSectionId)
        {
            var dbHiveSections = await _context.Items.Where(p => p.HiveSectionId == hiveSectionId && p.Quantity > 0).OrderBy(p => p.Id).ToArrayAsync();

            var hiveSections = dbHiveSections.Select(i => Mapper.Map<StoreItem>(i)).ToList();

            return hiveSections;
        }
    }
}
