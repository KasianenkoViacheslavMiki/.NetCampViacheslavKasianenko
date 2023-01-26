using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeWork16_Task1.Model
{
    public class Client
    {
        private string? email;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public string? Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (null == value)
                {
                    throw new Exception("Не можливо присвоїти");
                }
                if (!new Regex("^\\S+@\\S+\\.\\S+$").IsMatch(value))
                {
                    throw new Exception("Не можливо присвоїти");
                }
                else
                {
                    this.email = value;
                }
            }
        }
        public virtual ICollection<Bookings>? Bookings { get; set; }

    }
}
