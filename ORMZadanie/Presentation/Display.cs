using ORMZadanie.Business;
using ORMZadanie.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMZadanie.Presentation
{
    public class Display
    {
        public void Input()
        {
            var operation = -1;
            do
            {
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1: ListAll(); break;
                    case 2: Add(); break;
                    case 3: Update(); break;
                    case 4: Fetch(); break;
                    case 5: Delete(); break;
                    default: break;
                }

            } while (operation != 6);
        }

        public Display()
        {
            Input();
        }

        private void Add() 
        {
            Product product = new Product();
            Console.WriteLine("Enter name");
            product.Name = Console.ReadLine();
            Console.WriteLine("Enter price");
            product.Price=decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter stock");
            product.Stock=int.Parse(Console.ReadLine());
            ProductBusiness.Add(product);
        }

        private void ListAll() 
        {
            List<Product> products = ProductBusiness.GetAll();
            foreach (var item in products)
            {
                Console.WriteLine("{0} {1} {2} {3}",item.ID,item.Name,item.Price,item.Stock);
            }
        }

        private void Update()
        {
            Console.WriteLine("Enter id to update");
            int id = int.Parse(Console.ReadLine());
            Product product = ProductBusiness.Get(id);
            if (product != null)
            {
                Console.WriteLine("Enter name: ");
                product.Name = Console.ReadLine();
                Console.WriteLine("Enter price ");
                product.Price = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter stock ");
                product.Stock = int.Parse(Console.ReadLine());
                ProductBusiness.Update(product);
            }
            else { Console.WriteLine("Product is not found"); }
        }

        private void Fetch()
        {
            Console.WriteLine("Enter id to fetch");
            int id = int.Parse(Console.ReadLine());
            Product product = ProductBusiness.Get(id);
            if (product != null)
            {
                Console.WriteLine("ID " + product.ID);
                Console.WriteLine("Name " + product.Name);
                Console.WriteLine("Price " + product.Price);
                Console.WriteLine("Stock" + product.Stock);
            }
            else { Console.WriteLine("Product is not found"); }
        }

        private void Delete() 
        {
            Console.WriteLine("Enter id to delete");
            int id = int.Parse(Console.ReadLine());
            ProductBusiness.Delete(id);
            Console.WriteLine("Done");
        } 


    }
}
