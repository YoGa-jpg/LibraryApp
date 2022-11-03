using LibraryApp.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Infrastructure.Data
{
    public class UnitOfWork : IDisposable
    {
        private DataContext dataContext; //= new DataContext();
        private BookRepository bookRepository;
        private OrderRepository orderRepository;
        private ReaderRepository readerRepository;

        public UnitOfWork(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public BookRepository Books
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = new BookRepository(dataContext);
                return bookRepository;
            }
        }

        public OrderRepository Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(dataContext);
                return orderRepository;
            }
        }

        public ReaderRepository Readers
        {
            get
            {
                if (readerRepository == null)
                    readerRepository = new ReaderRepository(dataContext);
                return readerRepository;
            }
        }

        public void Save()
        {
            dataContext.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dataContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
