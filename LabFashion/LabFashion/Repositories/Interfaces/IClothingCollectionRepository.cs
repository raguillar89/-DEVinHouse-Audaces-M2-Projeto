using LabFashion.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace LabFashion.Repositories.Interfaces
{
    public interface IClothingCollectionRepository
    {
        Task<IEnumerable<ClothingCollection>> GetClothingCollections();
        Task<ClothingCollection> GetClothingCollectionById(int IdCollection);
        void CreateClothingCollection(ClothingCollection clothingCollection);
        void UpdateClothingCollection(ClothingCollection clothingCollection);
        Task UpdateCollectionStatus(int IdCollection, JsonPatchDocument clothingCollection);
        void DeleteClothingCollection(ClothingCollection clothingCollection);
        Task<bool> SaveAllAsync();
    }
}
