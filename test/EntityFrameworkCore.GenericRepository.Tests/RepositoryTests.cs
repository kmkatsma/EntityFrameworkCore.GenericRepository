using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCore.Tests;
using EntityFrameworkCore.GenericRepository;

namespace TestProject.InMemory
{
    public class RepositoryTests
    {
        [Fact]
        public async Task TestCRUD()
        {
            var options = new DbContextOptionsBuilder<TestContext>()            
                .UseInMemoryDatabase(databaseName: "TestCRUD")
                .Options;

            // Run the test against one instance of the context
            using (var context = new TestContext(options))
            {
                var constituent = new TestPerson();
                constituent.firstName = "Joe";
                constituent.lastName = "Smith";
                constituent.id = 1;
                var service = new Repository<TestPerson>(context);
                await service.Add(constituent, context.TestPersons);
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new TestContext(options))
            {
                Assert.Equal(1, context.TestPersons.Count());
                Assert.Equal("Joe", context.TestPersons.Single().firstName);
                Assert.True(context.TestPersons.Single().id == 1 );
                
                var service = new Repository<TestPerson>(context);
                var constituent = await service.FindByID(1,context.TestPersons);
                constituent.lastName = "Jones";
                await service.Update(constituent);
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new TestContext(options))
            {
                Assert.Equal(1, context.TestPersons.Count());
                Assert.Equal("Jones", context.TestPersons.Single().lastName);

                var service = new Repository<TestPerson>(context);
                await service.Remove(1, context.TestPersons);                
            }

            //use separate context to verify delete
            using (var context = new TestContext(options))
            {
                Assert.Equal(0, context.TestPersons.Count());            
            }
        }

        [Fact]
        public async Task TestAdd_ChangesNotSaved()
        {
            var options = new DbContextOptionsBuilder<TestContext>()            
                .UseInMemoryDatabase(databaseName: "TestAdd_ChangesNotSaved")
                .Options;

            // Run the test against one instance of the context
            using (var context = new TestContext(options))
            {
                var constituent = new TestPerson();
                constituent.firstName = "Joe";
                constituent.lastName = "Smith";
                constituent.id = 1;
                var service = new Repository<TestPerson>(context);
                await service.Add(constituent, context.TestPersons, false);
            }

            // Use a separate instance of the context to verify data was not saved to database
            using (var context = new TestContext(options))
            {
                Assert.Equal(0, context.TestPersons.Count());                
            }
           
        }

        [Fact]
        public async Task TestUpdate_ChangesNotSaved()
        {
            var options = new DbContextOptionsBuilder<TestContext>()            
                .UseInMemoryDatabase(databaseName: "TestUpdate_ChangesNotSaved")
                .Options;

            // Run the test against one instance of the context
            using (var context = new TestContext(options))
            {
                var constituent = new TestPerson();
                constituent.firstName = "Joe";
                constituent.lastName = "Smith";
                constituent.id = 1;
                var service = new Repository<TestPerson>(context);
                await service.Add(constituent, context.TestPersons);
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new TestContext(options))
            {
                Assert.Equal(1, context.TestPersons.Count());
                Assert.Equal("Joe", context.TestPersons.Single().firstName);
                Assert.True(context.TestPersons.Single().id == 1 );
                
                var service = new Repository<TestPerson>(context);
                var constituent = await service.FindByID(1,context.TestPersons);
                constituent.lastName = "Jones";
                await service.Update(constituent, false);
            }

             // Use a separate instance of the context to verify data was not saved to database
            using (var context = new TestContext(options))
            {
                Assert.Equal(1, context.TestPersons.Count());
                Assert.Equal("Smith", context.TestPersons.Single().lastName);              
            }
        }

       [Fact]
       public async Task TestDelete_ChangesNotSaved()
        {
            var options = new DbContextOptionsBuilder<TestContext>()            
                .UseInMemoryDatabase(databaseName: "TestDelete_ChangesNotSaved")
                .Options;

            // Run the test against one instance of the context
            using (var context = new TestContext(options))
            {                
                var constituent = new TestPerson();
                constituent.firstName = "Joe";
                constituent.lastName = "Smith";
                constituent.id = 1;
                var service = new Repository<TestPerson>(context);
                await service.Add(constituent, context.TestPersons);

                await service.Remove(1, context.TestPersons, false); 
            }
                  
            //use separate context to verify not deleted
            using (var context = new TestContext(options))
            {
                Assert.Equal(1, context.TestPersons.Count());            
            }
        }
        
    }
}