using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ErrorController(DataContext context): BaseApiController
{
[Authorize]
[HttpGet("auth")]
public ActionResult<string>  GetAuth()
{
return "";
}

[HttpGet("not-found")]
public ActionResult<AppUser>  GetNotFound()
{
    var thing = context.Users.Find(-1);

    if(thing == null) return NotFound();

    return thing;
}

[HttpGet("server-error")]
public ActionResult<AppUser>  GetServerError()
{
    var thing = context.Users.Find(-1) ?? throw new Exception();
    return thing;
}
}
