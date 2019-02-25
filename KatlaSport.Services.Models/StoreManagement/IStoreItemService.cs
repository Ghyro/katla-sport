using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.StoreManagement
{
    public interface IStoreItemService
    {
        /// <summary>
        /// Gets a list of store items in the hive section
        /// </summary>
        /// <param name="hiveSectionId">A hive section ID</param>
        /// <returns>A <see cref="Task{List{StoreItem}}"/></returns>
        Task<List<StoreItem>> GetStoreItemsAsync(int hiveSectionId);

        /// <summary>
        /// Creates a new store item in the hive section.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateStoreItemRequest"/></param>
        /// <returns>A <see cref="Task{StoreItem}"/></returns>
        Task<StoreItem> CreateStoreItemAsync(UpdateStoreItemRequest createRequest);
    }
}
