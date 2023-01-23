using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork15_Task1.Model
{
    public class Films
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? FilmName { get; set; }
        public DateTime? FilmYear { get; set; }

        public virtual ICollection<Showtimes>? Showtimes { get; set; }

    }
}
