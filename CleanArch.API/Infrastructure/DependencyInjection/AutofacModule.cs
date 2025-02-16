using Autofac;
using CleanArch.API.Application.Commands.CafeCommands;
using CleanArch.API.Application.Queries.CafeQueries;
using CleanArch.API.Application.Queries.EmployeeQueries;
using CleanArch.API.Domain.DTOs;
using CleanArch.API.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


public class AutofacModule : Module
{
    private readonly IConfiguration _configuration;

    // Constructor accepting IConfiguration to get the connection string
    public AutofacModule(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    protected override void Load(ContainerBuilder builder)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        // Register ApplicationDbContext with Autofac
        builder.Register(c =>
            new ApplicationDbContext(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer(connectionString)
                    .Options))
            .AsSelf() // Register the DbContext as itself
            .InstancePerLifetimeScope(); // Ensure it lives per HTTP request
                                         // Register the MediatR services
        builder.RegisterType<CafeRepository>().As<ICafeRepository>().InstancePerLifetimeScope();
        builder.RegisterType<GetCafesQueryHandler>().As<IRequestHandler<GetCafesQuery, List<CafeDTO>>>().InstancePerLifetimeScope();
        builder.RegisterType<GetAllCafesQueryHandler>().As<IRequestHandler<GetAllCafesQuery, List<CafeDTO>>>().InstancePerLifetimeScope();
        builder.RegisterType<CreateCafeQueryHandler>().As<IRequestHandler<CreateCafeQuery, Guid>>().InstancePerLifetimeScope();
        builder.RegisterType<UpdateCafeQueryHandler>().As<IRequestHandler<UpdateCafeQuery, bool>>().InstancePerLifetimeScope();
        builder.RegisterType<DeleteCafeQueryHandler>().As<IRequestHandler<DeleteCafeQuery, bool>>().InstancePerLifetimeScope();

        builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>().InstancePerLifetimeScope();
        builder.RegisterType<GetEmployeesQueryHandler>().As<IRequestHandler<GetEmployeesQuery, List<EmployeeDTO>>>().InstancePerLifetimeScope();
        builder.RegisterType<CreateEmployeeQueryHandler>().As<IRequestHandler<CreateEmployeeQuery, string>>().InstancePerLifetimeScope();
        builder.RegisterType<DeleteEmployeeQueryHandler>().As<IRequestHandler<DeleteEmployeeQuery, bool>>().InstancePerLifetimeScope();
        builder.RegisterType<UpdateEmployeeQueryHandler>().As<IRequestHandler<UpdateEmployeeQuery, bool>>().InstancePerLifetimeScope();
        builder.RegisterType<GetAllEmployeeQueryHandler>().As<IRequestHandler<GetAllEmployeeQuery, List<EmployeeDTO>>>().InstancePerLifetimeScope();

        

    }
}
