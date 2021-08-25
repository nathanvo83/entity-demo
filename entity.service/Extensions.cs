using entity.data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using entity.service.Implementations;
using AutoMapper.Extensions.ExpressionMapping;

namespace entity.service
{
    public static class Extensions
    {
        public static IServiceCollection AddTodoDbContext(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<tododbContext>(opts =>
            {
                opts.UseSqlServer(connectionString, sql =>
                {
                    sql.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                });
                opts.ConfigureWarnings(w =>
                {
                    w.Throw(RelationalEventId.MultipleCollectionIncludeWarning);
                    w.Ignore(CoreEventId.RowLimitingOperationWithoutOrderByWarning);
                });
            });
        }

        public static IServiceCollection AddTodoServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IJobService, JobService>();
            return services;
        }

        public static IServiceCollection AddTodoServiceModelMappings(this IServiceCollection services)
        {
            return services.AddAutoMapper(x =>
            {
                x.AddExpressionMapping();
            },
                typeof(Extensions).Assembly
            );
        }
    }
}
