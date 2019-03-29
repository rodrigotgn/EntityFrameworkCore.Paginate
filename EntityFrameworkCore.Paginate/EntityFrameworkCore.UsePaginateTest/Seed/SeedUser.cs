using EntityFrameworkCore.UsePaginateTest.Models;
using EntityFrameworkCore.UsePaginateTest.Repository;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCore.UsePaginateTest.Seed
{
    public class SeedUser
    {
        private readonly ApplicationDBContext _context;

        public SeedUser(ApplicationDBContext context)
        {
            _context = context;
        }

        public void CreateUsers()
        {
            foreach (var user in GetUsers())
            {
                if (!_context.User.Any(p => p.Name == user.Name))
                    _context.User.Add(user);
            }

            _context.SaveChanges();
        }

        private void DeleteAllUsers()
        {
            _context.User.RemoveRange(_context.User);
            _context.SaveChanges();
        }

        public List<User> GetUsersWithID()
        {
            var result = GetUsers();

            for (int i = 0; i < result.Count; i++)
                result[i].ID = i + 1;

            return result;
        }

        public List<User> GetUsers()
        {
            return new List<User>()
            {
                new User() { Name = "Juliana", Age = 20 },
                new User() { Name = "Abigail", Age = 40 },
                new User() { Name = "Rodrigo", Age = 25 },
                new User() { Name = "Karina", Age = 23 },
                new User() { Name = "Nadir", Age = 40 },
                new User() { Name = "Isaías", Age = 50 },
                new User() { Name = "Pedro", Age = 27 },
                new User() { Name = "Thiago", Age = 33 },
                new User() { Name = "Victor", Age = 25 },
                new User() { Name = "Enzo", Age = 2 },
                new User() { Name = "Vanessa", Age = 30 }
            };
        }
    }
}