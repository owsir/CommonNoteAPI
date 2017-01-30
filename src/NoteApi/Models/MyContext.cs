using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace NoteApi.Models
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Note> Notes { get; set; } 
    }

    public class SampleData
    {
        public static async Task InitDb(IServiceProvider service)
        {
            var context = service.GetService<MyContext>();

            if (context.Database != null && context.Database.EnsureCreated())
            {
                // Init sample data
                var user = new Note { Subject = "TEST",Content = "TEST-CONTENT",Email = "TEST@TEST.COM",Author = "TEST"};
                context.Add(user);
            }
            await context.SaveChangesAsync();
        }
    }

}
