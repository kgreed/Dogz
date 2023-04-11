using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Dogz.Module.BusinessObjects
{
    public class PugPup : Puppy
    {

        public PugPup() { { BreedId = (int)DogBreed.Pug; } }

        [ForeignKey(nameof(ParentId))]
        public virtual Pug PugParent { get; set; }
    }
}