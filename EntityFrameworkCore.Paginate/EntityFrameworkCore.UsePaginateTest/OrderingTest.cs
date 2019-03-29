using EntityFrameworkCore.Paginate;
using EntityFrameworkCore.UsePaginateTest.Models;
using EntityFrameworkCore.UsePaginateTest.Repository;
using EntityFrameworkCore.UsePaginateTest.Seed;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCore.UsePaginateTest
{
    [TestClass]
    public class OrderingTest
    {
        private readonly ApplicationDBContext _context;
        private readonly SeedUser _seed;

        public OrderingTest()
        {
            string[] args = new string[1];

            _context = new ApplicationDBContextFactory().CreateDbContext(args);
            _seed = new SeedUser(_context);
            _seed.CreateUsers();

        }

        [TestMethod]
        public void OrderedInOrderOfCreation()
        {
            var bulk = _seed.GetUsersWithID();
            var result = _context.User.ToList();

            AssertUser.AreEqual(result, bulk);
        }

        [TestMethod]
        public void OrderedInOrderOfNameAsc()
        {
            var bulk = _seed.GetUsersWithID().OrderBy(p => p.Name).ToList();

            var result = _context.User.SortQueryBy("Name").ToList();

            AssertUser.AreEqual(result, bulk);
        }

        [TestMethod]
        public void OrderedInOrderOfNameDesc()
        {
            var bulk = _seed.GetUsersWithID().OrderByDescending(p => p.Name).ToList();

            var result = _context.User.SortQueryByDescending("Name").ToList();

            AssertUser.AreEqual(result, bulk);
        }

        [TestMethod]
        public void OrderedInOrderOfNameFailed()
        {
            var bulk = _seed.GetUsersWithID().OrderByDescending(p => p.Name).ToList();

            var result = _context.User.SortQueryBy("Name").ToList();

            AssertUser.AreNotEqual(result.First(), bulk.First());
            AssertUser.AreNotEqual(result.Last(), bulk.Last());

            AssertUser.AreEqual(result.First(), bulk.Last());
            AssertUser.AreEqual(result.Last(), bulk.First());
        }

        [TestMethod]
        public void OrderedInOrderOfAgeAsc()
        {
            var bulk = _seed.GetUsersWithID().OrderBy(p => p.Age).ToList();

            var result = _context.User.SortQueryBy("Age").ToList();

            AssertUser.AreEqual(result, bulk);
        }

        [TestMethod]
        public void OrderedInOrderOfAgeDesc()
        {
            var bulk = _seed.GetUsersWithID().OrderByDescending(p => p.Age).ToList();

            var result = _context.User.SortQueryByDescending("Age").ToList();
            
            AssertUser.AreEqual(result, bulk);
        }

        [TestMethod]
        public void OrderedInOrderOfAgeFailed()
        {
            var bulk = _seed.GetUsersWithID().OrderByDescending(p => p.Age).ToList();

            var result = _context.User.SortQueryBy("Age").ToList();

            AssertUser.AreNotEqual(result.First(), bulk.First());
            AssertUser.AreNotEqual(result.Last(), bulk.Last());

            AssertUser.AreEqual(result.First(), bulk.Last());
            AssertUser.AreEqual(result.Last(), bulk.First());
        }
    }
}
