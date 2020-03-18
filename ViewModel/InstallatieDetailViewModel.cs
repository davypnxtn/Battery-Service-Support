using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class InstallatieDetailViewModel
    {
        public Installatie Installatie { get; set; }
        public List<Batterij> Batterijen { get; set; }
    }
}
