﻿namespace EsportsProfileWebApi.Web.Controllers;

using EsportsProfileWebApi.Web.Orchestrators;
using EsportsProfileWebApi.Web.Requests.User;
using Microsoft.AspNetCore.Mvc;
using Responses.User;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly IUserOrchestrator _userOrchestrator;

    public UserController(IUserOrchestrator userOrchestrator)
    {
        _userOrchestrator = userOrchestrator ?? throw new NotImplementedException();
    }

    [HttpPost]
    [Route("Register")]
    public async Task<GetUserDataResponse> Register(RegisterRequest request)
    {
        var result = await _userOrchestrator.RegisterUser(request);
        return result;
    }

    //[HttpPost]
    //[Route("Login")]
    //public ActionResult Login(LoginRequest request)
    //{
    //    var tokenHandler = new JwtSecurityTokenHandler();
    //    var key = Encoding.UTF8.GetBytes("SuperDuperSecretValueSuperDuperSecretValue");

    //    // find if the user is valid, if they are create the claims or retrieve them from the db
    //    if (users.Where(x=> x.Username == request.Username && x.password == request.Password).Count().Equals(0))
    //        return new NotFoundResult();
    //    var claims = new List<Claim>()
    //    {
    //        new (ClaimTypes.Role, "Admin"),
    //        new (ClaimTypes.Name, "NADROJ"), // Replace with user claims
    //        new (ClaimTypes.Email, "Jordanhsheldon@gmail.com"),
    //    };

    //    var tokenDescriptor = new SecurityTokenDescriptor()
    //    {
    //        Subject = new ClaimsIdentity(claims),
    //        Expires = DateTime.UtcNow.AddMinutes(30),
    //        Issuer = "https://localhost:5000",
    //        Audience = "https://localhost:5000",
    //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
    //    };

    //    return new JsonResult(new GetUserDataResponse
    //    {
    //        Token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor)),
    //        Id = 1,
    //        Claims = claims
    //    });
    //}
}