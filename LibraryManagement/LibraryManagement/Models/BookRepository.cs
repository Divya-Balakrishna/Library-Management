using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models
{
	public class BookRepository : IBookRepo
	{
		private List<Book> books = new List<Book>();
		private int _nextId = 1;

		public BookRepository()
		{
			Add(new Book { Name = "ABAP For Beginners", Category = "Software Development|Programming", Author ="Nithya K", Available = true});
			Add(new Book { Name = "Tinkle", Category = "Comic Magazine", Author = "Many", Available = false });
			Add(new Book { Name = "Life is not Enough", Category = "Novel|philosophical", Author = "Sidney Sheldon", Available = true});
			Add(new Book { Name = "Slow Cooker Recipes Cookbook", Category = "Cookery", Author = "Clark Webe", Available = true });
			Add(new Book { Name = "The Fix", Category = "Mystry|Thriller", Author = "David Baldacci", Available = false });
			Add(new Book { Name = "The Black Book", Category = "Mystry|Thriller", Author = "James Patterson ", Available = true });

		}


		public IEnumerable<Book> GetAll()
		{
			return books;
		}

		public Book Get(int id)
		{
			return books.Find(p => p.Id == id);
		}

		public Book Add(Book item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			item.Id = _nextId++;
			books.Add(item);
			return item;
		}

		public void Remove(int id)
		{
			books.RemoveAll(p => p.Id == id);
		}

		public bool Update(Book item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			int index = books.FindIndex(p => p.Id == item.Id);
			if (index == -1)
			{
				return false;
			}
			books.RemoveAt(index);
			books.Add(item);
			return true;
		}
	}
}