using Lab5.Models;
using Lab5.Services;
using System.Data;
using System.Runtime.InteropServices;

namespace TestProject1.Tests
{
	[TestClass]
	public sealed class Test1
	{

		[TestMethod]
		public async Task AddBookTest()
		{
			var LS = new LibraryService();
			int initialCount = LS.books.Count;

			await LS.AddBook("Test Title", "Test Author", "1234567890");

			Assert.AreEqual(initialCount + 1, LS.books.Count);
		}

		[TestMethod]
		public async Task AddUserTest()
		{
			var LS = new LibraryService();
			int initialCount = LS.users.Count;

			await LS.AddUser("Test User", "test@example.com");

			Assert.AreEqual(initialCount + 1, LS.users.Count);
		}

		[TestMethod]
		public async Task DeleteBookTest()
		{
			var LS = new LibraryService();
			var book = new Book { Id = 1, Title = "Test", Author = "Author", ISBN = "111" };
			LS.books.Add(book);

			await LS.DeleteBook(book);

			Assert.IsFalse(LS.books.Contains(book));
		}

		[TestMethod]
		public async Task DeleteUserTest()
		{
			var LS = new LibraryService();
			var user = new User { Id = 1, Name = "User", Email = "user@example.com" };
			LS.users.Add(user);

			await LS.DeleteUser(user);

			Assert.IsFalse(LS.users.Contains(user));
		}

		[TestMethod]
		public async Task EditBookTest()
		{
			var LS = new LibraryService();
			var book = new Book { Id = 1, Title = "Old", Author = "Old", ISBN = "000" };
			var newBook = new Book { Title = "New", Author = "New", ISBN = "999" };

			LS.books.Add(book);
			await LS.EditBook(book, newBook);

			Assert.AreEqual("New", book.Title);
			Assert.AreEqual("New", book.Author);
			Assert.AreEqual("999", book.ISBN);
		}

		[TestMethod]
		public async Task EditUserTest()
		{
			var LS = new LibraryService();
			var user = new User { Id = 1, Name = "Old", Email = "old@example.com" };
			var newUser = new User { Name = "New", Email = "new@example.com" };

			LS.users.Add(user);
			await LS.EditUser(user, newUser);

			Assert.AreEqual("New", user.Name);
			Assert.AreEqual("new@example.com", user.Email);
		}
	}
}
