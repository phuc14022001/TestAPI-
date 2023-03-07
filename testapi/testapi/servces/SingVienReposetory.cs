using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using testapi.data;

namespace testapi.servces
{
    public class SingVienReposetory : ISinhVien
    {
        private readonly MyDbContext _dbContext;

        public SingVienReposetory(MyDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public SinhVien Add(SinhVien s)
        {
            var newsv = new SinhVien
            {
                Name= s.Name,
                Age= s.Age,
                Nganh= s.Nganh
            };
            _dbContext.Add(newsv);
            _dbContext.SaveChanges();
            return new  SinhVien
            {
                Id = newsv.Id,
                Name = newsv.Name,
                Age = newsv.Age,
                Nganh = newsv.Nganh
            };
        }

        public void delete(int id)
        {
            var sinhvien= _dbContext.sinhViens.SingleOrDefault(s => s.Id== id);
            if (sinhvien!=null)
            {
                _dbContext.Remove(sinhvien);
                _dbContext.SaveChanges();
            }
        }

        public List<SinhVien> GetAll()
        {
            return _dbContext.sinhViens.ToList();
        }

        public SinhVien SinhVienByGet(int id)
        {
            var sinhvien = _dbContext.sinhViens.SingleOrDefault(s => s.Id== id);
            if (sinhvien != null) {
                return new SinhVien
                {
                    Id = sinhvien.Id,
                    Name = sinhvien.Name,
                    Age = sinhvien.Age,
                    Nganh = sinhvien.Nganh
                };
            }return null;
        }

        public void update(int id,SinhVien s)
        {
            var sinhvien = _dbContext.sinhViens.SingleOrDefault(a=> a.Id==id);
            s.Id = sinhvien.Id;
            s.Name = sinhvien.Name;
            s.Age = sinhvien.Age;
            s.Nganh = sinhvien.Nganh;
            _dbContext.SaveChanges();
        }
    }
}
