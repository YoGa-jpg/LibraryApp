using LibraryApp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Interfaces
{
    public interface IReaderRepository
    {
        IEnumerable<Reader> GetReaders();
        Reader GetReader(int id);
        void Create(Reader reader);
        void Update(Reader reader);
        void Delete(int id);
    }
}
