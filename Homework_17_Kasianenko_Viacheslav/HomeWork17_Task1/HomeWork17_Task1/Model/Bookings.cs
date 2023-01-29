using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork17_Task1.Model
{
    public class Bookings   
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid? GuidClient { get; set; }
        public virtual Client? Client { get; set; }

        public Guid? GuidShowTimes { get; set; }
        public virtual Showtimes? Showtimes { get; set; }

        public Guid? GuidPlaceCinemaHall { get; set; }
        public virtual PlacesCinemaHall? PlacesCinemaHall { get; set; }
    }
}
