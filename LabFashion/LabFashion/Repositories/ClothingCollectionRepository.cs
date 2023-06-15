using LabFashion.Context;
using LabFashion.Models;
using LabFashion.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LabFashion.Repositories
{
    public class ClothingCollectionRepository : IClothingCollectionRepository
    {
        private readonly LCCContext _lccContext;

        public ClothingCollectionRepository(LCCContext lccContext)
        {
            _lccContext = lccContext;
        }

        public async Task<IEnumerable<ClothingCollection>> GetClothingCollections()
        {
            return await _lccContext.Collections.Include(x => x.Person).ToListAsync();
        }

        public async Task<ClothingCollection> GetClothingCollectionById(int IdCollection)
        {
            return await _lccContext.Collections.Where(x => x.IdCollection == IdCollection).FirstOrDefaultAsync();
        }

        public void CreateClothingCollection(ClothingCollection clothingCollection)
        {
            _lccContext.Collections.Add(clothingCollection);
        }

        public void UpdateClothingCollection(ClothingCollection clothingCollection)
        {
            _lccContext.Entry(clothingCollection).State = EntityState.Modified;
        }

        public void DeleteClothingCollection(ClothingCollection clothingCollection)
        {
            _lccContext.Collections.Remove(clothingCollection);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _lccContext.SaveChangesAsync() > 0;
        }
    }
}
