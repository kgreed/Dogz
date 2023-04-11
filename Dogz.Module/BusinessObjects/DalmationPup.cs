using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Dogz.Module.BusinessObjects
{
    public class DalmationPup : Puppy
    {
      
        public DalmationPup() { {
                BreedId = (int)DogBreed.Dalmation; }
        
        }

        [ForeignKey(nameof(ParentId))]
        public virtual Dalmation DalmationParent { get; set; }

    }
}