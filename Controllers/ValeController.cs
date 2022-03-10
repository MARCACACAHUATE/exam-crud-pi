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
            try {
                using(TAdminContext db = new TAdminContext()) {
                    var list = db.TvaleCcs.OrderByDescending(d => d.Id).ToList();
                    
                    respuesta.message = "Operación Exitosa";
                    respuesta.Estado = 1;
                    respuesta.data = list;
                }
            }catch(Exception error){
                respuesta.message = error.Message;
            }
            return Ok(respuesta);
        }

        [HttpPost]
        public IActionResult Post(Request request){
            Response respuesta = new Response();
            
            try{
                using(TAdminContext db = new TAdminContext()){
                    
                    TvaleCc new_vale = new TvaleCc();
                    
                    new_vale.Fecha = DateTime.Now;
                    new_vale.Folio = request.folio;
                    new_vale.Monto = request.monto;
                    new_vale.Saldo = request.saldo;
                    new_vale.Motivo = request.motivo;

                    db.TvaleCcs.Add(new_vale);
                    db.SaveChanges();

                    respuesta.message = "Registro creado con exito";
                    respuesta.Estado = 1;
                    respuesta.data = new_vale;
                }

            }catch(Exception error){
                respuesta.message = error.Message;
            }

            return Ok(respuesta);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id) {
            Response respuesta = new Response();
            
            try{
                using(TAdminContext db = new TAdminContext()){
                    TvaleCc vale = db.TvaleCcs.Find(id);
                    db.Remove(vale);
                    db.SaveChanges();

                    respuesta.Estado = 1;
                    respuesta.message = "Registro elimindado con exito";
                    respuesta.data = vale;
                }
                
            }catch(Exception){
                respuesta.message = $"El registro {id} no existe";
            }

            return Ok(respuesta);
        } 

        [HttpPut]
        public IActionResult Put(Request request) {
            Response respuesta = new Response();
            try{
                using(TAdminContext db = new TAdminContext()){
                    TvaleCc vale = db.TvaleCcs.Find(request.id);

                    vale.Motivo = request.motivo;


                    db.Entry(vale).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();

                    respuesta.message = "Se modifico el registro";
                    respuesta.data = request.motivo;
                }

            }catch(Exception error){
                respuesta.message = error.Message;
            }
            return Ok(respuesta);
        }
    }
}