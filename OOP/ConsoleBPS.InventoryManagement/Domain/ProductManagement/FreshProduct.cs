﻿using ConsoleBPS.InventoryManagement.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBPS.InventoryManagement.Domain.ProductManagement
{
    internal class FreshProduct : Product
    {
        public FreshProduct(int Id, string name, string? description, Price price, UnitType unitType, int maxAmountInStock) 
            : base(Id, name, description, price, unitType, maxAmountInStock)
        {
        }
    }
}