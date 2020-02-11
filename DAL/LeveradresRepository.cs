﻿using DAL.Data;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class LeveradresRepository : ILeveradresRepository
    {
        private readonly DataContext _context;

        public LeveradresRepository(DataContext context)
        {
            _context = context;
        }

        public Leveradres FindByAdres(string adres)
        {
            return _context.Leveradressen.Where(l => l.Adres == adres).Single();
        }

        public List<Leveradres> FindByKlantId(int id)
        {
            return _context.Leveradressen.Where(l => l.RelatieId == id).ToList();
        }
    }
}