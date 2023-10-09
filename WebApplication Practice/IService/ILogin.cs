using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication_Practice.Models;

namespace WebApplication_Practice.IService
{
    public interface ILogin
    {
        string Save(LoginModel loginModel);
        List<LoginModel> List();
        string Delete(int id);
        string Edit(LoginModel dpt);
        LoginModel DetailsByid(int id);

    }
}
