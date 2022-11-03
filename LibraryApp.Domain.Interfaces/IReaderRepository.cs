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
        Task<IEnumerable<Reader>> GetReaders();
        Task<Reader> GetReader(int id);
        Task<int?> Create(Reader reader);
        Task<int?> Update(Reader reader);
        Task<int?> Delete(int id);
        Task Save();
    }
}
