﻿using Microsoft.EntityFrameworkCore;

namespace ApiGastos.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Gasto> Gastos { get; set; }
    }
}
