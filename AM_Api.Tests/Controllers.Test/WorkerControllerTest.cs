using AM_Api.Controllers;
using AM_Api.Models.Worker;
using AM_Api.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework.Legacy;
using AM_Api.Helpers;
using Microsoft.EntityFrameworkCore;
using AM_Api.DataAccess;

namespace AM_Api.Tests.Controllers.Test
{
    public class WorkerControllerTest
    {
        private WorkersController _controller;
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

            data = new []
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
            }.AsQueryable();

            var mockWorker = new Mock<DbSet<Workers>>();
            mockWorker.As<IQueryable<Workers>>().Setup(o => o.Provider).Returns(data.Provider);
            mockWorker.As<IQueryable<Workers>>().Setup(o => o.Expression).Returns(data.Expression);
            mockWorker.As<IQueryable<Workers>>().Setup(o => o.ElementType).Returns(data.ElementType);
            mockWorker.As<IQueryable<Workers>>().Setup(o => o.GetEnumerator()).Returns((IEnumerator<Workers>)data.GetEnumerator());

            var mockDb = new Mock<ContextDB>();
            mockDb.Setup(o => o.Workers).Returns(mockWorker.Object);
            
            _service = new WorkersService(mockDb.Object);

            _controller = new WorkersController(_service);
        }

        [Test]
        public void RegisterWorkerOkResult()
        {
            var workerData = new WorkerRegistrationModel
            {
                Email = "test@example.com",
                Password = "testpassword",
                Name = "John",
                LastName = "Doe"
            };

            var result = _controller.RegisterWorker(workerData) as ObjectResult;

            ClassicAssert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public void RegisterWorkerNotOkResult()
        {
            var workerData = new WorkerRegistrationModel
            {
                Email = "test@test.pe",
                Password = "testpassword",
                Name = "John",
                LastName = "Doe"
            };

            var result = _controller.RegisterWorker(workerData) as ObjectResult;

            ClassicAssert.AreEqual(400, result.StatusCode);
        }

        [Test]
        public void GetAllWorkersOkResult()
        {
            var result = _controller.GetAllWorkers();
            Assert.That(result.Count(), Is.EqualTo(1));
        }
    }
}
