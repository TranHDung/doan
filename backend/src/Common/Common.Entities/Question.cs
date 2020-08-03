using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    public class Question : Entity
    {
        public string Content { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public int RightAnswer { get; set; }
        public ICollection<QuestionGameShow> QuestionGameShows { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
