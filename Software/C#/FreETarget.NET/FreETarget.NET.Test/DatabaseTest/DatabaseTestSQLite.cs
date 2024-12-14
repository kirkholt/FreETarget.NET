using FreETarget.NET.Data;
using Microsoft.EntityFrameworkCore;

namespace FreETarget.NET.Test.DatabaseTest
{
    public  class DatabaseTestSQLite : DatabaseTest
    {
        public DatabaseTestSQLite() : base(new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite("Data Source=..\\DatabaseTestSQLite.db")
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            .Options)
        { }
    }
}
