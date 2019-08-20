using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essence.Test.RepositoryCore.Entity
{
    public class Amigo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int AmigoId { get; set; }
        public string Nome { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [NotMapped]
        public double Distancia { get; set; }
    }
}
