using LabFashion.Models;

namespace LabFashion.Repositories.Interfaces
{
    public interface IClothingCollectionRepository
    {
        Task<IEnumerable<ClothingCollection>> GetClothingCollections();
        Task<ClothingCollection> GetClothingCollectionById(int IdCollection);
        void CreateClothingCollection(ClothingCollection clothingCollection);
        void UpdateClothingCollection(ClothingCollection clothingCollection);
        void DeleteClothingCollection(ClothingCollection clothingCollection);
        Task<bool> SaveAllAsync();
    }
}
