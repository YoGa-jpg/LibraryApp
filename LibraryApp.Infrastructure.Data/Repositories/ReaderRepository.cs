using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void Create(Reader reader)
        {
            dataContext.Readers.Add(reader);
        }

        public void Delete(int id)
        {
            Reader reader = dataContext.Readers.Find(id);
            if (reader != null)
                dataContext.Readers.Remove(reader);
        }

        public Reader GetReader(int id)
        {
            return dataContext.Readers.Find(id);
        }

        public IEnumerable<Reader> GetReaders()
        {
            return dataContext.Readers;
        }

        public void Update(Reader reader)
        {
            dataContext.Entry(reader).State = EntityState.Modified;
        }
    }
}
