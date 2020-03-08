﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace BLL.Interfaces
{
    public interface IBatterijService
    {
        List<Batterij> FindByInstallatieId(int id);
        Batterij FindById(int id);
        BatterijDetailViewModel CreateBatterijDetailViewModel(int id);
    }
}
