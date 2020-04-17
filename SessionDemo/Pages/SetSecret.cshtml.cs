using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SessionDemo.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SessionDemo.Model;

namespace SessionDemo.Pages
{
    public class SetSecretModel : PageModel
    {
        private readonly SessionStorage _ss;

        //localhost/SetSecret?handler=SetNumber&number=21

        public bool IsSet { get; set; }

        public SetSecretModel(SessionStorage ss)
        {
            _ss = ss;
        }

        public void OnGet()
        {
            _ss.Users.Add(new User("Jan", "Kos"));
            _ss.Users.Add(new User("Pepa", "Nos"));

            _ss.SaveUsers();
        }

        public void OnGetSetNumber(int number)
        {
            _ss.SetSecretNumber(number);
            IsSet = true;
        }
    }
}