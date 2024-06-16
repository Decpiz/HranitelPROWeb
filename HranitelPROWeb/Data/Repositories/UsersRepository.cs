using HranitelPROWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Polzovateli> GetByLogin(string login)
        {
            var user = _context.Polzovatelis.FirstOrDefaultAsync(u => u.Login == login);

            return await user;
        }

        public async Task Update(Polzovateli curUser, string lastName, string name, string email, string patronopic = null)
        {
            var user = await _context.Polzovatelis.FirstOrDefaultAsync(u=>u.IdPolzovatelia == curUser.IdPolzovatelia);

            user.Familia = lastName;
            user.Imya = name;
            user.Otchestvo = patronopic;
            user.Email = email;

            _context.Polzovatelis.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
