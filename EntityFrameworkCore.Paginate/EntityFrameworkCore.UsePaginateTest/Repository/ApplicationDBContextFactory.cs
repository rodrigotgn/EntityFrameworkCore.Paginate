using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EntityFrameworkCore.UsePaginateTest.Repository
{
    public class ApplicationDBContextFactory : IDesignTimeDbContextFactory<ApplicationDBContext>
    {
        public ApplicationDBContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDBContext>();
            builder.UseInMemoryDatabase(databaseName: "testDB");

            return new ApplicationDBContext(builder.Options);
        }
    }
}
