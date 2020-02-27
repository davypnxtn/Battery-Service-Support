using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class RelatieInstallatieViewModel
    {
        public Relatie Relatie { get; set; }
        public List<Installatie> Installaties { get; set; }
    }
}
