using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppProj.Models
{
    public class AnnouncementDetailsViewModel
    {
        public Announcement Announcement { get; set; }
        public List<Comments> Comments { get; set; }

        public int AnnouncementsId { get; set; }
        public string Comment { get; set; }
    }
}
