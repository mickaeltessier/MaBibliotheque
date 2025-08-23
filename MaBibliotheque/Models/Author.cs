using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MaBibliotheque.Models
{
    public partial class Author : ObservableObject
    {
        [Key]
        public int AuthorId { get; set; }

        [ObservableProperty]
        public string _firstName;

        [ObservableProperty]
        public string _lastName;
        public ICollection<Book> Books { get; set; } // navigation inverse

        public Author() { }

        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString() => $"{FirstName} {LastName}";

        public override bool Equals(object? obj)
        {
            if (obj is Author author)
            {
                return FirstName == author.FirstName &&
                       LastName == author.LastName;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AuthorId, FirstName, LastName);
        }
    }
}
