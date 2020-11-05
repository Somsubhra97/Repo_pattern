using PostDomain;
using PostDomain.PostsAggregate;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PostRepo
{
    public static class DependencyInjection
        {
            public static IServiceCollection AddRepository(this IServiceCollection services)
            {
                services.AddTransient<IPostsRepository, PostsRepository>();           
                services.AddTransient<IUnitOfWork, UnitOfWork>();
                
                services.AddDbContext<BookStoreDbContext>(opt => opt
                    .UseSqlServer("DESKTOP-17AHND7\SQLEXPRESS; Database=CRUD_MVC; Trusted_Connection=True;"));
                return services;
            }
        }
}

