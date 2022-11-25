using Microsoft.AspNetCore.Mvc;

namespace ASPNET2.Controllers;

[ApiController]
[Route("api/authors")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authServ;
    private readonly ILogger<AuthorController> _logger;

    public AuthorController(IAuthorService authServ, ILogger<AuthorController> logger)
    {
        _authServ = authServ;
        _logger = logger;
    }

    // API Methods
    // https://localhost:7230/api/authros/1
    [HttpGet("{id}")]
    public IActionResult FindById(int id)
    {
        try
        {
            return Ok(_authServ.FindById(id));
        }
        catch (Exception e)
        {
            _logger.LogWarning("Author not found: {e}", e);
        }
        return NotFound();
    }

    [HttpGet("include/{id}")]
    public IActionResult FindByIdWithInclude(int id)
    {
        try
        {
            return Ok(_authServ.FindByIdWithInclude(id));
        }
        catch (Exception e)
        {
            _logger.LogWarning("Author not found: {e}", e);
        }
        return NotFound();
    }


    // https://localhost:7230/api/authros/findall
    [HttpGet]
    public List<Author> FindAll()
    {
        return _authServ.FindAll();
    }

    // https://localhost:7230/api/authros/email
    [HttpGet("email/{email}")]
    public Author FindByEmails(string email)
    {
        return _authServ.FindByEmail(email);
    }

    // https://localhost:7230/api/authros/nickname/id
    [HttpGet("nickname/{id}")]
    public string FindNickname(int id)
    {
        return _authServ.FindNickName(id);
    }

    // https://localhost:7230/api/authros/salgt/min
    [HttpGet("salgt/{min}")]
    public List<Author> FindSalGreaterThan(double min)
    {
        return _authServ.FindSalGreaterThan((decimal)min);
    }

    // delete
    // https://localhost:7230/api/authros/salary/min/max
    [HttpGet("salary/min/{min}/max/{max}")]
    public List<Author> FindBySalRange(double min, double max)
    {
        return _authServ.FindBySalRange(min, max);
    }


    // https://localhost:7230/api/authros
    [HttpPost]
    public IActionResult Create(Author author)
    {
        
        try
        {
            Author createdAuthor = _authServ.Create(author);
            return Created($"/api/authors/{createdAuthor.Id}", createdAuthor);
        }
        catch (Exception e)
        {
            _logger.LogError("Author can't be created. {e}", e);
        }
        return BadRequest();
    }

    // update
    // https://localhost:7230/api/authros
    [HttpPut]
    public IActionResult Update(Author author)
    {
        try
        {
            return Ok(_authServ.Update(author));
        }
        catch (Exception e)
        {
            _logger.LogError("Author couldn't be updated. {e}", e);
            return UnprocessableEntity();
        }
        //return Problem();
        //return BadRequest();
    }

    // delete
    // https://localhost:7230/api/authros/1
    [HttpDelete("{id}")]
    public IActionResult DeleteById(int id)
    {
        
        try
        {
            if (_authServ.Remove(id))
                return NoContent();
        }
        catch (EntityNotFoundException e)
        {
            _logger.LogError("{}", e);
            return NotFound();
        }
        catch (Exception e)
        {
            _logger.LogError("{}", e);
            return Problem();
        }
        return NotFound();
    }
}
