using CPD.Data;
using CPD.Models.Customer;
using CPD.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPD.Services
{
    public class ProductService
    {
          
            //private readonly Guid _userId;

            //public ProductService(Guid userId)
            //{
            //    _userId = userId;
            //}

            public bool CreateProduct(CreateProduct model)
            {
                var entity = new Product()
                    {

                        ProductID = model.ProductID,
                        Name = model.Name,
                        Price = model.Price,
                        Description = model.Description,
                        Quantity = model.Quantity,
                        ProjectID = model.ProjectID //needs projectID
                    
                    };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Product.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
            }
            public IEnumerable<ListProduct> GetProduct()
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var query =
                        ctx
                            .Product
                           // .Where(e => e.OwnerId == _userId)
                            .Select(
                                e =>
                                    new ListProduct
                                    {
                                        ProductID = e.ProductID,
                                        Name = e.Name,
                                        Price = e.Price,
                                        
                                    //    OwnerId = e.OwnerId
                                    }
                            );

                    return query.ToArray();
                }
            }
            public DetailProduct GetProductById(int id)
            {
                using (var ctx = new ApplicationDbContext())
                {
                var entity =
                    ctx
                        .Product
                        .Single(e => e.ProductID == id); //&& e.OwnerId == _userId);
                    return
                        new DetailProduct
                        {
                            ProductID = entity.ProductID,
                            Name = entity.Name,
                            Price = entity.Price,
                            Description = entity.Description,
                            Quantity = entity.Quantity,
                            ProjectID = entity.ProjectID,
                            
                           //Pass in the ProjectID tied to it
                           //Display the Name of the Project tied to it
                        
                        };
                }
            }
            public bool UpdateProduct(EditProduct model)
            {
                using (var ctx = new ApplicationDbContext())
                {
                var entity =
                    ctx
                        .Product
                        .Single(e => e.ProductID == model.ProductID); //&& e.OwnerId == _userId);

                    entity.ProductID = model.ProductID;
                    entity.Name = model.Name;
                    entity.Price = model.Price;
                    entity.Description = model.Description;
                    entity.Quantity = model.Quantity;
                //entity.ProjectID = model.ProjectID; // Project ID



                return ctx.SaveChanges() == 1;
                }
            }
            public bool DeleteProduct(int ID)
            {
                using (var ctx = new ApplicationDbContext())
                {
                var entity =
                    ctx
                        .Product
                        .Single(e => e.ProductID == ID); // && e.OwnerId == _userId);

                    ctx.Product.Remove(entity);

                    return ctx.SaveChanges() == 1;
                }
            }
        }
    }

