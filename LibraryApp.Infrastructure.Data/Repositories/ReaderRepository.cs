using Microsoft.EntityFrameworkCore;
using LibraryApp.Domain.Core;
using LibraryApp.Domain.Interfaces;

namespace LibraryApp.Infrastructure.Data.Repositories
{
    public class ReaderRepository : IReaderRepository
    {
        private DataContext dataContext;

        public ReaderRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<int?> Create(Reader reader)
        {
            await dataContext.Readers.AddAsync(reader);
            return dataContext.Readers.Count() > 0 ? dataContext.Readers.ToList().Last().Id + 1 : 1;
        }

        public async Task<int?> Delete(int id)
        {
            Reader reader = await dataContext.Readers.FindAsync(id);
            if (reader != null)
                dataContext.Readers.Remove(reader);
            return reader?.Id;
        }

        public async Task<Reader> GetReader(int id)
        {
            return await dataContext.Readers.FindAsync(id);
        }

        public async Task<IEnumerable<Reader>> GetReaders()
        {
            var readers = await Task.Run(() => dataContext.Readers);
            return readers;
        }

        public async Task<int?> Update(Reader reader)
        {
            await Task.Run(() => dataContext.Entry(reader).State = EntityState.Modified);
            return reader.Id;
        }

        public async Task Save()
        {
            await dataContext.SaveChangesAsync();
        }
    }
}
