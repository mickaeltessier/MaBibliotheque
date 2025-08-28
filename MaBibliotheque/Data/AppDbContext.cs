using MaBibliotheque.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Data.Common;

namespace MaBibliotheque.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=app.db").LogTo(Console.WriteLine, LogLevel.Information);
            options.AddInterceptors(new ForeignKeyEnforcer());
        }

        public class ForeignKeyEnforcer : DbCommandInterceptor
        {
            public override InterceptionResult<DbDataReader> ReaderExecuting(
                DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
            {
                command.CommandText = "PRAGMA foreign_keys=ON;" + command.CommandText;
                return base.ReaderExecuting(command, eventData, result);
            }
        }

    }
}