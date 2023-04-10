using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using test1.Data;
using testapi.Controllers;
using testapi.data;
using testapi.servces;

namespace test1.contrtoller
{
    public class TestSinhVienController
    {
        [Fact]
        public async Task GetAll_ShouldReturn200Status()
        {
            //arranger
            var Sinhvien= new Mock<ISinhVien>();
            Sinhvien.Setup(_ => _.GetAll()).Returns(SinhViendata.GetSinhViens());
            var sut = new SinhVienController(Sinhvien.Object);

            //Act
            var result =sut.GetAll();


            // /// Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task GetAll_ShouldReturn204Status()
        {
            var Sinhvien = new Mock<ISinhVien>();                               //khai báo mock của ISinhVien
            Sinhvien.Setup(_ => _.GetAll()).Returns(SinhViendata.GetEmptyTodos());         //lấy dữ liệu trong file SinhViendata
            var sut = new SinhVienController(Sinhvien.Object);                  


            var result = sut.GetAll();                          // đưa dữ liệu vào hàm của controller


            // /// Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }
        [Fact]
        public async Task Add_ShouldReturn200Status()
        {
            var SinhVien = new Mock<ISinhVien>();
            var newadd= SinhViendata.NewSinhVien();
            var suut= new SinhVienController(SinhVien.Object);

            var result = suut.Add(newadd);

             SinhVien.Verify(a =>a.Add(newadd),Times.Exactly(1));
        }
        [Fact]
        public async Task Delete_ShouldReturn200Status()
        {
            var SinhVien = new Mock<ISinhVien>();
            var newid = SinhViendata.Newid().Id;
            var suut = new SinhVienController(SinhVien.Object);

            var result = suut.delete(newid);

            SinhVien.Verify(a => a.delete(newid), Times.Exactly(1));

        }
    }
}
