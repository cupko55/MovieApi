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
    [Route("api/Movie")]
    [ApiVersion("1.0")]
    [Authorize]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService service)
        {
            _movieService = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {            
            var model = await _movieService.GetList();
            if(model == null)
            {
                return NotFound("Film nije pronaden");
            }

            return Ok(model);            
        }

        [HttpGet("{id:int:min(1)}", Name = "GetMovie")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {            
            var model = await _movieService.Get(id);
            if(model == null)
            {
                return NotFound("Film nije pronaden");
            }

            return Ok(model);            
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MovieDetailDto model)
        {
            try
            {
                if(!ModelState.IsValid)
                {   
                    var result = new BadRequestObjectResult(ModelState);                 
                    return result;
                }                  
                    
                await _movieService.Create(model);
                return Ok("Dodan film");    
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
            
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<IActionResult> Put([FromRoute]int id, [FromBody] MovieDetailDto model)
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
                
                await _movieService.Update(model);
                return Ok("Film izmjenjen");   
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }            
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _movieService.Get(id);
            if(entity == null)
            {
                return NotFound();
            }

            try
            {
                await _movieService.Delete(id);
                return Ok("Film obrisan");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
            
        }


    }
}