using HranitelPROWeb.Data.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HranitelPROWeb.Data.Repositories
{
    public class UsersRepository
    {
        HranitelDBContext _context; 

        public UsersRepository(HranitelDBContext context)
        {
            _context = context;

        }

        public async Task Registration(string lastName, string name, string eMail, string login, string password)
        {
            await _context.Polzovatelis.AddAsync(new Polzovateli
            {
                Familia = lastName,
                Imya = name,
                Email = eMail,
                Login = login,
                Parol = password
            });
            await _context.SaveChangesAsync();
        }

        public async Task Login(string login, string password)
        {

        }
    }
}
