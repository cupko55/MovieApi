using System;
using System.Collections.Generic;
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
    [Route("api/Studio")]
    [ApiVersion("1.0")]
    [Authorize]
    public class StudioController : Controller
    {
        private readonly IStudioService _studioService;

        public StudioController(IStudioService service)
        {
            _studioService = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {            
            var model = await _studioService.GetList();
            if(model == null)
            {
                return NotFound("Studio nije pronađen");
            }

            return Ok(model);            
        }

        [HttpGet("{id:int:min(1)}", Name = "GetStudio")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {            
            var model = await _studioService.Get(id);
            if(model == null)
            {
                return NotFound("Studio nije pronaden");
            }

            return Ok(model);                
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudioDto model)
        {
            try{
                if(!ModelState.IsValid)
                {   
                    var result = new BadRequestObjectResult(ModelState);                 
                    return result;
                }                    

                await _studioService.Create(model);
                return Ok("Dodan filmski studio");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }            
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<IActionResult> Put([FromRoute]int id, [FromBody] StudioDto model)
        {
            if(id != model.Id)
            {
                return BadRequest();
            }

            try{
                if(!ModelState.IsValid)
                {                    
                    var result = new BadRequestObjectResult(ModelState);                 
                    return result;
                }                  

                await _studioService.Update(model);
                return Ok("Filmski studio izmjenjen");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }            
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var entity = await _studioService.Get(id);
            if(entity == null)
            {
                return NotFound();
            }

            try{
                await _studioService.Delete(id);
                return Ok("Filmski studio obrisan");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }            
        }
    }
}