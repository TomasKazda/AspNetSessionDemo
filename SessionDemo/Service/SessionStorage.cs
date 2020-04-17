using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helpers;
using SessionDemo.Model;

namespace SessionDemo.Service
{
    public class SessionStorage
    {
        readonly ISession _session;
        const string SECRETKEY = "TotoJeTajneCislo";
        const string USERSKEY = "TotoJeMistoProUsery";

        private int _secretNumber;
        public bool IsSetSecret { get; }

        public List<User> Users { get; set; }

        public SessionStorage(IHttpContextAccessor hca)
        {
            _session = hca.HttpContext.Session;

            int? cislo = _session.GetInt32(SECRETKEY);
            if (cislo != default)
            {
                _secretNumber = (int)cislo;
                IsSetSecret = true;
            }
            else IsSetSecret = false;

            Users = _session.Get<List<User>>(USERSKEY);
            if (Users == default) Users = new List<User>();
        }

        public void SaveUsers()
        {
            _session.Set(USERSKEY, Users);
        }

        public void SetSecretNumber(int number)
        {
            _session.SetInt32(SECRETKEY, number);
            _secretNumber = number;
        }

        private void ClearSecretNumber()
        {
            _session.SetString(SECRETKEY, null);
        }

        public int GetSecretNumber()
        {
            return _secretNumber;
        }
    }
}
