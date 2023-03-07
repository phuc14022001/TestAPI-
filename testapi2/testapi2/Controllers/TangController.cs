using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testapi2.Data;
using testapi2.Models;
using testapi2.Service;

namespace testapi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TangController : ControllerBase
    {
        private readonly ITang _iTang;
        private readonly MyDbConText _myDbContext;
        public TangController(ITang tang, MyDbConText myDbConText)
        {
            _iTang= tang;
            _myDbContext = myDbConText;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var a = _iTang.GetAll();
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
                var a = _iTang.GetById(id);
                if (a == null)
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
        [HttpPost]
        public IActionResult Add(Tangs t)
        {
            try
            {
                var a = _myDbContext.tangs.Select(p => p.IdTang==t.IdTang);

                if (a == null)
                {
                    return BadRequest();
                }

                return Ok(_iTang.Add1(t));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("{id}")]
        public IActionResult update(int id, Tangs t)
        {
            if (id != t.IdTang) return NoContent();
            try
            {
                _iTang.Update(id, t);
                return Ok();
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
                _iTang.Remote(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
