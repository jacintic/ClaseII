using Microsoft.AspNetCore.Mvc;

namespace ASPNET2.Controllers;

[ApiController]
[Route("api/authors")]
public class AuthorController
{
    private IAuthorRepository AuthRepo;

    public AuthorController(IAuthorRepository authRepository)
    {
        AuthRepo = authRepository;
    }

    // API Methods
    // https://localhost:7230/api/authros/1
    [HttpGet("{id}")]
    public Author FindById(int id)
    {
        return AuthRepo.FindById(id);
    }


    // https://localhost:7230/api/authros/findall
    [HttpGet]
    public List<Author> FindAll()
    {
        return AuthRepo.FindAll();
    }

    // https://localhost:7230/api/authros/email
    [HttpGet("email/{email}")]
    public Author FindByEmails(string email)
    {
        return AuthRepo.FindByEmail(email);
    }

    // https://localhost:7230/api/authros/nickname/id
    [HttpGet("nickname/{id}")]
    public string FindNickname(int id)
    {
        return AuthRepo.FindNickName(id);
    }

    // https://localhost:7230/api/authros/salgt/min
    [HttpGet("salgt/{min}")]
    public List<Author> FindSalGreaterThan(double min)
    {
        return AuthRepo.FindSalGreaterThan((decimal)min);
    }

    // delete
    // https://localhost:7230/api/authros/salary/min/max
    [HttpGet("salary/min/{min}/max/{max}")]
    public List<Author> FindBySalRange(double min, double max)
    {
        return AuthRepo.FindBySalRange(min, max);
    }


    // https://localhost:7230/api/authros
    [HttpPost]
    public Author Create(Author author)
    {
        return AuthRepo.Create(author);
    }

    // update
    // https://localhost:7230/api/authros
    [HttpPut]
    public Author Update(Author author)
    {
        return AuthRepo.Update(author);
    }

    // delete
    // https://localhost:7230/api/authros/1
    [HttpDelete("{id}")]
    public void DeleteById(int id)
    {
        AuthRepo.Remove(id);

    }
}
