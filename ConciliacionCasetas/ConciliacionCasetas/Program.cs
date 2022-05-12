using Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ConciliacionCasetasContext>(o => o.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"], x => x.UseNetTopologySuite()));
builder.Services.AddScoped<IConciliacionCasetasRepository, ConciliacionCasetasRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(cfg =>
{
    cfg.AddPolicy("AllowAll",
       bldr =>
       bldr
          .AllowAnyOrigin().WithExposedHeaders("EmpresaId")
          .AllowAnyHeader()
          .AllowAnyMethod());
});

var audience = builder.Configuration["Audience"];
var validIssuer = builder.Configuration["ValidIssuer"];
var authority = builder.Configuration["Authority"];
builder.Services.AddSingleton<GeometryFactory>(NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326));

builder.Services.AddAuthentication(sharedoptions =>
{
    sharedoptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
           .AddJwtBearer(options =>
           {
               options.Authority = authority;
               options.Audience = audience;

               options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
               {
                   ValidateAudience = true,
                   ValidIssuers = new List<string> { validIssuer }
               };

           });

var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
