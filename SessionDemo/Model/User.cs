using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SessionDemo.Model
{
    public class User
    {
        public User(string first = "", string last = "") {
            FirstName = first;
            LastName = last;
        }

        public Guid UserId { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        private string FirstName;
        private string LastName;
    }
}
