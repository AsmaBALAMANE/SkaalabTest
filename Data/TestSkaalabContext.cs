using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestSkaalab.Models;

namespace TestSkaalab.Data
{
    public class TestSkaalabContext : DbContext
    {
        public TestSkaalabContext (DbContextOptions<TestSkaalabContext> options)
            : base(options)
        {
        }

        public DbSet<TestSkaalab.Models.LearningRessouce> LearningRessouce { get; set; } = default!;
    }
}
