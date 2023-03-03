using Task.Data.Context;
using Task.Data.Entities;
using Task.Repository;

namespace Mask.Repository
{
    public interface IAuthorRepository : IRepository<Author, int>
    {
        Task<Author> FindByName(string name);
    }

    public class AuthorRepository : EfRepository<Author, int>, IAuthorRepository
    {
        private readonly AppDbContext _dbContext;

        public AuthorRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Author> FindByName(string name)
        {
            throw new NotImplementedException();
        }
    }


}
