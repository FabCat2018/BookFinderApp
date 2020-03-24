using System;

namespace BookFinderApp
{
	public class Book
	{
		#region Public Instance Properties

		public string Title { get; set; }

		public string Author { get; set; }

		public DateTime PublishedDate { get; set; }

		public string ImagePath { get; set; }

		#endregion

		#region Public Constructor

		public Book(string title, string author, DateTime publishedDate, string imagePath)
		{
			Title = title;
			Author = author;
			PublishedDate = publishedDate;
			ImagePath = imagePath;
		}

		#endregion
	}
}
