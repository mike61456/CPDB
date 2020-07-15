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
                var entity =
                    new Product()
                    {

                        ItemID = model.ItemID,
                        Name = model.Name,
                        Price = model.Price,
                        Description = model.Description,
                        Quantity = model.Quantity,
                        
                    //    OwnerId = _userId
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
                                        ItemID = e.ItemID,
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
                        .Single(e => e.ItemID == id); //&& e.OwnerId == _userId);
                    return
                        new DetailProduct
                        {
                            ItemID = entity.ItemID,
                            Name = entity.Name,
                            Price = entity.Price,
                            Description = entity.Description,
                            Quantity = entity.Quantity,
                           
                        //    OwnerId = entity.OwnerId
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
                        .Single(e => e.ItemID == model.ItemID); //&& e.OwnerId == _userId);

                    entity.ItemID = model.ItemID;
                    entity.Name = model.Name;
                    entity.Price = model.Price;
                    entity.Description = model.Description;
                    entity.Quantity = model.Quantity;
                 
                    // entity.OwnerId = model.OwnerId;

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
                        .Single(e => e.ItemID == ID); // && e.OwnerId == _userId);

                    ctx.Product.Remove(entity);

                    return ctx.SaveChanges() == 1;
                }
            }
        }
    }

