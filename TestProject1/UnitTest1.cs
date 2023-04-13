using Dogz.Module;
using Dogz.Module.BusinessObjects;
using System.Configuration;
using System.Configuration.Provider;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //var connectionStringSettings = ConfigurationManager.ConnectionStrings;


            //var connectionString = connectionStringSettings["ConnectionString"].ConnectionString;
            var connectionString = "Integrated Security=SSPI;MultipleActiveResultSets=True;Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Dogz5";


            var db = Helpers.MakeDbContextWithConnectionString(connectionString);

            var pug = db.Dogs.FirstOrDefault(x=>x.BreedId == (int)DogBreed.Pug);

            var puppy = new PugPup
            {
                Name = $"Bert {DateTime.Now}"
            } as Puppy;

            var topDog = db.Dogs.SingleOrDefault(x => x.Name == "Fred");
            var parentPug = db.Dogs.Find(pug.Id); //works


            puppy.Parent = parentPug;
            puppy.ParentID = parentPug.Id;
            db.Puppies.Add(puppy);
            db.SaveChanges();


            //var dog = pug as Dog;
            //puppy.Parent = dog;
            //dog.Puppies.Add(puppy);
            //db.Puppies.Add(puppy);
            ////System.InvalidOperationException: 'The entity type 'PugPup' is configured to use the 'ChangingAndChangedNotificationsWithOriginalValues' change tracking strategy, but does not implement the required 'INotifyPropertyChanging' interface. Implement 
            //// If I make the keys a guid I get duplicate key errors
            //// If I have keys as an int I get SqlException: Cannot insert explicit value for identity column in table 'Dogs' when IDENTITY_INSERT is set to OFF.

            //db.SaveChanges();

            var puppyCount = db.Puppies.Count();
           // MessageBox.Show($"There are {puppyCount} puppies");
            //MessageBox.Show("PugPup added");
        }
    }
}