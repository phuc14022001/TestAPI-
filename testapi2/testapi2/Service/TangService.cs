using Microsoft.EntityFrameworkCore;
using testapi2.Data;
using testapi2.Models;

namespace testapi2.Service
{
    public class TangService : ITang
    {
        private readonly MyDbConText _MyDbContext;

        public TangService(MyDbConText myDbConText) 
        {
            _MyDbContext = myDbConText;
        }

        public Tangs Add1(Tangs a)
        {
            var tang = new Tang
            {
                
                IdSonha = a.IdSonha,
                ChuTro = a.ChuTro
            };
            _MyDbContext.Add(tang);
            _MyDbContext.SaveChanges();
            return new Tangs
            {
                IdTang= tang.IdTang,
                IdSonha = tang.IdSonha,
                ChuTro = tang.ChuTro
            };
          
        }

        public List<Tang> GetAll()
        {
            var tang = _MyDbContext.tangs.Select(a => new Tang
            {
                IdTang = a.IdTang,
                IdSonha = a.IdSonha,
                ChuTro = a.ChuTro
            });
            return tang.ToList();
        }

        public Tangs GetById(int id)
        {
            var a= _MyDbContext.tangs.FirstOrDefault(p => p.IdTang == id);
            if (a != null)
            {
                return new Tangs
                {
                    IdTang = a.IdTang,
                    IdSonha = a.IdSonha,
                    ChuTro = a.ChuTro
                };
            }
            return null;
        }

        public void Remote(int id)
        {
            var tang = _MyDbContext.tangs.SingleOrDefault(s => s.IdTang == id);
            if (tang != null)
            {
                _MyDbContext.Remove(tang);
                _MyDbContext.SaveChanges();
            };
        }

        public void Update(int id,Tangs Tang)
        {
            var phong = _MyDbContext.phongs.SingleOrDefault(a => a.IdTang == Tang.IdTang);
            Tang.IdTang= Tang.IdTang;
            Tang.IdSonha = Tang.IdSonha;
            Tang.ChuTro = Tang.ChuTro;
            _MyDbContext.SaveChanges();
        }
    }
}
