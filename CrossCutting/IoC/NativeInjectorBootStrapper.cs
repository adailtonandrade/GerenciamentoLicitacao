using Application.Mapper;
using AutoMapper.Extensions.ExpressionMapping;
using Data;
using Data.Context;
using Data.Repository;
using Domain.Interfaces.Data;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Service;
using Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            #region Universal
            services.AddDbContext<ModelContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region AutoMapper
            services.AddAutoMapper(cfg => { cfg.AddExpressionMapping(); }, typeof(MappingProfile));
            #endregion

            #region Service
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            #endregion

            #region repository
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            #endregion repository
        }
    }
}
