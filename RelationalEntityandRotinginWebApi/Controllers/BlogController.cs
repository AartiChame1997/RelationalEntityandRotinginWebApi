using Microsoft.AspNetCore.Mvc;
using RelationalEntityandRotinginWebApi.Infrastructure;
using RelationalEntityandRotinginWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RelationalEntityandRotinginWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        // GET: api/<BlogController>

        private readonly IPost _post;
        public BlogController(IPost post)
        {
            _post = post;
        }

        [HttpGet]
        [Route("GetAllDetails")]
        public async Task<IActionResult> Get()
        {
            try {
                var res = _post.GetCategories();
                if (res != null)
                {
                    return Ok(res);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetPost/{id}")]
        public async Task<IActionResult> GetbyidAsync(int? postid)
        {
            if (postid == null)
            {
                return BadRequest();
            }

            try
            {
                var post = await _post.GetPost(postid);

                if (post == null)
                {
                    return NotFound();
                }

                return Ok(post);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }




        [HttpGet]
        [Route("GetAllpost")]
        public async Task<IActionResult> Getpost()
        {
            try
            {
                var res = _post.GetPosts();
                if (res != null)
                {
                    return Ok(res);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        // GET api/<BlogController>/5
       

        // POST api/<BlogController>
        [HttpPost]
        [Route("AddPost")]
        public async Task<IActionResult> AddPostData([FromBody] Post post)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    
                    
                    var res = await _post.AddPost(post);
                    if (res>0)
                    {
                        return Ok(res);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch(Exception)
                {
                    return BadRequest();

                }
                 
                
            }
            return BadRequest();
        }

        // PUT api/<BlogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BlogController>/5
        [HttpDelete]
        [Route("deletepost")]
        public IActionResult Delete(int id)
        {

            try
            {
                var res = _post.DeletePost(id);
                if(res>1)
                {
                    return Ok(res);

                }
                else
                {
                    return NotFound();

                }

            }
            catch(Exception)
            {
                return BadRequest();
            }


        }


        [HttpPost]
        [Route("SaveEmployee")]
        public IActionResult SaveEmployee([FromForm] EmployeeRegistration employeeRegistration)
        {
            
                _post.SignupEmp(employeeRegistration);
                return Ok();
            
            //catch (Exception)
            //{
            //    return BadRequest();
            //}
        }
    }
}
