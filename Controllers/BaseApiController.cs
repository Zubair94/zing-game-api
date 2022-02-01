using Microsoft.AspNetCore.Mvc;

namespace ZingGameApi.Controllers;

[ApiController]
[Produces("application/json")]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public class BaseApiController
{
    
}

