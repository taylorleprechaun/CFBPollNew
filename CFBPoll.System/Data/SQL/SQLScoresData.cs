using CFBPoll.System.Data.Interfaces;

namespace CFBPoll.System.Data.SQL
{
    public class SQLScoresData : BaseData, IScoresData
    {
        public SQLScoresData() : base() { }

        public string Scores_Insert(int season, int week)
        {
            return "test";
        }
    }
}
