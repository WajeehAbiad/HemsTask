using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;

namespace HemsTask.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    public class ErrorsController : Controller
    {
        //[HttpGet, HttpPost, HttpPut, HttpDelete]  //We can use this
        [AcceptVerbs("Get", "Post", "Put", "Delete")]   //Or this
        [Route("Error/{StatusCode}")]
        public IActionResult ErrorsHandler(string statusCode)
        {
            return statusCode switch
            {
                "400" => View("~/Views/Shared/Errors/" + statusCode + ".cshtml"),
                "401" => Redirect("/Login"),
                "403" => View("~/Views/Shared/Errors/" + statusCode + ".cshtml"),
                "404" => View("~/Views/Shared/Errors/" + statusCode + ".cshtml"),
                "405" => View("~/Views/Shared/Errors/" + statusCode + ".cshtml"),
                //"500" => View("~/Views/Shared/Errors/"+ StatusCode + ".cshtml"),
                _ => View("~/Views/Shared/Errors/500.cshtml"),
            };
        }
    }
}