using Microsoft.AspNetCore.Mvc;

namespace OrderTest.API.Controllers.Abstraction;

/// <summary>
/// Базовый контроллер
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase { }