using Microsoft.AspNetCore.Mvc;
using ZingGameApi.Data;
using ZingGameApi.Entities;
using System.Collections.Generic;
using System.Linq;
using System;

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
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return _context.Users.ToList();
        }

        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(Guid id)
        {
            return _context.Users.Find(id);
        }
    }
}