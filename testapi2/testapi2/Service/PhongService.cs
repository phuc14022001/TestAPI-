using Microsoft.EntityFrameworkCore;
using testapi2.Data;
using testapi2.Models;

namespace testapi2.Service
{
    public class PhongService : IPhong
    {
        private readonly MyDbConText _myDbContext;

        public PhongService(MyDbConText myDbConText)
        {
            _myDbContext = myDbConText;
        }

        public Phongs Add(Phong phong)
        {
            var a = _myDbContext.phongs.Select(x => x.IdPhong == phong.IdPhong);
            if (a == null)
            {
                var newp = new Phongs
                {
                    IdPhong = phong.IdPhong,
                    IdTang = phong.IdTang,
                    SoPhong = phong.SoPhong,
                    TenChuPhong = phong.TenChuPhong
                };
                _myDbContext.Add(newp);
                _myDbContext.SaveChanges();
                return new Phongs
                {
                    IdPhong = newp.IdPhong,
                    IdTang = newp.IdTang,
                    SoPhong = newp.SoPhong,
                    TenChuPhong = newp.TenChuPhong
                };
            }
            return null;
        }

        public List<Phong> GetAll()
        {
            var phong = _myDbContext.phongs.Select(a => new Phong
            {
                IdPhong = a.IdPhong,
                IdTang = a.IdTang,
                SoPhong = a.SoPhong,
                TenChuPhong = a.TenChuPhong
            });

            return phong.ToList();
        }

        public Phongs GetById(int id)
        {
            var phong = _myDbContext.phongs.SingleOrDefault(s => s.IdPhong == id);
            if (phong != null)
            {
                return new Phongs
                {
                    IdPhong = phong.IdPhong,
                    IdTang = phong.IdTang,
                    SoPhong = phong.SoPhong,
                    TenChuPhong = phong.TenChuPhong
                };
            }
            return null;
        }

        public void Remote(int id)
        {
            var phong = _myDbContext.phongs.SingleOrDefault(s => s.IdPhong == id);
            if (phong != null)
            {
                _myDbContext.Remove(phong);
                _myDbContext.SaveChanges();
            };
        }

        public void Update(int id,Phongs Phong)
        {
            var phong = _myDbContext.phongs.SingleOrDefault(a => a.IdPhong==Phong.IdPhong);
            Phong.IdPhong = phong.IdPhong;
            Phong.IdTang = phong.IdTang;
            Phong.SoPhong = phong.SoPhong;
            Phong.TenChuPhong = phong.TenChuPhong;
            _myDbContext.SaveChanges();
        }
    }
}
