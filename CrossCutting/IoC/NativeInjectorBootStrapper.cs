using Application;
using Application.Interfaces;
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
            services.AddDbContext<ModelContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region AutoMapper
            services.AddAutoMapper(cfg => { cfg.AddExpressionMapping(); }, typeof(MappingProfile));
            #endregion

            #region AppService
            services.AddScoped<IBiddingAppService, BiddingAppService>();
            #endregion

            #region Service
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<IBiddingService, BiddingService>();
            #endregion

            #region repository
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IBiddingRepository, BiddingRepository>();
            #endregion repository
        }
    }
}