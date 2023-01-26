using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork16_Task1.Model
{
    public class PlacesCinemaHall
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public uint? NumberPlace { get; set; }

        public Guid? GuidCinemaHall { get; set; }
        public virtual CinemaHalls CinemaHalls { get; set; }
        public virtual ICollection<Bookings>? Bookings { get; set; }

    }
}
