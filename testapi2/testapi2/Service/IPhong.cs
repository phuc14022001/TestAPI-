using testapi2.Models;
using testapi2.Data;
namespace testapi2.Service
{
    public interface IPhong
    {
        List<Phong> GetAll();
        Phongs GetById(int id);
        Phongs Add(Phong phong);
        void Update(int id,Phongs Phong);
        void Remote(int id);
    }
}
