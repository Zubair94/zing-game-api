using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZingGameApi.Data;
using ZingGameApi.Entities.User;

namespace ZingGameApi.Controllers;

public class UsersController : BaseApiController
{
    private readonly DataContext _context;
    public UsersController(DataContext context)
    {
        _context = context;
    }

    [MapToApiVersion("1.0")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserEntity>>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }
        
    [MapToApiVersion("2.0")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserEntity>>> GetUsersV2()
    {
        return await _context.Users.ToListAsync();
    }

    [MapToApiVersion("1.0")]
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserEntity>> GetUser(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }
}