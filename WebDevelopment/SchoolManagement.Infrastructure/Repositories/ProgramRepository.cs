using Microsoft.EntityFrameworkCore;
using SchoolManagement.ApplicationCore.Models;
using SchoolManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class ProgramRepository
    {
        private readonly SchoolContext db;
        public ProgramRepository(SchoolContext db)
        {
            this.db = db;
        }

        public async Task<List<Program>> All() => await db.Programs.ToListAsync();
    }
}
