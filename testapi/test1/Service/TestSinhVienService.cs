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

        public void Dispose()
        {
            _myDbContext.Database.EnsureCreated();

            _myDbContext.Dispose();
        }
    }
}
