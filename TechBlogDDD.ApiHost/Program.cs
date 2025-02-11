using TechBlogDDD.Application;
using TechBlogDDD.Application.Register;
using TechBlogDDD.Data;
using TechBlogDDD.Domain.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



builder.Services.AddAutoMapper(typeof(ApplicationAutoMapper));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly));


#region Dependency Injection

builder.Services.AddScoped<ICategoryRepository,CategoryRepositoryAsync>();
builder.Services.AddScoped<ICommentRepository, CommentRepositoryAsync>();
builder.Services.AddScoped<IPostRepository, PostRepositoryAsync>();
builder.Services.AddScoped<IRoleRepositoryAsync, RoleRepositoryAsync>();
builder.Services.AddScoped<IUserRepository, UserRepositoryAsync>();
builder.Services.AddScoped<IUserRoleRepositoryAsync, UserRoleRepositoryAsync>();

#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
