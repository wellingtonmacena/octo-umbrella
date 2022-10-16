﻿using Microsoft.AspNetCore.Mvc;
using Octo_Umbrella_API.Models;
using Octo_Umbrella_API.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace Octo_Umbrella_API.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        public UserRepository UserRepository { get; set; }
        public NoteRepository NoteRepository { get; set; }
        public UserController()
        {
            UserRepository = new UserRepository();
            NoteRepository = new NoteRepository();
        }

        [Route("[controller]")]
        [HttpGet]
        [SwaggerOperation(Summary = "Gets all users saved.", Description = "Returns a list with all users saved.")]
        public IActionResult GetAll()
        {
            return Ok(UserRepository.GetAll());
        }

        [Route("[controller]/{id}")]
        [HttpGet()]
        [SwaggerOperation(Summary = "Gets one user filtered by id.", Description = "Returns a user object.")]
        public IActionResult GetById(string id)
        {
            User User = UserRepository.GetById(id);
            if (User == null)
                return NotFound();

            return Ok(User);
        }

        [HttpPost]
        [Route("[controller]")]
        [SwaggerOperation(Summary = "Creates one user object", Description = "Returns a user object.")]
        public IActionResult InsertOne([FromBody] User User)
        {
            try
            {
                UserRepository.Create(User);
                return StatusCode(201, User);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route("[controller]/login")]
        [SwaggerOperation(Summary = "Signs in one user.", Description = "Returns a list with all notes of user saved")]
        public IActionResult Login([FromBody] User user)
        {
            try
            {
                User foundUser = UserRepository.Login(user);
                if (foundUser == null)
                    return NotFound();

                List<Note> notes = NoteRepository.GetAllFromUserByUserEmail(foundUser.Email);
                return Ok(new { User = foundUser, Notes = notes});
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("[controller]/{id}")]
        [SwaggerOperation(Summary = "Updates one user filtered by id.", Description = "Returns user object updated.")]
        public async Task<IActionResult> UpdateOne([FromBody] User User, string id)
        {
            try
            {
                User updatedUser = UserRepository.Update(User, id);

                if (updatedUser == null)
                    return NotFound();

                return StatusCode(200, updatedUser);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        [Route("[controller]")]
        [SwaggerOperation(Summary = "Deletes all users saved.", Description = "Returns nothing")]
        public IActionResult DeleteAll()
        {
            try
            {
                UserRepository.DeleteAll();
                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        [Route("[controller]/{id}")]
        [SwaggerOperation(Summary = "Deletes one user filtered by id .", Description = "Returns nothing")]
        public IActionResult DeleteOne(string id)
        {
            try
            {
                UserRepository.DeleteById(id);
                return StatusCode(200);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }
    }
}
