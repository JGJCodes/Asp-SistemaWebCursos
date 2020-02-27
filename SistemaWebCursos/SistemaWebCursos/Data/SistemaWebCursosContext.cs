using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaWebCursos.Models;

namespace SistemaWebCursos.Data
{
    public class SistemaWebCursosContext : DbContext
    {
        public SistemaWebCursosContext (DbContextOptions<SistemaWebCursosContext> options)
            : base(options)
        {
        }

        public DbSet<SistemaWebCursos.Models.Categoria> Categoria { get; set; }
    }
}
