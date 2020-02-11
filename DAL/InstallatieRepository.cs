﻿using DAL.Data;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class InstallatieRepository : IInstallatieRepository
    {
        private readonly DataContext _context;

        public InstallatieRepository(DataContext context)
        {
            _context = context;
        }

        public List<Installatie> FindByLeveradresId(int id)
        {
            return _context.Installaties.Where(i => i.LeveradresID == id).ToList();
        }
    }
}