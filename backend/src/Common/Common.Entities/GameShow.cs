﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    public class GameShow: Entity
    {
        public string Name { get; set; }
        public bool IsOpen { get; set; } = true;
        public bool IsOnline { get; set; } = true;
        public ICollection<QuestionGameShow> QuestionGameShows { get; set; }
        public ICollection<Respond> Responds { get; set; }
        public ICollection<UserGameShow> UserGameShows { get; set; }
    }
}
