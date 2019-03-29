using EntityFrameworkCore.Paginate;
using EntityFrameworkCore.UsePaginateTest.Repository;
using EntityFrameworkCore.UsePaginateTest.Seed;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameworkCore.UsePaginateTest
{

    [TestClass]
    public class PaginateTest
    {
        private readonly ApplicationDBContext _context;
        private readonly SeedUser _seed;

        public PaginateTest()
        {
            string[] args = new string[1];

            _context = new ApplicationDBContextFactory().CreateDbContext(args);
            _seed = new SeedUser(_context);
            _seed.CreateUsers();
        }

        [TestMethod]
        public void PaginateTestWith3PerPageStartingPage1()
        {
            var bulk = _seed.GetUsersWithID();

            int totalRow = 0;

            var result = _context.User.Paginate(new PaginationInfo()
            {
                Page = 1,
                Per_Page = 3,
                sort_by = "Name",
                sort_order = EnumSortOrder.Asc

            }, out totalRow).ToList();

            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual(bulk.Count, totalRow);

            AssertUser.AreEqual(result, bulk.OrderBy(p => p.Name).Take(3).ToList());
            AssertUser.AreNotEqual(result, bulk.OrderByDescending(p => p.Name).Take(4).ToList());
        }

        [TestMethod]
        public void PaginateTestWith3PerPageStartingPage2()
        {
            var bulk = _seed.GetUsersWithID();

            int totalRow = 0;

            var result = _context.User.Paginate(new PaginationInfo()
            {
                Page = 2,
                Per_Page = 3,
                sort_by = "Name",
                sort_order = EnumSortOrder.Asc

            }, out totalRow).ToList();

            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual(bulk.Count, totalRow);

            AssertUser.AreEqual(result, bulk.OrderBy(p => p.Name).Skip(3).Take(3).ToList());
            AssertUser.AreNotEqual(result, bulk.OrderByDescending(p => p.Name).Take(4).ToList());
        }
    }
}
