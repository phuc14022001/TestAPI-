using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testapi2.Data;
using testapi2.Models;
using testapi2.Service;

namespace testapi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhongController : ControllerBase
    {
        private readonly IPhong _iPhong;
        private readonly MyDbConText _myDbContext;
        public PhongController(IPhong phong,MyDbConText myDbConText) 
        {
            _iPhong = phong;
            _myDbContext = myDbConText;
        }    
        [HttpGet]
        public IActionResult GetAll()
        {            
            try
            {
                var a = _iPhong.GetAll();
                if (a.Count == 0)
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
                var a= _iPhong.GetById(id);
                if(a== null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public IActionResult Add( Phong p)
        {
            try 
            {
                    return Ok(_iPhong.Add(p));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("{id}")]
        public IActionResult update(int id,Phongs p)
        {
            if (id != p.IdPhong) return BadRequest();
            try
            {
                _iPhong.Update(id,p);
                return NoContent(); 
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
                _iPhong.Remote(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
