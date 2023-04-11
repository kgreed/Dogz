using DevExpress.Persistent.Base;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Dogz.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Poodle : Dog { 
        
        public Poodle(
            
            
            ) { BreedId = (int)DogBreed.Poodle; 
        
            PoodlePups = new ObservableCollection<PoodlePup>();
        
        } 
    
      public virtual ObservableCollection<PoodlePup> PoodlePups { get; set; }
        public override event PropertyChangingEventHandler PropertyChanging;
    }
}