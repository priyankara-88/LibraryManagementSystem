using LibraryManagementSystem.Data.Interfaces;
using LibraryManagementSystem.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Data.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Book> FindWithAouthorAndBorrower(Func<Book, bool> predicate)
        {
            return _dbContext.Books
                .Include(x => x.Author)
                .Include(x => x.Customer)
                .Where(predicate);
        }

        public IEnumerable<Book> FindWithAuthor(Func<Book, bool> predicate)
        {
            return _dbContext.Books
                .Include(x => x.Author)
                .Where(predicate);
        }

        public IEnumerable<Book> GetAllWithAuthor()
        {
            return _dbContext.Books.Include(x => x.Author);
        }
    }
}
