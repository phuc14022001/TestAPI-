using testapi2.Models;
using testapi2.Data;
namespace testapi2.Service
{
    public interface ITang
    {
        List<Tang> GetAll();
        Tangs GetById(int id);
        Tangs Add1(Tangs Tang);
        void Update(int id,Tangs Tang);
        void Remote(int id);
    }
}
