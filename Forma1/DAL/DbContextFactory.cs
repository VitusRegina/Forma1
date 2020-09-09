using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Forma1.DAL
{
    public class DbContextFactory : IDisposable
    {
        private DbConnection _connection;

        private DbContextOptions<Forma1DbContext> CreateOptions()
        {
            return new DbContextOptionsBuilder<Forma1DbContext>()
                .UseSqlite(_connection).Options;
        }

        public Forma1DbContext CreateContext()
        {
            if (_connection == null)
            {
                _connection = new SqliteConnection("DataSource=:memory:");
                _connection.Open();

                var options = CreateOptions();
                using var context = new Forma1DbContext(options);
                context.Database.EnsureCreated();
            }

            return new Forma1DbContext(CreateOptions());
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}
