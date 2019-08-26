using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITSTracker.Models;

namespace ITSTracker.Services
{
    public class AccountService : IAccountService
    {
        private traccarContext TrackerContext = null;
        public AccountService()
        {
            this.TrackerContext = new traccarContext();
        }

        public AccountResponse Find(int Id)
        {
            var user = this.TrackerContext.TcUsers.FirstOrDefault((obj) => obj.Id == Id);
            if (user == null) return null;
            return new AccountResponse() { LoggedIn = true, Login = user.Login, Id = user.Id };
        }

        public AccountResponse Login(AccountRequest model)
        {
            var user = this.TrackerContext.TcUsers.FirstOrDefault((obj) => obj.Login == model.Login 
                                                                    && obj.Hashedpassword == model.Password);
            if (user == null) return null;
            return new AccountResponse() { LoggedIn = true, Login = user.Login, Id = user.Id };
        }

        public bool Logout(AccountRequest model)
        {
            throw new NotImplementedException();
        }

        public AccountResponse Register(AccountRequest model)
        {
            var user = this.TrackerContext.TcUsers.FirstOrDefault((obj)=> obj.Login == model.Login);
            if (user != null) return null;
            var newUser = new TcUsers()
            {
                Login = model.Login,
                Email = model.Email,
                Name = model.FullName,
                Hashedpassword = model.Password,
            };
            this.TrackerContext.TcUsers.Add(newUser);
            this.TrackerContext.SaveChanges();
            return new AccountResponse() { LoggedIn = true, Login = model.Login, Id = newUser.Id };
        }
    }
}
