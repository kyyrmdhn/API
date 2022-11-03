using Api.Context;
using Api.Models;
using Api.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Data
{
    public class AccountRepository
    {
        private MyContext myContext;
        public AccountRepository(MyContext myContext)
        {
            this.myContext = myContext; 
        }
        public ResponseLoginVM Login(string email, string password)
        {
            var data = myContext.Users
                .Include(x => x.Employee)
                .Include(x => x.Role)
                .SingleOrDefault(x => x.Employee.Email.Equals(email) && x.Password.Equals(password));
            if (data != null)
            {
                ResponseLoginVM responseLogin = new ResponseLoginVM()
                {
                    Id = data.Id,
                    FullName = data.Employee.FullName,
                    Email = data.Employee.Email,
                    Role = data.Role.Name
                };
                return responseLogin;
            }
            return null;
        }
        public int Register(RegisterVM registerVM)
        {
            if (myContext.Employees.Any(x => x.Email != registerVM.Email))
            {
                myContext.Employees.Add(new Employee()
                {
                    FullName = registerVM.FullName,
                    Email = registerVM.Email,
                    BirthDate = registerVM.BirthDate
                });
                var result = myContext.SaveChanges();
                if (result > 0)
                {
                    var id = myContext.Employees.SingleOrDefault(x => x.Email.Equals(registerVM.Email)).Id;
                    myContext.Users.Add(new User()
                    {
                        Id = id,
                        Password = registerVM.Password,
                        RoleId = 1
                    });
                    var resultUser = myContext.SaveChanges();
                    if (resultUser > 0)
                    {
                        return resultUser;
                    }
                }
            }
            return 0;
        }
        public int ChangePassword(ChangePasswordVM changePasswordVM)
        {
            var data = myContext.Users
               .Include(x => x.Employee)
               .Include(x => x.Role)
               .SingleOrDefault(x => x.Employee.Email.Equals(changePasswordVM.Email) && x.Password.Equals(changePasswordVM.Password));
            if (data != null)
            {
                data.Password = changePasswordVM.NewPass;
                myContext.Entry(data).State = EntityState.Modified;
                var resultUser = myContext.SaveChanges();
                if (resultUser > 0)
                {
                    return resultUser;
                }
            }
            return 0;
        }
        public int ForgotPassword(ForgotPasswordVM forgotPasswordVM)
        {
            var data = myContext.Users
                .Include(x => x.Employee)
                .SingleOrDefault(x => x.Employee.Email.Equals(forgotPasswordVM.Email));
            if (data != null)
            {
                if (forgotPasswordVM.NewPass == forgotPasswordVM.ConfPass)
                {
                    data.Password = forgotPasswordVM.ConfPass;
                    myContext.Entry(data).State = EntityState.Modified;
                    var resultUser = myContext.SaveChanges();
                    if (resultUser > 0)
                    {
                        return resultUser;
                    }
                }
            }
            return 0;
        }
    }
}
