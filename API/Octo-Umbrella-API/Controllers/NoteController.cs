using Microsoft.AspNetCore.Mvc;
using Octo_Umbrella_API.Models;
using Octo_Umbrella_API.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace Octo_Umbrella_API.Controllers
{
    [ApiController]
    public class NoteController : Controller
    {
        public NoteRepository NoteRepository { get; set; }
        public NoteController()
        {
            NoteRepository = new NoteRepository();
        }

        [Route("[controller]")]
        [HttpGet]
        [SwaggerOperation(Summary = "Gets all notes saved.", Description = "Returns a list with all notes saved.")]    
        public IActionResult GetAll()
        {
            return Ok(NoteRepository.GetAll());
        }

        [Route("[controller]/{id}")]
        [HttpGet()]
        [SwaggerOperation(Summary = "Gets one note filtered by id.", Description = "Returns a Note object.")]
        public IActionResult GetById(string id)
        {
            Note note = NoteRepository.GetById(id);
            if (note == null)
                return NotFound();

            return Ok(note);
        }

        [HttpPost]
        [Route("[controller]")]
        [SwaggerOperation(Summary = "Creates one note object.", Description = "Returns a note object.")]
        public IActionResult InsertOne([FromBody] Note note)
        {
            try
            {
                NoteRepository.Create(note);
                return StatusCode(201, note);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("[controller]/{id}")]
        [SwaggerOperation(Summary = "Updates one note filtered by id.", Description = "Returns Note object updated.")]
        public async Task<IActionResult> UpdateOne([FromBody] Note note, string id)
        {
            try
            {
                Note updatedNote = NoteRepository.Update(note, id);

                if (updatedNote == null)
                    return NotFound();

                return StatusCode(200, updatedNote);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        [Route("[controller]")]
        [SwaggerOperation(Summary = "Deletes all noted saved.", Description = "Returns nothing")]
        public IActionResult DeleteAll()
        {
            try
            {
                NoteRepository.DeleteAll();
                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        [Route("[controller]/{id}")]
        [SwaggerOperation(Summary = "Deletes one note filtered by id .", Description = "Returns nothing")]
        public IActionResult DeleteOne(string id)
        {
            try
            {
                NoteRepository.DeleteById(id);
                return StatusCode(200);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }
    }
}
