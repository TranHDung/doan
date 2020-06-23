using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    public class Respond : Entity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int Score { get; set; }
        public int GameShowId { get; set; }
        public GameShow GameShow { get; set; }
    }
}
