﻿using CrazyElephant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyElephant.Service
{
    public interface IXmlDataService
    {
        List<Dish> GetAllDishes();

    }
}