﻿using System;
using System.Collections.Generic;
namespace KhueLe.Scoreboards
{
    [Serializable]
    public class ScoreboardSaveData 
    {
        public List<ScoreboardEntryData> highscores = new List<ScoreboardEntryData>();
    }

}
