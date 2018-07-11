using LibraryManagementSystem.Data.Interfaces;
using LibraryManagementSystem.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Data.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Author> GetAllWithBooks()
        {
            return _dbContext.Authors.Include(x => x.Books);
        }

        public Author GetWithBook(int id)
        {
            return _dbContext.Authors
                .Where(x => x.AuthorId == id)
                .Include(x => x.Books)
                .FirstOrDefault();
        }
    }
}
