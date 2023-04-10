using System.Runtime.CompilerServices;
using testapi.data;

namespace testapi.servces
{
    public interface ISinhVien
    {
        List<SinhVien> GetAll();

        SinhVien SinhVienByGet(int id);
        SinhVien Add(SinhVien s);
        void update(SinhVien s);
        void delete(int id);
    }
}
