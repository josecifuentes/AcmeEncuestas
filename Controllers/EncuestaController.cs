using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAcmeEncuestasV1.Models;
using WebApiAcmeEncuestasV1.Services;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiAcmeEncuestasV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncuestaController : ControllerBase
    {
      
        public EncuestaService _encuestaService;
        private readonly JwtAuthenticationManager jwtAuthenticationManager;
        public EncuestaController(EncuestaService encuestaService, JwtAuthenticationManager jwtAuthenticationManager)
        {
            _encuestaService = encuestaService;
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }
        [HttpGet("get/all")]
        public IActionResult GetAllEncuestas()
        {
            var allEncuestas = _encuestaService.GetAllEncuestas();
            return Ok(allEncuestas);
        }
        [Authorize]
        [HttpGet("get/byid/{id}")]
        public IActionResult GetEncuestaById(int id)
        {
            var encuesta = _encuestaService.GetEncuestaById(id);
            return Ok(encuesta);
        }
        // GET: api/<EncuestaController>
        [Authorize]
        [HttpPost]
        public IActionResult AddEncuesta([FromBody]Encuesta encuesta)
        {
            _encuestaService.AddEncuesta(encuesta);
            return Ok("Url:llenar/encuesta/"+encuesta.Id);
        }
        [Authorize]
        [HttpPut("update/encuesta/byid/{id}")]
        public IActionResult UpdateEncuestaById(int id, [FromBody]Encuesta encuesta)
        {
            var updatedEncuesta = _encuestaService.UpdateEncuestaById(id, encuesta);
            return Ok(updatedEncuesta);
        }
        [Authorize]
        [HttpDelete("delete/encuesta/byid/{id}")]
        public IActionResult DeleteEncuestaById(int id)
        {
            _encuestaService.DeleteEncuestaById(id);
            return Ok();
        }
        [AllowAnonymous]
        // GET: api/<EncuestaController>
        [HttpPost("llenar/encuesta/{id}")]
        public IActionResult LlnearEncuesta([FromBody]LlenarEncuesta llenado)
        {
            _encuestaService.LlenarEncuesta(llenado);
            return Ok("Encuesta llenada con exito");
        }
        [Authorize]
        [HttpGet("get/llenado/byid/{id}")]
        public IActionResult GetLlenadoById(int id)
        {
            var encuesta = _encuestaService.GetLlenadoById(id);
            return Ok(encuesta);
        }

        [AllowAnonymous]
        [HttpPost("Authorize")]
        public IActionResult AuthUser([FromBody] user usr)
        {
            var token = jwtAuthenticationManager.Authenticate(usr.username, usr.password);
            if(token==null)
            {
                return Unauthorized();
            }
            
            return Ok(token);
        }
        public class user
        {
            public string username { get; set; }
            public string password { get; set; }
        }
    }
}
