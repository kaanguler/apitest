﻿using API.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.Interface
{
    public interface IGenericRepository<T> where T:BaseEntity
    {

        Task<T> GetByIdAsync(int Id);
        Task<IReadOnlyList<T>> ListAllAsync();


    }
}
