using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Tests
{
    public class TestContext : DbContext
    {

        public DbSet<TestPerson> TestPersons { get; set; }
        
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
        }
    }
}
