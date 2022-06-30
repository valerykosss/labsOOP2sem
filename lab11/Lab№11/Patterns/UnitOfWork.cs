using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_11.Patterns
{
    public class UnitOfWork : IDisposable
    {
        private Context.Context context = new Context.Context();
        private BookRepository bookRepository;
        private LibraryRepository libraryRepository;

        public BookRepository Books
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = new BookRepository(context);
                return bookRepository;
            }
        }

        public LibraryRepository Libraries
        {
            get
            {
                if (libraryRepository == null)
                    libraryRepository = new LibraryRepository(context);
                return libraryRepository;
            }
        }

        public void BeginTran()
        {
            context.Database.BeginTransaction();
        }

        public void Commit()
        {
            context.Database.CurrentTransaction.Commit();
        }

        public void Rollback()
        {
            context.Database.CurrentTransaction.Rollback();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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
