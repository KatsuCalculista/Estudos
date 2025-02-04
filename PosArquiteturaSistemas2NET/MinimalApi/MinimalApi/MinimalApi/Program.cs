using MinimalApi.Entidade;
using MinimalApi.Interface;
using MinimalApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Endpoint GET
app.MapGet("/buscar-todos-usuarios", (IUsuarioRepository usuarioRepository) =>
{
    return usuarioRepository.ObterTodosUsuarios();
});

//Endpoint GET
app.MapGet("/buscar-usuario/{id}", (int id, IUsuarioRepository usuarioRepository) =>
{
    return usuarioRepository.ObterUsuarioPorId(id);
});

//Endpoint POST
app.MapPost("/usuario", (Usuario usuario, IUsuarioRepository usuarioRepository) =>
{
    usuarioRepository.CadastrarUsuario(usuario);
});

//Endpoint PUT
app.MapPut("/usuario", (Usuario usuario, IUsuarioRepository usuarioRepository) =>
{
    usuarioRepository.AlterarUsuario(usuario);
});

//Endpoint DELETE
app.MapDelete("/usuario/{id}", (int id, IUsuarioRepository usuarioRepository) =>
{
    usuarioRepository.DeletarUsuario(id);
});
app.Run();
