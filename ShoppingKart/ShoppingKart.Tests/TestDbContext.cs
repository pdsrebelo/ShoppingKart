using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace ShoppingKart.Tests
{
    public class TestDbContext : DbContext
    {
        private static IDatabaseInitializer<TestDbContext> _initializer;

        public TestDbContext(string connString, IDatabaseInitializer<TestDbContext> initializer = null)
            : base(connString)
        {
            _initializer = initializer;
        }

        public ObjectContext UnderlyingContext
        {
            get { return (this as IObjectContextAdapter).ObjectContext; }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (_initializer != null)
            {
                Database.SetInitializer(_initializer);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}