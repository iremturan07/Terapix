﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terapix.CORE.UnitOfWorks;

namespace Terapix.REPOSİTORY.UnitOfWorks
{
    public class UnitOfWorks(AppDbContext context) : IUnitOfWorks
    {
        private readonly AppDbContext _context=context;
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
