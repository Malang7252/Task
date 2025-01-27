﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Service.Helper;

namespace Task.API.Controllers
{
    public class BaseController : ControllerBase
    {
        public IActionResult ReturnFormattedResponse<T>(ServiceResponse<T> response)
        {
            if (response.Success)
            {
                return Ok(response);
            }

            return StatusCode(response.StatusCode, response.Errors);
        }
    }
}
