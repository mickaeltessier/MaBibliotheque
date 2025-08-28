using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace MaBibliotheque.Models
{
    public partial class Publisher : ObservableObject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PublisherName { get; set; }

        public string? EditorLine { get; set; }

        public ICollection<Book> Books { get; set; } = [];

        public Publisher() { } // Constructeur pour EF Core

        public Publisher(string publisherName, string editorLine = "")
        {
            PublisherName = publisherName;
            EditorLine = editorLine;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Publisher publisher)
            {
                return publisher.Id == Id &&
                    publisher.PublisherName == PublisherName &&
                    publisher.EditorLine == EditorLine &&
                    publisher.Books == Books;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{PublisherName} -  {EditorLine} - ({Books.Count})";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, PublisherName, EditorLine, Books);
        }
    }
}
