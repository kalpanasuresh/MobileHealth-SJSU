using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

using DoFactory.BusinessLayer.BusinessObjects;
using DoFactory.DataLayer.DataObjects;
using DoFactory.BusinessLayer.Facade.Utilities;

namespace DoFactory.BusinessLayer.Facade
{
    /// <summary>
    /// Facade (also called Service Layer) that controls all access to Catalog, 
    /// Product, and Product Search related activities.  Note that the Shopping
    /// Cart activities are handled in the Presentation layer (i.e. code behind)
    /// and do not access the Facade. If you had a persistent Shopping Cart 
    /// then this Facade would need to accomodate that. 
    /// 
    /// Gof Design Patterns: Facade.
    /// Enterprise Design Patterns: Remote Facade, Service Layer, Transaction Script.
    /// </summary>
    /// <remarks>
    /// This Facade is not secure. In most applications each method in the 
    /// Facade should check for access security. This can be accomplished  
    /// either programmatically or declaratively (using Attributes).In addition,
    /// validation of arguments should also be added in each procedure.
    /// 
    /// The DataObject and DataObjectMethod Attributes in this class tell the 
    /// Visual Studio 2005 Wizards which classes and methods are 
    /// appropriate for building the ObjectDataSource Web controls.
    /// 
    /// The Remote Facade Design Pattern provides a course-grained facade on a 
    /// fine-grained objects. Indeed the methods are course-grained as they 
    /// deal with complete entities and/or entity lists rather than their individual 
    /// attributes.
    /// 
    /// The Service Layer Design Pattern is the same as the Facade Design Pattern 
    /// except that Service Layer is more specific to Enterprise Business Applications 
    /// in that the layer sits on top of the Domain Model (which is the case here).
    /// 
    /// The Transaction Script Design Pattern organizes business logic by procedures
    /// where each procedure handles a single request from the presentation.  This is 
    /// exactly how the Facade API has been modeled. They entirely handle individual
    /// requests (either from Web Application or Web Service).
    /// </remarks>
    [DataObject(true)]
    public class ProductFacade
    {
        private IProductDao productDao = DataAccess.ProductDao;

        /// <summary>
        /// Gets a list of product categories.
        /// </summary>
        /// <returns>Category list.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<Category> GetCategories()
        {
            // TODO: add access security here..

            return productDao.GetCategories();
        }

        /// <summary>
        /// Gets a list of products for a given category.
        /// </summary>
        /// <param name="categoryId">Unique category identifier.</param>
        /// <returns>Product list.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<Product> GetProductsByCategory(int categoryId)
        {
            // TODO: add access security here..
            // TODO: add argument validation here..

            return productDao.GetProductsByCategory(categoryId,null);
        }

        /// <summary>
        /// Gets a sorted list of products for a given category.
        /// </summary>
        /// <param name="categoryId">Unique category Identifier.</param>
        /// <param name="sortExpression">Sort expression.</param>
        /// <returns>Sorted list of products.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<Product> GetProductsByCategory(int categoryId, string sortExpression)
        {
            // TODO: add access security here..
            // TODO: add argument validation here..

            return productDao.GetProductsByCategory(categoryId, sortExpression);
        }

        /// <summary>
        /// Gets product details.
        /// </summary>
        /// <param name="productId">Unique product identifier.</param>
        /// <returns>Product</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public Product GetProduct(int productId)
        {
            // TODO: add access security here..
            // TODO: add argument validation here..

            Product product = productDao.GetProduct(productId);
            product.Category = productDao.GetCategoryByProduct(productId);
            
            return product;
        }

        /// <summary>
        /// Gets a list of predefined price ranges.
        /// </summary>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<PriceRangeItem> GetProductPriceRange()
        {
            return PriceRange.List;
        }

        /// <summary>
        /// Search for products given certain criteria.
        /// </summary>
        /// <param name="productName">Product name criterium.</param>
        /// <param name="priceRangeId">Price range criterium.</param>
        /// <param name="sortExpression">Sort order of product list.</param>
        /// <returns>Product list that meets the criteria.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<Product> SearchProducts(string productName, int priceRangeId, string sortExpression)
        {
            // TODO: add access security here..
            // TODO: add argument validation here..

            double? priceFrom = null;
            double? priceThru = null;
            if (priceRangeId > 0)
            {
                PriceRangeItem pri = PriceRange.List[priceRangeId];
                priceFrom = pri.RangeFrom;
                priceThru = pri.RangeThru;
            }

            return productDao.SearchProducts(productName, priceFrom, priceThru, sortExpression);
        }
    }
}
