using ChapterAPI.Contexts;
using ChapterAPI.Repositories;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.C
builder.Services.AddScoped<ChapterContext, ChapterContext>();  // config servico contexto
builder.Services.AddTransient<LivroRepository, LivroRepository>(); // config servico repository
builder.Services.AddTransient<UsuarioRepository, UsuarioRepository>(); // config servico repository

builder.Services.AddControllers();

builder.Services.AddCors(options => 
    {
        options.AddPolicy("CorsPolicy", builder =>
         {
             builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
         });
    });

// Adicionado servi�o de JWT para autentica��o.
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

// Define os parametros de valida��o do Token.
.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        // Valida quem esta solicitando o acesso. Valida o usu�rio que est� tentando acesso.
        ValidateIssuer = true,
        // Valida quem est� recebendo o acesso. 
        ValidateAudience = true,
        // Define se o tempo de expira��o ser� validado.
        ValidateLifetime = true,
        // Forma de criptografia e ainda valida a chave de autenticacao.
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chapter-chave-autenticacao")),
        // Forma e valor de expira��o do Token.
        ClockSkew = TimeSpan.FromMinutes(10),
        // Nome do Issuer de onde est� vindo.
        ValidIssuer = "ChapterAPI",
        // Nome do Audience para onde est� indo.
        ValidAudience = "ChapterAPI"
    };
});
    
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.UseCors("CorsPolicy");

app.Run();
