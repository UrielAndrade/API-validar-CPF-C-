
using ValidarCPF.Routes;

var builder = WebApplication.CreateBuilder(args);
//para ukltilizar o swegger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

//Uma tal de PipeLine pro Swagger
app.UseSwagger();
app.UseSwaggerUI();

//Puxa do arquivo CpfRouts que esta na pasta Routs
app.CpfRoutes();
app.Run();

