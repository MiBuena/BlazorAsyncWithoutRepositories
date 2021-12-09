using ListGenerator.Server.Services;
using ListGeneratorListGenerator.Data.DB;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ListGenerator.Web.UnitTests
{
    public class SqliteInMemoryItemsControllerTest : IDisposable
    {
        private readonly DbConnection _connection;

        public SqliteInMemoryItemsControllerTest()
        {
            ContextOptions =
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlite(CreateInMemoryDatabase())
                    .Options;

            _connection = RelationalOptionsExtension.Extract(ContextOptions).Connection;
        }

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }

        protected DbContextOptions<ApplicationDbContext> ContextOptions { get; }


        public void Dispose() => _connection.Dispose();

        [Test]
        public void Can_get_items()
        {
            using (var context = new ApplicationDbContext(ContextOptions, null))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var controller = new ItemsDataService(context, null, null);

            }
        }
    }
}
