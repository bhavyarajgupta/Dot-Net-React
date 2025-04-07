using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController :BaseApiController
    {
        [HttpGet("not-found")]
        public ActionResult GetNotFound(){
            return NotFound();
        }
    
        [HttpGet("bad-request")]
        public ActionResult GetBadRequest(){
            return BadRequest(new ProblemDetails{Title="This is a bad request"});
        }
    
        [HttpGet("unauthorised")]
        public ActionResult GetUnauthorised(){
            return Unauthorized();
        }
    
        [HttpGet("validation-error")]
        public ActionResult GetValidationError(){
            //Modelstate is a property of the controller that holds the validation errors
            
            ModelState.AddModelError("Problem 1" , "This is a problem");
            ModelState.AddModelError("Problem 2" , "This is a problem2");
            return ValidationProblem();  
        }
        [HttpGet("server-error")]
        public ActionResult GetServerError(){
            throw new Exception("This is a server error");
        }
        
    }
}