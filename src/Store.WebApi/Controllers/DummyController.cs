﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Store.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("Dummy")]
    public class DummyController : ControllerBase
    {
        public IActionResult GetDummies()
        {
            return Ok(new string[]
            {
                "Hello",
                "Dummies"
            });
        }
    }
}