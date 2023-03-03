using Mask.Repository;
using Task.Data.Entities;
using Task.Repository;

namespace Mask.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IRepository<Book, int> bookRepository { get; set; }
        public IAuthorRepository authorRepository { get; set; }

        public System.Threading.Tasks.Task Commit();
    }
}
