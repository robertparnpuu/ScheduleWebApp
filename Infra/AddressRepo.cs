using Aids;
using Data;
using Domain;
using Domain.Repos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra
{
    public class AddressRepo : IAddressRepo
    {
        public readonly DbSet<AddressData> dbSet;
        public readonly DbContext db;

        public AddressRepo(ApplicationDbContext c)
        {
            db = c;
            dbSet = c?.Addresses;
        }
        protected internal Task<List<AddressData>> GetDataListAsync() => dbSet.AsNoTracking().ToListAsync();

        public async Task<List<Address>> GetEntityListAsync() =>
        (await GetDataListAsync()).Select(ToEntity).ToList();

        protected internal Address ToEntity(AddressData d) => new Address(d);
        protected internal AddressData ToData(Address e) => e?.Data ?? new AddressData();
        protected internal async Task<AddressData> GetDataAsync(string id)
        {
            if (id is null) return null;
            if (dbSet is null) return null;
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(r => r.id == id);
        }

        public async Task<Address> GetEntityAsync(string id) => ToEntity(await GetDataAsync(id));

        public async Task<bool> DeleteAsync(string id) => await DeleteFromDatabase(id);

        protected internal async Task<bool> DeleteFromDatabase(string id)
        {
            var o = await dbSet.FindAsync(id);
            var isOk = IsEntityOk(o);
            if (isOk) dbSet.Remove(o);
            await db.SaveChangesAsync();
            return isOk;
        }

        public async Task<bool> AddAsync(Address obj)
        {
            if (obj is null) return false;
            if (dbSet is null) return false;
            return await AddToDatabase(ToData(obj));
        }

        protected internal async Task<bool> AddToDatabase(AddressData obj)
        {
            if (!IsEntityOk(obj)) return false;
            await dbSet.AddAsync(obj);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Address obj)
        {
            if (obj is null) return false;
            if (dbSet is null) return false;
            return await UpdateInDatabase(ToData(obj));
        }

        protected internal async Task<bool> UpdateInDatabase(AddressData obj)
        {
            var o = await dbSet.FindAsync(obj.id);
            Copy.Members(obj, o);
            var isOk = IsEntityOk(o);
            if (isOk) dbSet.Update(o);
            await db.SaveChangesAsync();
            return isOk;
        }

        private bool IsEntityOk(object obj)
        {
            if (obj is null) return false;
            if (dbSet is null) return false;
            return true;
        }
    }
}
