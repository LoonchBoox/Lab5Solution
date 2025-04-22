using System.ComponentModel.DataAnnotations;
using Lab5.Models;

namespace Lab5.Services
{
	public interface ILibraryService
	{
		//Lists
		public List<Book> books { get; set; }
		public List<User> users { get; set; }

		public Dictionary<User, List<Book>> borrowedBooks { get; set; }

		//Books
		Task ReadBooks(string path);

		Task AddBook(string title, string author, string isbn);
		Task EditBook(Book book, Book newbook);
		Task DeleteBook(Book book);


		//Users
		Task ReadUsers(string path);

		Task AddUser(string name, string email);

		Task EditUser(User user, User newuser);

		Task DeleteUser(User user);
	}
}
