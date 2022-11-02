using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Domain.Core;
using LibraryApp.Domain.Interfaces;

namespace LibraryApp.Infrastructure.Data.Repositories
{
    internal class ReaderRepository : IReaderRepository
    {
        private DataContext dataContext;

        public ReaderRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Create(Reader reader)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Reader GetReader(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reader> GetReaders()
        {
            throw new NotImplementedException();
        }

        public void Update(Reader reader)
        {
            throw new NotImplementedException();
        }
    }
}
