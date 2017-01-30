using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteApi.Models
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate => DateTime.Now;
        public string Author { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public string Phone { get; set; }
        public string Nationality
        {
            get;
            set;
        }
        public DateTime? TripStartDate { get; set; }
        public int? TripNumberOfPeople { get; set; }
        public string Ip
        {
            get;
            set;
        }
        public string Device
        {
            get;
            set;
        }
        public string FromUrl
        {
            get;
            set;
        }
    }
}
