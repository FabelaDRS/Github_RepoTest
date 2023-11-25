using FabelaExam.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabelaExam.Business.DataContext
{
    public class ExamDbContext : DbContext
    {
        public ExamDbContext(DbContextOptions<ExamDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        {
            optionsBuilder.Entity<User>(entity => { entity.ToTable("tbl_User", "SecurityApp");  });
            optionsBuilder.Entity<AuthorizerUser>(entity => { entity.ToTable("tbl_AuthorizerUser", "SecurityApp"); });
            base.OnModelCreating(optionsBuilder);            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<AuthorizerUser> AuthorizerUsers { get; set; }
    }
}
