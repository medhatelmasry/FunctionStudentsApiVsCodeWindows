using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Snoopy.Function {
    public class SchoolContextFactory : IDesignTimeDbContextFactory<SchoolDbContext> {
        public SchoolDbContext CreateDbContext(string[] args) {
            var optionsBuilder = new DbContextOptionsBuilder<SchoolDbContext>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("CSTRING"));

            return new SchoolDbContext(optionsBuilder.Options);
        }
    }
}