using Lab_11.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_11.Patterns
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }

    public class BookRepository : IRepository<Book>
    {
        private Context.Context db;
        public BookRepository(Context.Context context)
        {
            db = context;
        }

        public void Create(Book item)
        {
            db.Books.Add(item);
        }

        public void Delete(int id)
        {
            Book book = db.Books.Find(id);
            if (book != null)
                db.Books.Remove(book);
        }

        public void Delete(Book book)
        {
            db.Books.Remove(book);
        }

        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return db.Books;
        }

        public IEnumerable<Book> GetFromLibrary(Library library)
        {
            return db.Books.Where(b => b.LibraryId == library.Id);
        }

        public void Update(Book item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }

    public class LibraryRepository : IRepository<Library>
    {
        private Context.Context db;

        public LibraryRepository(Context.Context context)
        {
            this.db = context;
        }

        public IEnumerable<Library> GetAll()
        {
            return db.Library;
        }

        public Library Get(int id)
        {
            return db.Library.Find(id);
        }

        public void Create(Library item)
        {
            db.Library.Add(item);
        }

        public void Update(Library item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Library library = db.Library.Find(id);
            if (library != null)
                db.Library.Remove(library);
        }
    }
}
