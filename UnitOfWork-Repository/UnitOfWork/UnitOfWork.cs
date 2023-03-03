using Mask.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Task.Data.Context;
using Task.Data.Entities;
using Task.Repository;

namespace Mask.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Book, int> bookRepository { get; set; }
        public IAuthorRepository authorRepository { get; set; }

        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

            bookRepository = new EfRepository<Book, int>(_appDbContext);
            authorRepository = new AuthorRepository(_appDbContext);
        }

        public async System.Threading.Tasks.Task Commit()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
