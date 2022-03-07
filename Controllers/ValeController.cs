using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using crud.Models;
using crud.Models.Response;
using crud.Models.Request;


namespace crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValeController : ControllerBase {

        [HttpGet]
        public IActionResult Get() {
            Response respuesta = new Response();

            using(TAdminContext db = new TAdminContext()) {
                var list = db.TvaleCcs.OrderByDescending(d => d.Id).ToList();
                respuesta.data = list;
            }
            
            return Ok(respuesta);
        }

        [HttpPost]
        public IActionResult Post(Request request){
            Response respuesta = new Response();
            using(TAdminContext db = new TAdminContext()){
                TvaleCc new_vale = new TvaleCc();
                new_vale.Folio = request.folio;
                db.TvaleCcs.Add(new_vale);
                db.SaveChanges();
                respuesta.data = new_vale;
            }
            return Ok(respuesta);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id) {
            Response respuesta = new Response();
            using(TAdminContext db = new TAdminContext()){
                TvaleCc vale = db.TvaleCcs.Find(id);
                db.Remove(vale);
                db.SaveChanges();
                respuesta.data = vale;
            }

            return Ok(respuesta);
        } 

        [HttpPut]
        public IActionResult Put(Request request) {
            Response respuesta = new Response();

            using(TAdminContext db = new TAdminContext()){
                TvaleCc vale = db.TvaleCcs.Find(request.id);

                vale.Motivo = request.motivo;


                db.Entry(vale).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

                respuesta.message = "Se modifico el registro";
                respuesta.data = request.motivo;
            }


            return Ok(respuesta);
        }
    }
}