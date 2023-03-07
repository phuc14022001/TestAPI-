using System.ComponentModel.DataAnnotations;

namespace testapi2.Data
{
    public class Phong
    {
        [Key]
        public int IdPhong { get; set; }      
        public int SoPhong { get; set; }
    
        public string TenChuPhong { get; set; }
        public int IdTang { get; set; }
        public Tang tang { get; set; }
    }
}
