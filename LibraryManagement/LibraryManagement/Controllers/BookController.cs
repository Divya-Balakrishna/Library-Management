using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers
{
    public class BookController : ApiController
    {
		static readonly IBookRepo bookRepository = new BookRepository();

		[HttpGet]
		public IEnumerable<Book> GetAllBooks()
		{
			return bookRepository.GetAll();
		}

		public Book GetBook(int id)
		{
			Book book = bookRepository.Get(id);
			if (book == null)
			{
				throw new Exception("Invalid Id");
			}
			return book;
		}

		public IEnumerable<Book> GetBookssByCategory(string category)
		{
			return bookRepository.GetAll().Where(
				p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
		}

		public Book PostBook(Book book)
		{
			book = bookRepository.Add(book);
			return book;
		}

		public void UpdateBook(int id, Book book)
		{
			book.Id = id;
			if (!bookRepository.Update(book))
			{
				throw new Exception("Invalid Id");
			}
		}

		public void DeleteBook(int id)
		{
			Book book = bookRepository.Get(id);
			if (book == null)
			{
				throw new Exception("Invalid Id");
			}

			bookRepository.Remove(id);
		}
	}
}
