using Model;
using System.Collections.Generic;

namespace ViewModel
{
    public class InstallatieDetailViewModel
    {
        public Installatie Installatie { get; set; }
        public List<Batterij> Batterijen { get; set; }
    }
}
