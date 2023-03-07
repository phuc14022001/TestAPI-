using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testapi2.Data;
using testapi2.Models;

namespace testapi2_usecase.Data
{
    public class PhongData
    {
        public static List<Phong> GetPhongs()
        {
            return new List<Phong> 
            {
                new Phong
                {
                    IdPhong= 1,
                    IdTang= 1,
                    SoPhong= 1,
                    TenChuPhong = "Phuc"
                },
                new Phong
                {
                    IdPhong= 2,
                    IdTang= 2,
                    SoPhong= 2,
                    TenChuPhong= "abc"
                }
            }; 
        }
        public static List<Phong> GetPhongNull()
        {
            return new List<Phong>();
        }

        public static Phong GetById1()
        {
            return new Phong 
            {
                IdPhong = 1,
                IdTang = 1,
                SoPhong = 1,
                TenChuPhong = "Phuc"
            };
        }
        public static Phong GetById2()
        {
            return new Phong() { };
        }
        public static Phongs GetById3()
        {
            return new Phongs
            {
                IdPhong = 1,
                IdTang = 1,
                SoPhong = 1,
                TenChuPhong = "Phuc"
            };
        }
    }
}
