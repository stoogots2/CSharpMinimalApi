using Microsoft.AspNetCore.Mvc;

var mine = "Developers";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<DeveloperRepository>();
var app = builder.Build();

//Get
app.MapGet($"/{mine}", ([FromServices] DeveloperRepository repo)=>{ return Results.Ok(repo.GetAllDevelopers()); });
//Get by Id
app.MapGet($"/{mine}/{{id}}", ([FromServices] DeveloperRepository repo, Guid id) => {
    var customer = repo.GetById(id);
    return customer is not null ? Results.Ok(customer):Results.NotFound();
    });
//Add
app.MapPost($"/{mine}/", ([FromServices] DeveloperRepository repo, [FromBody] Developer developer) =>
{
    repo.Create(developer);
    return Results.Created($"/{mine}/{developer.Id}", developer);
});
//Update
app.MapPut($"/{mine}/", ([FromServices] DeveloperRepository repo, Developer developer) =>
{
    repo.Update(developer);
    return Results.NoContent();
});
//Delete
app.MapDelete($"/{mine}/{{id}}", ([FromServices] DeveloperRepository repo, Guid Id) =>
{
    repo.Delete(Id);
    return Results.NoContent();
});

app.Run();

record Developer(Guid Id, string FullName, string Languages);
class DeveloperRepository
{
    private readonly Dictionary<Guid, Developer> _developers = new();

    public void Create(Developer developer)
    {
        if (developer is null)
            return;

        _developers[developer.Id] = developer;
    }

    public void Delete(Guid Id)
    {
        _developers.Remove(Id);
    }

    public void Update(Developer developer)
    {
        _developers[developer.Id] = developer;
    }

    public IEnumerable<Developer> GetAllDevelopers()
    {
        return _developers.Select(t=>t.Value);
    }
    public Developer GetById(Guid id)
    {
        return _developers.Where(t => t.Key == id).Select(t=>t.Value).First();
    }
}

