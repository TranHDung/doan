using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    public class UserGameShow : Entity
    {
        public bool IsOnline { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int GameshowId { get; set; }
        public GameShow GameShow { get; set; }
    }
}
