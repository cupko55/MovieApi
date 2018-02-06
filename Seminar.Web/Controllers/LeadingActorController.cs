using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Seminar.Service;
using Seminar.Service.DTO;

namespace Seminar.Web.Controllers
{    
    [Produces("application/json")]
    [Route("api/LeadingActor")]
    [ApiVersion("1.0")]
    [Authorize]
    public class LeadingActorController : Controller
    {
        private readonly ILeadingActorService _leadingActorService;

        public LeadingActorController(ILeadingActorService service)
        {
            _leadingActorService = service;
        }
        
        // GET: api/LeadingActor
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var model = await _leadingActorService.GetList();             
            if(model == null)
            {
                return NotFound("Glumac nije pronaden");
            }            
            return Ok(model);
        }

        // GET: api/LeadingActor/5
        [HttpGet("{id:int:min(1)}", Name = "GetLeadingActor")]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var model = await _leadingActorService.Get(id);            
            if(model == null)                
            {
                return NotFound("Glumac nije pronaden");
            }                

            return Ok(model);
        }
        
        // POST: api/LeadingActor
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]LeadingActorDto model)
        {
            try
            {
                if(!ModelState.IsValid)
                {   
                    var result = new BadRequestObjectResult(ModelState);                 
                    return result;
                }                  

                await _leadingActorService.Create(model);
                return Ok("Glumac dodan");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
            
        }
        
        // PUT: api/LeadingActor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute]int id, [FromBody]LeadingActorDto model)
        {
            if(id != model.Id)
            {
                return BadRequest();
            }

            try
            {
                if(!ModelState.IsValid)
                {   
                    var result = new BadRequestObjectResult(ModelState);                 
                    return result;
                }                  
            
                await _leadingActorService.Update(model);
                return Ok("Glumac izmjenjen");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
            
        }
        
        // DELETE: api/LeadingActor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _leadingActorService.Get(id);
            if(entity == null)
            {
                return NotFound();
            }

            try
            {
                await _leadingActorService.Delete(id);
                return Ok("Glumac obrisan");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
            
        }
    }
}
