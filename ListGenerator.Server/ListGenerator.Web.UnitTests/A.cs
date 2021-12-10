using AutoMapper;
using FluentAssertions;
using IdentityServer4.EntityFramework.Options;
using ListGenerator.Data.Entities;
using ListGenerator.Server.CommonResources;
using ListGenerator.Server.Services;
using ListGenerator.Shared.Dtos;
using ListGenerator.Web.UnitTests.Helpers;
using ListGenerator.Web.UnitTests.ItemsDataServiceTests;
using ListGeneratorListGenerator.Data.DB;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ListGenerator.Web.UnitTests
{
    public class SqliteInMemoryItemsControllerTest : BaseItemsDataServiceTests, IDisposable
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
        public async Task Can_get_items()
        {
            Mock<IOptions<OperationalStoreOptions>> operationalStoreOptions = new Mock<IOptions<OperationalStoreOptions>>();
            operationalStoreOptions.Setup(x => x.Value)
                .Returns(new OperationalStoreOptions() 
                { 
                    DeviceFlowCodes = new TableConfiguration("DeviceCodes"),
                    EnableTokenCleanup = false,
                    PersistedGrants = new TableConfiguration("PersistedGrants"),
                    TokenCleanupBatchSize = 100,
                    TokenCleanupInterval = 3600
                }
            );


            using (var context = new ApplicationDbContext(ContextOptions, operationalStoreOptions.Object))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var allItems = BuildItemsCollection();
                var a = new ApplicationUser()
                {
                    Items = allItems.ToList()
                };

                context.Users.Add(a);

                context.SaveChanges();

                Mock<IStringLocalizer<Errors>> StringLocalizerMock = new Mock<IStringLocalizer<Errors>>(MockBehavior.Strict);

                string key = "OverviewItemsError";
                string value = "An error occured while getting items";
                var localizedString = new LocalizedString(key, value);
                StringLocalizerMock.Setup(_ => _[key]).Returns(localizedString);


                Mock<IMapper> MapperMock = new Mock<IMapper>(MockBehavior.Strict);

                var filteredItem = BuildFirstItem();
                var filteredItems = new List<Item>() { filteredItem };

                var filteredItemNameDto = BuildFirstItemNameDto();
                var filteredItemNameDtos = new List<ItemNameDto>() { filteredItemNameDto };

                MapperMock
                    .Setup(c => c.ProjectTo(
                        It.IsAny<IQueryable<Item>>(),
                        null,
                        It.Is<Expression<Func<ItemNameDto, object>>[]>(x => x.Length == 0)))
                 .Returns(filteredItemNameDtos.AsQueryable());


                var itemsDataService = new ItemsDataService(context, MapperMock.Object, StringLocalizerMock.Object);


                //Act
                var result = await itemsDataService.GetItemsNames("d", a.Id);

                //Assert
                AssertHelper.AssertAll(
                    () => result.Data.Count().Should().Be(1),
                    () => result.IsSuccess.Should().BeTrue(),
                    () => result.ErrorMessage.Should().BeNull()
                    );
            }
        }
    }
}
