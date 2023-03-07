using System.ComponentModel.DataAnnotations;

namespace testapi2.Data
{
    public class Tang
    {
        [Key]
        public int IdSonha { get; set; }
        public int IdTang { get; set; }
      
        public string ChuTro { get; set; }
        public ICollection<Phong> phongs { get; set; }
    }
}
