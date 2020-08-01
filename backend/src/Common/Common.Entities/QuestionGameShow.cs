using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    public class QuestionGameShow : Entity
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int GameshowId { get; set; }
        public GameShow GameShow { get; set; }
    }
}
