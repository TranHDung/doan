using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    public class GameShow: Entity
    {
        public int Name { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int TimeNext { get; set; }
        public bool IsOpen { get; set; } = true;
        public ICollection<QuestionGameShow> QuestionGameShows { get; set; }
        public ICollection<Respond> Responds { get; set; }
        public ICollection<UserGameShow> UserGameShows { get; set; }
    }
}
