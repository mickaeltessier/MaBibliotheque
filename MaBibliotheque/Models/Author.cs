using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaBibliotheque.Models
{
    public partial class Author(int id, string firstName, string lastName) : ObservableObject
    {
        [ObservableProperty]
        [Key]
        private int _id = id; // logique qui sera gerer une fois la base de données implémentée

        [ObservableProperty]
        private string _firstName = firstName;

        [ObservableProperty]
        private string _lastName = lastName;

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Author author)
            {
                return Id == author.Id &&
                       FirstName == author.FirstName &&
                       LastName == author.LastName;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, FirstName, LastName);
        }
    }
}
