﻿using API.DATA.DbModels;
using Microsoft.EntityFrameworkCore;

namespace API.DATA.DataContext
{
    public class StoreContext : DbContext 
    {
        public StoreContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Product> Products { get; set; }


    }
}
