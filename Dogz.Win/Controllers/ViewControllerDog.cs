using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Utils.Filtering.Internal;
using DevExpress.XtraSpreadsheet.Commands;
using Dogz.Module;
using Dogz.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dogz.Win.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ViewControllerDog : ViewController
    {
        SimpleAction actTestOS;
        SimpleAction actTest;
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public ViewControllerDog()
        {
            InitializeComponent();
            TargetObjectType = typeof(Dogz.Module.BusinessObjects.Dog);
            actTest = new SimpleAction(this, "TestDb", "View");
            actTest.Execute += actTest_Execute;
            actTestOS = new SimpleAction(this, "TestOS", "View");
            actTestOS.Execute += actTestOS_Execute;
            

            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        private void actTestOS_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var d = View.CurrentObject as Dog;

            var pug = d as Pug;
            if (pug is null)
            {
                MessageBox.Show("Opps we need a Pug selected");
                return;

            }

            var os = Application.CreateObjectSpace(typeof(Dog));
            var puppy = os.CreateObject<PugPup>() as Puppy;
            var dog = pug as Dog;
            puppy.Parent = dog;
            dog.Puppies.Add(puppy);
            //pugPup.Parent = pug;
            //pugPup.BreedId = (int)DogBreed.Pug;
            //pugPup.Name = $"Bert {DateTime.Now}";
            //pug.PugPups.Add(pugPup);

            os.CommitChanges();

            //Unable to cast object of type 'Castle.Proxies.PugPupProxy' to type 'Dogz.Module.BusinessObjects.DalmationPup'.
        }
        private void actTest_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112737/).

             
            var d = View.CurrentObject as Dog;

            var pug = d as Pug;
            if (pug is null) {
                MessageBox.Show("Opps we need a Pug selected");
                return;
            
            }
            var db = Helpers.MakeDbContext();
 

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
            MessageBox.Show($"There are {puppyCount} puppies");
            //MessageBox.Show("PugPup added");


        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
