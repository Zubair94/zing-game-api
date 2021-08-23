using Microsoft.AspNetCore.Mvc;
using ZingGameApi.Data;
using ZingGameApi.Entities.User;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ZingGameApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}