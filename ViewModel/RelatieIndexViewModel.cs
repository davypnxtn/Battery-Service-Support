using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    // Viewmodel voor Index view van Relatiecontroller
    public class RelatieIndexViewModel
    {
        public List<Relatie> Relaties { get; set; }
        public string NaamSearch { get; set; }
        public string AdresSearch { get; set; }
    }
}
