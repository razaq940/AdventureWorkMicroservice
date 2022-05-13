﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.Contracts.Interface;

namespace Sales.Contracts
{
    public interface IRepositoryManager
    {
        ICustomerRepository Customers { get; }

        public void Save();
        Task SaveAsync();
    }
}