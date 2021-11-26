﻿using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        public DataContext Context { get; }
        public BuggyController(DataContext context)
        {
            Context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var thing = Context.Users.Find(-1);
            if(thing == null)
            {
                return NotFound("Not found");
            }

            return Ok(thing);
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var thing = Context.Users.Find(-1);

            var thingToReturn = thing.ToString();

            return thingToReturn;
          
          
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was not correct request");
        }

      




    }
}