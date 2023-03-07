using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testapi.data;

namespace test1.Data
{
    public class SinhViendata
    {
        public static List<SinhVien> GetSinhViens()
        {
            return new List<SinhVien>
            {
                new SinhVien
                {
                    Id = 1,
                    Name= "Test",
                    Age= 30,
                    Nganh="ktpm"
                },
                new SinhVien
                {
                    Id = 2,
                    Name= "Test1",
                    Age= 30,
                    Nganh="CNTT"
                }
            };
        }
        public static SinhVien updateSinhVien()
        {
            return new SinhVien
            {
                    Id = 1,
                    Name= "Test",
                    Age= 30,
                    Nganh="ktpm"
          
            };
        }
        public static List<SinhVien> GetEmptyTodos()
        {
            return new List<SinhVien>();
        }
        public static SinhVien GetEmptyTodos1()
        {
            return new SinhVien() { };

        }
        public static SinhVien NewSinhVien()
        {
            return new SinhVien
            {
                Name = "Test3",
                Age = 32,
                Nganh = "CNTT"
            }; 
        }
        public static SinhVien Newid()
        {
            return new SinhVien
            {
                Id= 1
            };
        }

    }
}
