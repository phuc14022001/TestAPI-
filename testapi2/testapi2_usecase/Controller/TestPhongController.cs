using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using testapi2.Controllers;
using testapi2.Data;
using testapi2.Models;
using testapi2.Service;
using testapi2_usecase.Data;

namespace testapi2_usecase.Controller
{
    public class TestPhongController
    {
        private readonly MyDbConText _myDbContext;
        public TestPhongController()
        {
            var options = new DbContextOptionsBuilder<MyDbConText>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            _myDbContext = new MyDbConText(options);

            _myDbContext.Database.EnsureCreated();
        }

        [Fact]
        //200
        public async Task Getall_ShouldReturn200Status()
        {
            var Phong = new Mock<IPhong>();
            Phong.Setup(_ => _.GetAll()).Returns(PhongData.GetPhongs);
            var sut = new PhongController(Phong.Object,_myDbContext);

            var result = sut.GetAll();

            result.GetType().Should().Be(typeof(OkObjectResult));
            //result.GetType().Should().Be(typeof(OkObjectResult));
           // (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        //200
        public async Task Getall_ShouldReturn204Status()
        {
            var Phong = new Mock<IPhong>();
            Phong.Setup(_ => _.GetAll()).Returns(PhongData.GetPhongNull);
            var sut = new PhongController(Phong.Object, _myDbContext);

            var result = sut.GetAll();

            result.GetType().Should().Be(typeof(NoContentResult));
        }

        [Fact]
        //200
        public async Task GetById_ShouldReturn200Status()
        {
            var Phong = new Mock<IPhong>();
            var newid = PhongData.GetById1();
            var sut = new PhongController(Phong.Object, _myDbContext);

            var result = sut.GetById(newid.IdPhong);

            Phong.Verify(a => a.GetById(newid.IdPhong), Times.Exactly(1));

            //result.GetType().Should().Be(typeof(OkObjectResult));
            //result.GetType().Should().Be(typeof(OkObjectResult));
            // (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetById_ShouldReturn404Status()
        {
            var Phong = new Mock<IPhong>();
            var newid = PhongData.GetById2();
            var sut = new PhongController(Phong.Object, _myDbContext);

            var result = sut.GetById(newid.IdPhong);

            result.GetType().Should().Be(typeof(NotFoundResult));
        }

        [Fact]
        public async Task Add_ShouldReturn200Status()
        {
            var Phong = new Mock<IPhong>();
            var newid = PhongData.GetById2();
            var sut = new PhongController(Phong.Object, _myDbContext);

            var result = sut.Add(newid);

            result.GetType().Should().Be(typeof(OkObjectResult));
        }



        public void Dispose()
        {
            _myDbContext.Database.EnsureCreated();

            _myDbContext.Dispose();
        }
    }
}
