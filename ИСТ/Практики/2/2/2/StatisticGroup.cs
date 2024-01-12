using System.Collections.Generic;

namespace _2
{
    internal class StatisticGroup
    {
       public Dictionary<string, StatisticGroupDiscipline> statisticGroupDisciplineDictionary = new Dictionary<string, StatisticGroupDiscipline>();
        public StatisticGroup(string discipline)
        {
            statisticGroupDisciplineDictionary.Add(discipline, new StatisticGroupDiscipline());
        } 
    }
}
