using DevExpress.Persistent.Base;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Dogz.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Dalmation : Dog
    {

        public Dalmation() { BreedId = (int)DogBreed.Dalmation;
        DalmationPups = new ObservableCollection<DalmationPup>();
        }

        public virtual ObservableCollection<DalmationPup> DalmationPups { get; set; }
    }
}