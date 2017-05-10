using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
	interface IBookRepo
	{
		IEnumerable<Book> GetAll();
		Book Get(int id);
		Book Add(Book item);
		void Remove(int id);
		bool Update(Book item);
	}
}
