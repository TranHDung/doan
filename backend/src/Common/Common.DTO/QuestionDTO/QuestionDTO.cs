using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO
{
    public class QuestionDTO
    {
        public string Content { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public int RightAnswer { get; set; }
        public int? GameShowId { get; set; }
        public int UserId { get; set; }
    }
}
