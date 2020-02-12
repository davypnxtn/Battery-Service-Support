﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IArtikelRepository
    {
        List<Artikel> GetArtikels();
        Artikel FindById(int id);
        Artikel FindByXjoArtikelId(int id);
    }
}
