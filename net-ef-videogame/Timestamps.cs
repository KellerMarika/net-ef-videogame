using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public interface IHasUpdate
    {
      
        public DateTime? UpdateDate { get; set; }
    }
    public static class Extension
    {
        public static void UpdateAndSave <T>(this T row) where T : IHasUpdate 
        {
        row.UpdateDate = DateTime.UtcNow;
            //SQL salva riga
        }
    }
    internal class Timestamps:IHasUpdate
    {
        [Column("created_at")]
        public DateTime CreationDate { get; set; }= DateTime.UtcNow;
        [Column("updated_at")]
        public DateTime? UpdateDate { get; set; } = null;
      
        public void Save() { }

        public Timestamps() 
        {
            this.UpdateAndSave();
           
        }
    }
}
