using System;
using System.Linq;
using Suteki.Common.Repositories;
using Suteki.Common.Services;

namespace Suteki.Shop.Services
{
    public class ProductCopyService : IProductCopyService
    {
        readonly IOrderableService<Product> productOrder;
        readonly IRepository<Product> productRepository;

        public ProductCopyService(IOrderableService<Product> productOrder, IRepository<Product> productRepository)
        {
            this.productOrder = productOrder;
            this.productRepository = productRepository;
        }

        public Product Copy(Product originalProduct)
        {
            if (originalProduct == null)
            {
                throw new ArgumentNullException("originalProduct");
            }

            var copiedProduct = new Product
            {
                Name = GetCopyName(originalProduct),
                Description = originalProduct.Description,
                Price = originalProduct.Price,
                Weight = originalProduct.Weight,
                IsActive = false
            };

            ApplyCategories(originalProduct, copiedProduct);
            SetPosition(copiedProduct);
            CopySizes(originalProduct, copiedProduct);

            return copiedProduct;
        }

        static void CopySizes(Product originalProduct, Product copiedProduct)
        {
            foreach (var size in originalProduct.Sizes)
            {
                copiedProduct.AddSize(new Size
                {
                    Name = size.Name,
                    IsActive = size.IsActive,
                    IsInStock = size.IsInStock
                });
            }
        }

        void SetPosition(Product copiedProduct)
        {
            copiedProduct.Position = productOrder.NextPosition;
        }

        static void ApplyCategories(Product originalProduct, Product copiedProduct)
        {
            foreach (var productCategory in originalProduct.ProductCategories)
            {
                copiedProduct.AddCategory(productCategory.Category);
            }
        }

        string GetCopyName(Product originalProduct)
        {
            var nameCandidate = originalProduct.Name + " Copy";
            return CheckNameCandidate(nameCandidate);
        }

        string CheckNameCandidate(string nameCandidate)
        {
            var candidateAlreadyExists = productRepository.GetAll().Any(p => p.Name == nameCandidate);
            if (candidateAlreadyExists)
            {
                return CheckNameCandidate(nameCandidate + "*");
            }
            return nameCandidate;
        }
    }
}