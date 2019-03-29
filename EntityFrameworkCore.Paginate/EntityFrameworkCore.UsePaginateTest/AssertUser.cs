using EntityFrameworkCore.UsePaginateTest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EntityFrameworkCore.UsePaginateTest
{
    public class AssertUser
    {
        public static void AreEqual(List<User> expectedUser, List<User> actualUser)
        {
            for (int i = 0; i < expectedUser.Count; i++)
                AreEqual(expectedUser[i], actualUser[i]);
        }

        public static void AreEqual(User expectedUser, User actualUser)
        {
            Assert.AreEqual(expectedUser.ID, actualUser.ID, $"User id {expectedUser.ID} was expected but came {actualUser.ID}.");
            Assert.AreEqual(expectedUser.Name, actualUser.Name, $"User name {expectedUser.Name} was expected but came {actualUser.Name}.");
            Assert.AreEqual(expectedUser.Age, actualUser.Age, $"User age {expectedUser.Age} was expected but came {actualUser.Age}.");
        }

        public static void AreNotEqual(List<User> expectedUser, List<User> actualUser)
        {
            try
            {
                for (int i = 0; i < expectedUser.Count; i++)
                    AreNotEqual(expectedUser[i], actualUser[i]);
            }
            catch (Exception)
            {
            }
        }

        public static void AreNotEqual(User expectedUser, User actualUser)
        {
            Assert.AreNotEqual(expectedUser.ID, actualUser.ID, $"User id {expectedUser.ID} was not expected but came {actualUser.ID}.");
            Assert.AreNotEqual(expectedUser.Name, actualUser.Name, $"User name {expectedUser.Name} was not expected but came {actualUser.Name}.");
            Assert.AreNotEqual(expectedUser.Age, actualUser.Age, $"User age {expectedUser.Age} was not expected but came {actualUser.Age}.");
        }
    }
}
