using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]        
     //we can be writing for api/catalg , api/loginuser etc but writting as api/[Controller] we can specify this for any route 
    public class BaseApiController : ControllerBase{

    }
}