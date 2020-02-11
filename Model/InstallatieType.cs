﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class InstallatieType
    {
        public int Id { get; set; }
        public string InstalTypeCode { get; set; }
        public string Naam { get; set; }
        public DateTime ModDatum { get; set; }
        public List<Installatie> Installaties { get; set; }
    }
}
