using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Dogz.Module.BusinessObjects
{
    public class DalmationPup : Puppy
    {
      
        public DalmationPup() { {
                BreedId = (int)DogBreed.Dalmation; }
        
        }

        [ForeignKey(nameof(ParentID))]
        public virtual Dalmation DalmationParent { get; set; }
        public override event PropertyChangingEventHandler PropertyChanging;

    }
}