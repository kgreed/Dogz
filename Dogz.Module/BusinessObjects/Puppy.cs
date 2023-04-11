using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.XtraScheduler.Native;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Dogz.Module.BusinessObjects
{
    
    public abstract class Puppy :    MyBaseObject ,INotifyPropertyChanging , INotifyPropertyChanged
    {

        public Puppy()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new ObservableCollection<AssociatedEntityObject>();
        }

        //[Key]
        //public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }
        public virtual int ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual Dog Parent { get; set; }

        public virtual int BreedId { get; set; }

        [NotMapped]
        public virtual DogBreed Breed => (DogBreed)BreedId;

        public abstract event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
    }
}