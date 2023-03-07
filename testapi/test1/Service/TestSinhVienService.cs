using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using test1.Data;
using testapi.data;
using testapi.servces;

namespace test1.Service
{
    public class TestSinhVienService:IDisposable
    {
        private readonly MyDbContext _myDbContext;
        public TestSinhVienService() 
        {
            var options = new DbContextOptionsBuilder<MyDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            _myDbContext = new MyDbContext(options);

            _myDbContext.Database.EnsureCreated();
        }

        [Fact]
        public async Task GetAll_ReturnSinhienController()
        {
            _myDbContext.sinhViens.AddRange(SinhViendata.GetSinhViens());
            _myDbContext.SaveChangesAsync();
            var sut = new SingVienReposetory(_myDbContext);

            var result =sut.GetAll();

            result.Should().HaveCount(SinhViendata.GetSinhViens().Count);

        }

        [Fact]
        public async Task add_ReturnSinhVienController()
        {
            var SV = SinhViendata.NewSinhVien();
            _myDbContext.sinhViens.AddRange(SinhViendata.GetSinhViens());
            _myDbContext.SaveChangesAsync();
            var sut  = new SingVienReposetory(_myDbContext);

            var result = sut.Add(SV);

            int expectedRecordCount = (SinhViendata.GetSinhViens().Count() + 1);
            _myDbContext.sinhViens.Count().Should().Be(expectedRecordCount);
        }
        [Fact]
        public async Task delete_ReturnSinhVienController()
        {
            var SV = SinhViendata.updateSinhVien().Id;
            _myDbContext.sinhViens.AddRange(SinhViendata.GetSinhViens());
            _myDbContext.SaveChangesAsync();
            var sut = new SingVienReposetory(_myDbContext);

            sut.delete(SV);

            int expectedRecordCount = (SinhViendata.GetSinhViens().Count() - 1);
            _myDbContext.sinhViens.Count().Should().Be(expectedRecordCount);
        }
        [Fact]
        public async Task GetByid_ReturnSinhienController()
        {
            var SV = SinhViendata.updateSinhVien();
            _myDbContext.sinhViens.AddRange(SinhViendata.updateSinhVien());
            _myDbContext.SaveChangesAsync();
            var sut = new SingVienReposetory(_myDbContext);

            var result = sut.SinhVienByGet(SV.Id);

         //   int expectedRecordCount = SinhViendata.GetSinhViens().Count();
         //   result.Should().Be(expectedRecordCount);
            Assert.IsType<SinhVien>(result);
        }
        [Fact]
        public async Task Update_ReturnSinhienController()
        {
            var SV = SinhViendata.updateSinhVien();
            _myDbContext.sinhViens.AddRange(SinhViendata.GetSinhViens());
            _myDbContext.SaveChangesAsync();
            var sut = new SingVienReposetory(_myDbContext);

            var result = sut.SinhVienByGet(SV.Id);


            Assert.Equal(SV.Name, result.Name);
            Assert.IsType<SinhVien>(result);
        }
        public void Dispose()
        {
            _myDbContext.Database.EnsureCreated();

            _myDbContext.Dispose();
        }
    }
}
