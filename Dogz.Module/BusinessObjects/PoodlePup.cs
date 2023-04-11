using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Dogz.Module.BusinessObjects
{
    public class PoodlePup : Puppy
    {
        public PoodlePup() { 
            BreedId = (int)DogBreed.Poodle;
        }
        [ForeignKey(nameof(ParentId))]
        public virtual Poodle PoodleParent { get; set; }
        public override event PropertyChangingEventHandler PropertyChanging;
    }
}