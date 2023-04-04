using ORMZadanie.Data;
using ORMZadanie.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMZadanie.Business
{
    public static class ProductBusiness
    {
        private static ProductContext productContext;

        public static List<Product> GetAll()
        {
            using (productContext = new ProductContext())
            {
                return productContext.Products.ToList();
            }
        }

        public static Product Get(int id)
        {
            using (productContext = new ProductContext()) { return productContext.Products.Find(id); }
        }

        public static void Add(Product product)
        {
            using(productContext = new ProductContext()) 
            { 
                productContext.Products.Add(product);
                productContext.SaveChanges();
            }
        }

        public static void Update(Product product)
        {
            using (productContext = new ProductContext()) 
            {
                var item = productContext.Products.Find(product.ID);
                if (item != null) 
                {
                    productContext.Entry(item).CurrentValues.SetValues(product);
                    productContext.SaveChanges();
                }
            }
        }

        public static void Delete(int id) 
        {
            using (productContext = new ProductContext()) 
            {
                var product = productContext.Products.Find(id);
                if (product != null) 
                {
                    productContext.Products.Remove(product);
                    productContext.SaveChanges();
                }
            }
        }
    }
}
