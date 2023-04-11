using System.ComponentModel.DataAnnotations;

namespace Dogz.Module.BusinessObjects
{
    public class MyBaseObject
    {
        [Key]
        public virtual int Id { get; set; }
    }
}