using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaBibliotheque.Models
{
    public class Author
    {
        private int _id;
        private string _firstName;
        private string _lastName;

        public Author(int id, string firstname, string lastname)
        {
            _id = id;
            _firstName = firstname;
            _lastName = lastname;
        }

        public int Id => _id;

        public string FirstName => _firstName;

        public string LastName => _lastName;

    }
}
