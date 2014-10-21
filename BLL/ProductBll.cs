using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductsInformationApp.DLL.DAO;
using ProductsInformationApp.DLL.Gateway;

namespace ProductsInformationApp.BLL
{
    class ProductBll
    {
        ProductGateway aProductGateway = new ProductGateway();

        public string SaveProduct(Product aProduct)
        {
            if (aProduct.Code == string.Empty || aProduct.Name == string.Empty )
            {
                return "Fill up all fields first.";
            }
            if (aProduct.Code.Length > 3 && aProduct.Code.Length < 3)
            {
                return "Need 3 Characters Only";
            }

            if (aProduct.Name.Length < 10 && aProduct.Name.Length > 5)
            {
                return "Need 5 Characters Only";
            }
            if (HasThisCode(aProduct.Code) || HasThisName(aProduct.Name))
            {
                return "Code Or Name already included.";
            }
            return aProductGateway.SaveProduct(aProduct);
        }

        private bool HasThisName(string name)
        {
            return aProductGateway.HasThisName(name);
        }

        private bool HasThisCode(string code)
        {
            return aProductGateway.HasThisCode(code);
        }


        public List<Product> ShowProducts()
        {
            return aProductGateway.ShowProducts();
        }

      
        
        public int GetTotalQuantity()
        {
            List<Product> products = ShowProducts();
            int quantity = 0;
            foreach (var product in products)
            {
                quantity += product.Quantity;
            }
            return quantity;
        }
    }
}
