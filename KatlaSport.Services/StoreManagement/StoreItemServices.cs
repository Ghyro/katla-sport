using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.ProductCatalogue;
using KatlaSport.DataAccess.ProductStore;
using KatlaSport.DataAccess.ProductStoreHive;
using DbStoreItem = KatlaSport.DataAccess.ProductStore.StoreItem;

namespace KatlaSport.Services.StoreManagement
{
    public class StoreItemServices : IStoreItemService
    {
        private readonly IProductCatalogueContext _productContext;
        private readonly IProductStoreHiveContext _categoryContext;
        private readonly IProductStoreContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreItemServices"/> class with specified <see cref="IProductStoreContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="IProductStoreContext"/>.</param>
        /// <param name="categoryContext">A <see cref="IProductStoreHiveContext"/></param>
        /// <param name="productContext">A <see cref="IProductCatalogueContext"/></param>
        public StoreItemServices(IProductStoreContext context, IProductCatalogueContext productContext, IProductStoreHiveContext categoryContext)
        {
            _productContext = productContext ?? throw new ArgumentNullException(nameof(productContext));
            _categoryContext = categoryContext ?? throw new ArgumentNullException(nameof(categoryContext));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task<List<StoreItem>> GetHiveSectionStoreItemsAsync(int hiveSectionId)
        {
            var dbHiveSections = await _context.Items.Where(i => i.HiveSectionId == hiveSectionId && i.Quantity > 0).OrderBy(i => i.Id).ToArrayAsync();

            if (dbHiveSections.Length == 0)
            {
                throw new RequestedResourceHasConflictException();
            }

            var hiveSection = dbHiveSections.Select(i => Mapper.Map<StoreItem>(i)).ToList();

            return hiveSection;
        }

        /// <inheritdoc/>
        public async Task<StoreItem> CreateStoreItemAsync(UpdateStoreItemRequest createRequest)
        {
            var dbProduct = _productContext.Products.Where(p => p.Id == createRequest.ProductId).FirstOrDefault();

            if (dbProduct == null)
            {
                throw new RequestedResourceHasConflictException();
            }

            var dbAllowedSectionCatagegories = _categoryContext.Categories.Where(c => c.StoreHiveSectionId == createRequest.HiveSectionId && c.ProductCategoryId == dbProduct.Category.Id).FirstOrDefault();

            if (dbAllowedSectionCatagegories == null)
            {
                throw new RequestedResourceHasConflictException();
            }

            var dbStoreItem = Mapper.Map<UpdateStoreItemRequest, DbStoreItem>(createRequest);

            _context.Items.Add(dbStoreItem);

            await _context.SaveChangesAsync();

            return Mapper.Map<StoreItem>(dbStoreItem);
        }

        /// <inheritdoc/>
        public async Task<StoreItem> GetStoreItemAsync(int id)
        {
            var dbStoreItems = await _context.Items.Where(i => i.Id == id).ToArrayAsync();

            if (dbStoreItems.Length == 0)
            {
                throw new RequestedResourceHasConflictException();
            }

            return Mapper.Map<DbStoreItem, StoreItem>(dbStoreItems[0]);
        }
    }
}
