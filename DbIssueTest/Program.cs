using System;
using Microsoft.EntityFrameworkCore;

namespace DbIssueTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var dbc = new TdbContext())
            {
                dbc.Database.EnsureDeleted();
                dbc.Database.EnsureCreated();
                
                var entity = new Parent {Name = "Bob", Dob = new DateTime(2000, 1, 1)};
                dbc.Parents.Add(entity);
                dbc.SaveChanges();

                var bob = dbc.Parents.Find(entity.Id);
                var child1 = new Child
                {
                    Name = "Sonny",
                    Dob = new DateTime(2010, 1, 1),
                    Parent1 = bob
                };
                bob.Children.Add(child1);

                var child2 = new Child
                {
                    Name = "Daughtery",
                    Dob = new DateTime(2010, 1, 1),
                    Parent1 = bob
                };
                bob.Children.Add(child2);

                dbc.Entry(child1).State = EntityState.Added;
                dbc.Entry(child2).State = EntityState.Added;

                dbc.SaveChanges();
            }
        }
    }
}
