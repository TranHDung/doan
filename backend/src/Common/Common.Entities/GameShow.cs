using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    public class GameShow: Entity
    {
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int TimeNext { get; set; }
        public ICollection<Respond> Responds { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
