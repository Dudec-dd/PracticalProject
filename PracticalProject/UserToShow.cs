using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalProject
{
    internal class UserToShow
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string birthdayDate { get; set; }
        public string login { get; set; }
        public UserToShow() { }
        public UserToShow(string name, string surname, string birthdayDate, string login)
        {
            this.name = name;
            this.surname = surname;
            this.birthdayDate = birthdayDate;
            this.login = login;
        }
    }
}
