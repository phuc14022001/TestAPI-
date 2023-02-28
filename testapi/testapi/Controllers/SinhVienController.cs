using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testapi.data;
using testapi.servces;

namespace testapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhVienController : ControllerBase
    {
        private readonly ISinhVien _iSinhVien;

        public SinhVienController(ISinhVien sinhVien)
        {
            _iSinhVien=sinhVien;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var a= _iSinhVien.GetAll();
                if (a.Count==0)
                {
                    return NoContent();
                }
                return Ok(a);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = _iSinhVien.SinhVienByGet(id);
                if (data == null) 
                    {
                        return NotFound();
                    }
                return Ok(_iSinhVien.SinhVienByGet(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, SinhVien s)
        {
            if (id != s.Id) return BadRequest();
            try
            {
                _iSinhVien.update(s);
                return NoContent(); // thông báo thành công và trả về kết quả ( 204 )
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            try
            {
                _iSinhVien.delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public IActionResult Add(SinhVien s)
        {
            try
            {

                return Ok(_iSinhVien.Add(s));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
