using LabFashion.Context;
using LabFashion.Models;
using LabFashion.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LabFashion.Repositories
{
    public class ModelClothingRepository : IModelClothingRepository
    {
        private readonly LCCContext _lccContext;

        public ModelClothingRepository(LCCContext lccContext)
        {
            _lccContext = lccContext;
        }

        public async Task<IEnumerable<ModelClothing>> GetModelsClothing()
        {
            return await _lccContext.Models.Include(x => x.ClothingCollection).ToListAsync();
        }

        public async Task<ModelClothing> GetModelsClothingById(int IdModel)
        {
            return await _lccContext.Models.Where(x => x.IdModel == IdModel).FirstOrDefaultAsync();
        }

        public void CreateModelsClothing(ModelClothing modelClothing)
        {
            _lccContext.Models.Add(modelClothing);
        }

        public void UpdateModelsClothingn(ModelClothing modelClothing)
        {
            _lccContext.Entry(modelClothing).State = EntityState.Modified;
        }

        public void DeleteModelsClothing(ModelClothing modelClothing)
        {
            _lccContext.Models.Remove(modelClothing);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _lccContext.SaveChangesAsync() > 0;
        }
    }
}
