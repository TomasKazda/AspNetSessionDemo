using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SessionDemo.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SessionDemo.Model;

namespace SessionDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SessionStorage _ss;
        public int SecretNumber { get; set; }
        public bool isSetSecret { get; set; }

        public List<User> Users { get; set; }

        public IndexModel(SessionStorage ss)
        {
            _ss = ss;
            Users = _ss.Users;
        }

        public void OnGet()
        {
            SecretNumber = _ss.GetSecretNumber();
            isSetSecret = _ss.IsSetSecret;
        }
    }
}
