using Microsoft.AspNetCore.Mvc;
using SanalSatis.API.Errors;
using SanalSatis.Infrastructure.DataAccess;

namespace SanalSatis.API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly ProjectContext _context;
        public BuggyController(ProjectContext context)
        {
            _context = context;

        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _context.Products.Find(42);
            if (thing == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }
        
        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = _context.Products.Find(42);

            var thingToReturn = thing.ToString();
            
            return Ok();
        }
        
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(404));
        }
        
        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}