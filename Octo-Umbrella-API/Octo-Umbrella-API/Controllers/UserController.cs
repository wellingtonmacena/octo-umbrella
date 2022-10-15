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
        public UserController()
        {
            UserRepository = new UserRepository();
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
        [SwaggerOperation(Summary = "Gets one User filtered by id.", Description = "Returns a User object.")]
        public IActionResult GetById(string id)
        {
            User User = UserRepository.GetById(id);
            if (User == null)
                return NotFound();

            return Ok(User);
        }

        [HttpPost]
        [Route("[controller]")]
        [SwaggerOperation(Summary = "Gets one User filtered by id.", Description = "Returns a User object.")]
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
        [SwaggerOperation(Summary = "Gets one User filtered by id.", Description = "Returns a User object.")]
        public IActionResult Login([FromBody] User user)
        {
            try
            {
                User foundUser= UserRepository.Login(user);
                if (foundUser == null)
                    return NotFound();

                return Ok(foundUser);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("[controller]/{id}")]
        [SwaggerOperation(Summary = "Updates one User filtered by id.", Description = "Returns User object updated.")]
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
        [SwaggerOperation(Summary = "Deletes all Userd saved.", Description = "Returns nothing")]
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
        [SwaggerOperation(Summary = "Deletes one User filtered by id .", Description = "Returns nothing")]
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