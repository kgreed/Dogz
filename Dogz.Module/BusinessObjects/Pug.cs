using DevExpress.Persistent.Base;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Dogz.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Pug : Dog { 
        public Pug() { BreedId = (int)DogBreed.Pug;
            PugPups = new ObservableCollection<PugPup>();
        }

        public virtual ObservableCollection<PugPup> PugPups { get; set; }

        public override event PropertyChangingEventHandler PropertyChanging;
    }
}