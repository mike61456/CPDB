using CPD.Data;
using CPD.Models.Customer;
using CPD.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPD.Services
{
 
        public class CustomerService
        {
            private readonly Guid _userId;

            public CustomerService(Guid userId)
            {
                _userId = userId;
            }

            public bool CreateCustomer(CreateCustomer model)
            {
                var entity =
                    new Customer()
                    {
                        
                        CustomerID = model.CustomerID,
                        Name = model.Name,
                        Address = model.Address,
                        Telephone = model.Telephone,
                        Email = model.Email,
                        Notes = model.Notes,
                        OwnerId =_userId
                    };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Customer.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
            }
            public IEnumerable<ListCustomer> GetCustomer()
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var query =
                        ctx
                            .Customer
                            .Where(e => e.OwnerId == _userId)
                            .Select(
                                e =>
                                    new ListCustomer
                                    {
                                        CustomerID = e.CustomerID,
                                        Name = e.Name,
                                        OwnerId = e.OwnerId
                                    }
                            );

                    return query.ToArray();
                }
            }
            public DetailCustomer GetCustomerById(int id)
            {
                List<ListProject> listOfProjects = new List<ListProject>();
                using (var ctx = new ApplicationDbContext())
                {

                var entity =
                        ctx
                            .Customer
                            .Single(e => e.CustomerID == id && e.OwnerId == _userId);
                foreach (var project in entity.Projects)
                {
                    var projectToAdd = new ListProject()
                    {
                        Name = project.Name,
                        ProjectID = project.ProjectID,
                        OwnerId = project.OwnerId,
                        CustomerID = project.CustomerID,
                        TypeOfProject = project.TypeOfProject
                    };
                    listOfProjects.Add(projectToAdd);
                }
                return
                        new DetailCustomer
                        {
                            CustomerID = entity.CustomerID,
                            Name = entity.Name,
                            Address = entity.Address,
                            Telephone = entity.Telephone,
                            Email = entity.Email,
                            Notes = entity.Notes,
                            Projects = listOfProjects
                          //  OwnerId = entity.OwnerId
                        };
                }
            }
            public bool UpdateCustomer(EditCustomer model)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Customer
                            .Single(e => e.CustomerID == model.CustomerID && e.OwnerId == _userId);

                    entity.CustomerID = model.CustomerID;
                    entity.Name = model.Name;
                    entity.Address = model.Address;
                    entity.Telephone = model.Telephone;
                    entity.Email = model.Email;
                    entity.Notes = model.Notes;
              //      entity.OwnerId = model.OwnerId;

                return ctx.SaveChanges() == 1;
                }
            }
            public bool DeleteCustomer(int CustomerID)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Customer
                            .Single(e => e.CustomerID == CustomerID && e.OwnerId == _userId);

                    ctx.Customer.Remove(entity);

                    return ctx.SaveChanges() == 1;
                }
            }
        }
    }


