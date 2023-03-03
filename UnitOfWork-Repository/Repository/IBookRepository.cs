using Task.Data.Entities;

namespace Task.Repository
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAll();
        Task<Book> GetId(int id);
        Task<Book> Create(string bookName, decimal price, string category, int authorId);
        Task<bool> Update(int id, string bookName, decimal price, string category);
        Task<bool> Remove(int id);

        Task<object> GetAllwithAuthor();
    }
}
