using myShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace myShop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<productCategory> productCategories;

        public ProductCategoryRepository()
        {
            productCategories = cache["productCategories"] as List<productCategory>;
            if (productCategories == null)
            {
                productCategories = new List<productCategory>();
            }
        }

        public void Commit()
        {
            cache["productCategories"] = productCategories;
        }

        public void Insert(productCategory p)
        {
            productCategories.Add(p);
        }

        public void Update(productCategory ProductCategory)
        {
            productCategory productCategoryToUpdate = productCategories.Find(p => p.Id == ProductCategory.Id);

            if (productCategoryToUpdate != null)
            { 
                productCategoryToUpdate = ProductCategory;
            }
            else
            {
                throw new Exception("Product category not found");
            }
        }

        public productCategory Find(string Id)
        {
            productCategory ProductCategory = productCategories.Find(p => p.Id == Id);
            if (ProductCategory != null)
            {
                return ProductCategory;
            }
            else
            {
                throw new Exception("product category not found");
            }
        }

        public IQueryable<productCategory> Collection()
        {
            return productCategories.AsQueryable();
        }

        public void Delete(string Id)
        {
            productCategory productCategoryToDelete = productCategories.Find(p => p.Id == Id);

            if (productCategoryToDelete != null)
            {
                productCategories.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
    }
}
