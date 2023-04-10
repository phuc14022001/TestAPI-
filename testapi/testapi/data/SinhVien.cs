using System.ComponentModel.DataAnnotations;

namespace testapi.data
{
    public class SinhVien
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Nganh { get; set; }

    }
}
