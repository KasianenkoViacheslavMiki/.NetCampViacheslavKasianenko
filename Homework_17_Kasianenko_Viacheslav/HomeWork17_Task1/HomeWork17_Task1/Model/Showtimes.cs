using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork17_Task1.Model
{
    public class Showtimes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime ShowTime { get; set; }
        public decimal PriceShowTime { get; set; }

        public Guid? GuidFilm { get; set; }
        public virtual Films? Film { get; set; }
        
        public Guid? GuidCinemaHall { get; set; }
        public virtual CinemaHalls? CinemaHall { get; set; }


        public virtual IEnumerable<Bookings>? Bookings { get; set; }
    }
}
