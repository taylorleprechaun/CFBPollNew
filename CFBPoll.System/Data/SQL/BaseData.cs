using WPU.InsurSys.Framework.Data.SQL.DataConnection;

namespace CFBPoll.System.Data.SQL
{
    public class BaseData
    {
        protected readonly DapperExecutor _dapperExecutor;

        public BaseData()
        {
            _dapperExecutor = new DapperExecutor();
        }
    }
}
