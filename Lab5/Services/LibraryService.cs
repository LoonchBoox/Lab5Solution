using Lab5.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace Lab5.Services
{
	public class LibraryService : ILibraryService
	{
		public List<Book> books { get; set; } = new List<Book>();
		public List<User> users { get; set; } = new List<User>();

		public Dictionary<User, List<Book>> borrowedBooks { get; set; } = new Dictionary<User, List<Book>>();

		public LibraryService()
		{
			ReadBooks("./Data/Books.csv");
			ReadUsers("./Data/Users.csv");
		}

		public async Task AddBook(string title, string author, string isbn)
		{
			int id = books.Any() ? books.Max(b => b.Id) + 1 : 1;
			books.Add(new Book { Id = id, Title = title, Author = author, ISBN = isbn });
		}

		public async Task AddUser(string name, string email)
		{
			int id = users.Any() ? users.Max(u => u.Id) + 1 : 1;
			users.Add(new User { Id = id, Name = name, Email = email });
		}

		public async Task DeleteBook(Book book)
		{
			books.Remove(book);
		}

		public async Task DeleteUser(User user)
		{
			users.Remove(user);
		}

		public async Task EditBook(Book book, Book newbook)
		{
			book.Title = newbook.Title;
			book.Author = newbook.Author;
			book.ISBN = newbook.ISBN;
		}

		public async Task EditUser(User user, User newuser)
		{
			user.Name = newuser.Name;
			user.Email = newuser.Email;
		}

		public async Task ReadBooks(string path)
		{
			try
			{
				foreach (var line in File.ReadLines(path))
				{
					var fields = line.Split(',');

					if (fields.Length >= 4)
					{
						var book = new Book
						{
							Id = int.Parse(fields[0].Trim()),
							Title = fields[1].Trim(),
							Author = fields[2].Trim(),
							ISBN = fields[3].Trim()
						};

						books.Add(book);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
			}
		}

		public async Task ReadUsers(string path)
		{
			try
			{
				foreach (var line in File.ReadLines(path))
				{
					var fields = line.Split(',');

					if (fields.Length >= 3) // Ensure there are enough fields
					{
						var user = new User
						{
							Id = int.Parse(fields[0].Trim()),
							Name = fields[1].Trim(),
							Email = fields[2].Trim()
						};

						users.Add(user);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
			}
		}

		private async Task UpdateBookCSV()
		{

		}

		private async Task UpdateUserCSV()
		{

		}
	}
}
