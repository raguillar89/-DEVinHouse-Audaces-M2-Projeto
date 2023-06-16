using LabFashion.Models;

namespace LabFashion.Repositories.Interfaces
{
    public interface IModelClothingRepository
    {
        Task<IEnumerable<ModelClothing>> GetModelsClothing();
        Task<ModelClothing> GetModelsClothingById(int IdModel);
        void CreateModelsClothing(ModelClothing modelClothing);
        void UpdateModelsClothingn(ModelClothing modelClothing);
        void DeleteModelsClothing(ModelClothing modelClothing);
        Task<bool> SaveAllAsync();
    }
}
