using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    public class BugController : BaseApiController
    {
        private readonly DataContext context;

        public BugController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFound()
        {
            var req = this.context.Products.Find(188122);

            if(req == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok();
        }

        [HttpGet("internalservererror")]
        public ActionResult GetServerError()
        {
            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}