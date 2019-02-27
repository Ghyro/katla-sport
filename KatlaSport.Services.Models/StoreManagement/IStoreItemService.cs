using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.StoreManagement
{
    public interface IStoreItemService
    {
        /// <summary>
        /// Gets a store item from the hive section.
        /// </summary>
        /// <param name="id">Item id.</param>
        /// <returns>A <see cref="Task{StoreItem}}"/></returns>
        Task<StoreItem> GetStoreItemAsync(int id);

        /// <summary>
        /// Gets a list of a hive section store items.
        /// </summary>
        /// <param name="hiveSectionId">A hive section identifier.</param>
        /// <returns>A <see cref="Task{List{StoreItem}}"/>.</returns>
        Task<List<StoreItem>> GetHiveSectionStoreItemsAsync(int hiveSectionId);

        /// <summary>
        /// Creates a new store item in the hive section.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateStoreItemRequest"/></param>
        /// <returns>A <see cref="Task{StoreItem}"/></returns>
        Task<StoreItem> CreateStoreItemAsync(UpdateStoreItemRequest createRequest);
    }
}
