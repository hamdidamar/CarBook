using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Handlers.ColorHandlers;
using CarBook.Application.Features.CQRS.Handlers.FuelHandlers;
using CarBook.Application.Features.CQRS.Handlers.ModelHandlers;
using CarBook.Application.Features.CQRS.Handlers.TransmissionHandlers;
using CarBook.Application.Interfaces;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<CarBookContext>();
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));

builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();

builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();

builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();

builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();

builder.Services.AddScoped<GetColorQueryHandler>();
builder.Services.AddScoped<GetColorByIdQueryHandler>();
builder.Services.AddScoped<CreateColorCommandHandler>();
builder.Services.AddScoped<UpdateColorCommandHandler>();
builder.Services.AddScoped<RemoveColorCommandHandler>();

builder.Services.AddScoped<GetModelQueryHandler>();
builder.Services.AddScoped<GetModelByIdQueryHandler>();
builder.Services.AddScoped<CreateModelCommandHandler>();
builder.Services.AddScoped<UpdateModelCommandHandler>();
builder.Services.AddScoped<RemoveModelCommandHandler>();

builder.Services.AddScoped<GetFuelQueryHandler>();
builder.Services.AddScoped<GetFuelByIdQueryHandler>();
builder.Services.AddScoped<CreateFuelCommandHandler>();
builder.Services.AddScoped<UpdateFuelCommandHandler>();
builder.Services.AddScoped<RemoveFuelCommandHandler>();

builder.Services.AddScoped<GetTransmissionQueryHandler>();
builder.Services.AddScoped<GetTransmissionByIdQueryHandler>();
builder.Services.AddScoped<CreateTransmissionCommandHandler>();
builder.Services.AddScoped<UpdateTransmissionCommandHandler>();
builder.Services.AddScoped<RemoveTransmissionCommandHandler>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
