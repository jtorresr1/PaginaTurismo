using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Errores;
using Infraestructura.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ErrorTestController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ErrorTestController(ApplicationDbContext db)
        {
            _db = db;
        }


        [HttpGet("not found")]
        public ActionResult GetNonFoundError()
        {
            var something = _db.Lugar.Find(166);
            if (something == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }


        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var something = _db.Lugar.Find(166);
            var somethingretornar = something.ToString(); 

            if (something == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequestError()
        {
            return BadRequest(new ApiResponse(400));
        }


        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequestError(int id)
        {
            return BadRequest();
        }

    }
}