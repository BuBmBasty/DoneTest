using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notes.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Notes.Application.Interfaces;

namespace Notes.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var collectionString = configuration["DbConnection"];
            services.AddDbContext<NotesDBContext>(options =>
            {
                options.UseSqlite(collectionString);
            });
            services.AddScoped<INotesDBContext>(provider => provider.GetService<NotesDBContext>());
            return services;
        }
    }
}
