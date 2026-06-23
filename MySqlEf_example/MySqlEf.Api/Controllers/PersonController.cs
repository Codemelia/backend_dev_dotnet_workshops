using System.Runtime.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MySqlEf.Api.Models;
using MySqlEf.Api.DTO;
using MySqlEf.Api.Mapper;

namespace MySqlEf.Api.Controllers;

[Route("api/person")]
[ApiController]
public class PersonController : ControllerBase
{
    
    // Dependency Injection
    private readonly AppDbContext _context;

    public PersonController(AppDbContext context)
    {
        _context = context;
    }

}