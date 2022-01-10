﻿using ContosoCrafts.WebSite.Models;

namespace ContosoCrafts.WebSite.Services;

public interface IProductService
{
    IEnumerable<Product> GetProducts();

    void AddRating(string productId, int rating);

}