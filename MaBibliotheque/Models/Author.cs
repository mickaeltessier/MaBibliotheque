using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaBibliotheque.Models
{
    public partial class Author : ObservableObject
    {
        [ObservableProperty]
        private int _id;

        [ObservableProperty]
        private string _firstName;

        [ObservableProperty]
        private string _lastName;

        public Author(int id, string firstname, string lastname)
        {
            _id = id;
            _firstName = firstname;
            _lastName = lastname;
        }
    }
}
