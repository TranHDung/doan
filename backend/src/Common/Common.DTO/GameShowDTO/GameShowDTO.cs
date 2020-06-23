using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO
{
    public class GameShowDTO
    {
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int TimeNext { get; set; }
        public ICollection<QuestionDTO> Questions { get; set; }
    }
}
