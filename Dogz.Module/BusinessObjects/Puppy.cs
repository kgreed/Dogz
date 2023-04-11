using DevExpress.Persistent.Base;
using DevExpress.XtraScheduler.Native;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Dogz.Module.BusinessObjects
{
    
    public abstract class Puppy
    {

        public Puppy()
        {
            // In the constructor, initialize collection properties, e.g.: 
            // this.AssociatedEntities = new ObservableCollection<AssociatedEntityObject>();
        }

        [Key]
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }
        public virtual int ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual Dog Parent { get; set; }

        public virtual int BreedId { get; set; }

        [NotMapped]
        public virtual DogBreed Breed => (DogBreed)BreedId;

    }
}