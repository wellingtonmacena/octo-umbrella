using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Octo_Umbrella_API.Models;
using Octo_Umbrella_API.Services;

namespace Octo_Umbrella_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : Controller
    {
        public NoteService NoteService { get; set; }
        public NoteController()
        {
            NoteService = new NoteService();
        }
 
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(NoteService.GetAll());
        }

        [HttpPost]
        public IActionResult InsertOne([FromBody] Note note)
        {
            try
            {
                NoteService.Create(note);
                return StatusCode(201,note);
            }
            catch (Exception ex)
            {

                return StatusCode(500,ex);
            }
        }
    }
}
