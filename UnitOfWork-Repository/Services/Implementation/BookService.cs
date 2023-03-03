using Microsoft.EntityFrameworkCore;
using Task.Data.Context;
using Task.Data.Entities;
using Task.Services.Interface;

namespace Task.Services.Imp;

public class BookService : IBookService
{
    private readonly AppDbContext _context;

    public BookService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Book> Create(string bookName, decimal price, string category, int authorId)
    {
        Book book = new()
        {
            BookName = bookName,
            Price = price,
            Category = category,
            AuthorId = authorId
        };
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task<List<Book>> GetAll()
    {
        List<Book> book = await _context.Books.ToListAsync();
        return book;
    }

    public async Task<object> GetAllwithAuthor()
    {
        return await _context.Books.Include(x => x.Author).Select(s => new
        {
            s.BookName,
            s.Author.AuthorName
        }).ToListAsync();

    }

    public Task<Book> GetId(int id)
    {
        var result = _context.Books.FirstOrDefaultAsync(i => i.Id == id);
        return result;
    }

    public async Task<bool> Remove(int id)
    {
        var result = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        _context.Books.Remove(result);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(int id, string bookName, decimal price, string category)
    {
        Book book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

        book.BookName = bookName;
        book.Price = price;
        book.Category = category;
        await _context.SaveChangesAsync();
        return true;
    }
}
