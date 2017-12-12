using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppProj.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string CommentDesc { get; set; }

        public virtual Announcement MyAnnouncement { get; set; }

    }
}
