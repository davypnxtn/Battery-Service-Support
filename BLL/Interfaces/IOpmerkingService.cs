﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IOpmerkingService
    {
        Opmerking FindByInstallatieId(int id);
    }
}