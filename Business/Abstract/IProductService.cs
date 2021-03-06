﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetailDtos();
        IDataResult<Product> GetById(int productId);
        IResult Add(Product product); //Data olmadığı için IDataResult demedik sadece IResult dedik
        IResult Update(Product product);

        IResult AddTransactionalTest(Product product);
    }
}
