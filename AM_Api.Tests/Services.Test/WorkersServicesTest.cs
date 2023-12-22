using AM_Api.DataAccess;
using AM_Api.Helpers;
using AM_Api.Models.Worker;
using AM_Api.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace AM_Api.Tests.Services.Test
{
    public class WorkersServicesTest
    {
        private WorkersService _service;

        IQueryable data;

        readonly string strPassword = "TestPassword";
        string encryption;
        byte[] password;

        [SetUp]
        public void Setup()
        {
            encryption = HelperCryptography.GenerateSalt();
            password = HelperCryptography.EncryptPassword(strPassword, encryption);

            data = new[]
            {
                new Workers
                {
                    Id = 1,
                    Name = "test",
                    LastName = "test",
                    Password = password,
                    Cifrado = encryption,
                    Email = "test@test.pe",
                },
                new Workers
                {
                    Id = 2,
                    Name = "Test2",
                    LastName = "Test2",
                    Password = password,
                    Cifrado = encryption,
                    Email = "test2@test.pe",
                },
            }.AsQueryable();

            var mockWorker = new Mock<DbSet<Workers>>();
            mockWorker.As<IQueryable<Workers>>().Setup(o => o.Provider).Returns(data.Provider);
            mockWorker.As<IQueryable<Workers>>().Setup(o => o.Expression).Returns(data.Expression);
            mockWorker.As<IQueryable<Workers>>().Setup(o => o.ElementType).Returns(data.ElementType);
            mockWorker.As<IQueryable<Workers>>().Setup(o => o.GetEnumerator()).Returns((IEnumerator<Workers>)data.GetEnumerator());

            var mockDb = new Mock<ContextDB>();
            mockDb.Setup(o => o.Workers).Returns(mockWorker.Object);

            _service = new WorkersService(mockDb.Object);
        }

        [Test]
        public void RegisterWorkerWithNotExistingEmail()
        {
            var data = new
            {
                email = "test1@test.pe",
                name = "Test",
                lastName = "Test",
                password = "Test",
            };
            var result = _service.Register(data.email, data.name, data.lastName, data.password);
            Assert.That(result.IsRegistered, Is.EqualTo(true));
        }

        [Test]
        public void RegisterWorkerWithExistingEmail()
        {
            var data = new
            {
                email = "test@test.pe",
                name = "Test",
                lastName = "Test",
                password = "Test",
            };
            var result = _service.Register(data.email, data.name, data.lastName, data.password);
            Assert.That(result.IsRegistered, Is.EqualTo(false));
        }

        [Test]
        public void GetAllWorkers()
        {
            var result = _service.GetAllWorkers();
            Assert.That(result.Count(), Is.EqualTo(2));
        }
    }
}