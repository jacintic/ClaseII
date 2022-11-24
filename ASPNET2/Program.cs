var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

// CORS
builder.Services.AddCors(options => {
    /*    options.AddPolicy("AllowAll", builder => {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();

        });*/
    options.AddPolicy(name: "angular", policy =>
    {
        policy.WithOrigins("http://localhost:4200", "http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Other services

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MYSQL connection
// create MySQL DB setting
string url = "server=localhost;port=3306;user=root;password=admin;database=aspnet";
builder.Services.AddDbContext<AppDbContext>
    (
        options => options.UseMySql(url, ServerVersion.AutoDetect(url))
    );

// Add repos
builder.Services.AddScoped<IAddressRepository, AddressDbRepository>();
builder.Services.AddScoped<IBookRepository, BookDbRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryDbRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorDbRepository>();

// Add services
builder.Services.AddScoped<IBookService, BookService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// CORS
app.UseCors("angular");

app.UseAuthorization();

app.MapControllers();

app.Run();
