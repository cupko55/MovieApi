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
    [Route("api/Type")]
    [ApiVersion("1.0")]
    [Authorize]
    public class TypeController : Controller
    {
        private readonly ITypeService _typeService;

        public TypeController(ITypeService service)
        {
            _typeService = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {            
            var model = await _typeService.GetList();
            if(model == null)
            {
                return NotFound("Tip nije pronaden");
            }

            return Ok(model);            
        }

        [HttpGet("{id:int:min(1)}", Name = "GetType")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {            
            var model = await _typeService.Get(id);
            if(model == null)
            {
                return NotFound("Tip nije pronaden");
            }                

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TypeDto model)
        {
            try
            {
                if(!ModelState.IsValid)
                {   
                    var result = new BadRequestObjectResult(ModelState);                 
                    return result;
                }

                await _typeService.Create(model);
                return Ok("Dodan tip filma");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }            
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<IActionResult> Put([FromRoute]int id, [FromBody] TypeDto model)
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

                await _typeService.Update(model);
                return Ok("Tip filma izmjenjena");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }            
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var entity = await _typeService.Get(id);
            if(entity == null)
            {
                return NotFound();
            }
            
            try
            {
                await _typeService.Delete(id);
                return Ok("Tip filma obrisan");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }            
        }
    }
}