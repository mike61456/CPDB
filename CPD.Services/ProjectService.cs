using CPD.Data;
using CPD.Models.Product;
using CPD.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPD.Services
{
    public class ProjectService
    {
       
        private readonly Guid _userId;

            public ProjectService(Guid userId)
            {
                _userId = userId;
            }

            public bool CreateProject(CreateProject model)
            {
                var entity =
                    new Project()
                    {

                        Name = model.Name,
                        TypeOfProject = model.TypeOfProject,
                        Notes = model.Notes,
                        ProjectCost = model.ProjectCost,
                        ProjectID = model.ProjectID,
                        OwnerId = _userId,
                        CustomerID = model.CustomerID
                    };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Project.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
            }
            public IEnumerable<ListProject> GetProject()
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var query =
                        ctx
                            .Project
                            .Where(e => e.OwnerId == _userId)
                            .Select(
                                e =>
                                    new ListProject
                                    {
                                        Name = e.Name,
                                        ProjectID = e.ProjectID,
                                        CustomerID = e.CustomerID,
                                        OwnerId = e.OwnerId
                                    }
                            );

                    return query.ToArray();
                }
            }
            public DetailProject GetProjectById(int id)
            {
                List<ListProduct> listOfProducts = new List<ListProduct>();
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Project
                            .Single(e => e.ProjectID == id && e.OwnerId == _userId);
                foreach (var product in entity.Products)
                {
                    var productToAdd = new ListProduct()
                    {
                        Name = product.Name,
                        Price = product.Price,
                        ProductID = product.ProductID                  
                    };
                    listOfProducts.Add(productToAdd);
                }
                    return
                        new DetailProject
                        {
                            Name = entity.Name,
                            TypeOfProject = entity.TypeOfProject,
                            Notes = entity.Notes,
                            ProjectCost = entity.ProjectCost,
                            ProjectID = entity.ProjectID,
                            OwnerId = entity.OwnerId,
                            CustomerID = entity.CustomerID,
                            Products = listOfProducts   
                        };
                }
            }
            public bool UpdateProject(EditProject model)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Project
                            .Single(e => e.ProjectID == model.ProjectID && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.TypeOfProject = model.TypeOfProject;
                entity.Notes = model.Notes;
                entity.ProjectID = model.ProjectID;
                entity.OwnerId = model.OwnerId;
                entity.CustomerID = model.CustomerID;

                    return ctx.SaveChanges() == 1;
                }
            }
            public bool DeleteProject(int ProjectID)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Project
                            .Single(e => e.ProjectID == ProjectID && e.OwnerId == _userId);

                    ctx.Project.Remove(entity);

                    return ctx.SaveChanges() == 1;
                }
            }
        }
    }

