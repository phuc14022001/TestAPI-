using System.ComponentModel.DataAnnotations;

namespace testapi2.Models
{
    public class Phongs
    {
        public int IdPhong { get; set; }
        public int SoPhong { get; set; }
    
        public string TenChuPhong { get; set; }
        public int IdTang { get; set; }
    }
}
