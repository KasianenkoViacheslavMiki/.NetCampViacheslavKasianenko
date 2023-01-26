using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork16_Task1.Model
{
    public class CinemaHalls
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Adress { get; set; }
        public virtual ICollection<PlacesCinemaHall>? PlacesCinemaHall { get; set; }
        public virtual ICollection<Showtimes>? Showtimes { get; set; }

        public Guid? GuidCinema { get; set; }
        public virtual Cinemas? Cinema { get; set; }
    }
}
