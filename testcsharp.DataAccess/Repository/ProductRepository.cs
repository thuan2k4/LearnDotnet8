﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testcsharp.DataAccess.Data;
using testcsharp.DataAccess.Repository.IRepository;
using testcsharp.Models;

namespace testcsharp.DataAccess.Repository
{
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}
