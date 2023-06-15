using LabFashion.Models;

namespace LabFashion.Repositories.Interfaces
{
    public interface IClothingCollectionRepository
    {
        Task<IEnumerable<ClothingCollection>> GetCollections();
        Task<ClothingCollection> GetCollectionById(int IdCollection);
        void CreateCollection(ClothingCollection clothingCollection);
        void UpdateCollection(ClothingCollection clothingCollection);
        void DeleteCollection(ClothingCollection clothingCollection);
        Task<bool> SaveAllAsync();
    }
}
