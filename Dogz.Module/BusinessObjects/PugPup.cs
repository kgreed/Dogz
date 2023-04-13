using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Dogz.Module.BusinessObjects
{
    public class PugPup : Puppy
    {

        public PugPup() { { BreedId = (int)DogBreed.Pug; } }

        [ForeignKey(nameof(ParentID))]
        public virtual Pug PugParent { get; set; }

        public override event PropertyChangingEventHandler PropertyChanging;
    }
}