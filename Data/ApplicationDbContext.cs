using System;
using System.Collections.Generic;
using System.Text;
using Biblioteca.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Biblioteca.Models.Libro> Libro { get; set; }
        public DbSet<Biblioteca.Models.ClienteLibro> ClienteLibro { get; set; }
    }
}
