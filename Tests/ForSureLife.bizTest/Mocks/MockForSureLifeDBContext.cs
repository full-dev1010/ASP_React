using Microsoft.EntityFrameworkCore;
using ForSureLife.repo;
using Microsoft.Data.Sqlite;

namespace ForSureLife.BizTest
{
    public class MockForSureLifeDBContext
    {
        public const string ConnectionString = "DataSource=Assets/ForSureLifeDBContext.db;Cache=Shared;";
        private readonly SqliteConnection _connection;

        public readonly ForSureLifeDBContext Context;

        public MockForSureLifeDBContext()
        {
            _connection = new SqliteConnection(ConnectionString);
            _connection.Open();
            var options = new DbContextOptionsBuilder<ForSureLifeDBContext>()
                .UseSqlite(_connection)
                .Options;
            Context = new ForSureLifeDBContext(options);
            Context.Database.EnsureCreated();
            SeedDb(Context);
        }

        public static void SeedDb(ForSureLifeDBContext Context)
        {
            // seed categories and sellers 
            Context.SaveChanges();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}