using ITSTracker.Controllers;
using ITSTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSTracker.Services
{
    public interface IAccountService
    {
        AccountResponse Login(AccountRequest model);
        AccountResponse Find(int id);
        AccountResponse Register(AccountRequest model);
        bool Logout(AccountRequest model);
    }
}
