using Microsoft.AspNetCore.Mvc;

namespace SalesDatePredictionAPI.Helpers
{
    public class DBConnection : ControllerBase
    {
        private string _connectionString;
        private static DBConnection instance;
        private static readonly object lockObject = new object();

        private DBConnection() { }

        public static DBConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new DBConnection();
                        }
                    }
                }
                return instance;
            }
        }

        public void setConnectionString(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Connection");
        }

        public string getConnectionString()
        {
            return _connectionString;
        }
    }
}
