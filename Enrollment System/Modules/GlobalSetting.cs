using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment_System.Modules
{
    public static class GlobalSetting
    {


        private static string _connectionString;

        public static string ConnectionString 
        {
            get 
            {
                if (string.IsNullOrEmpty(_connectionString)) 
                {
                    _connectionString = "Data Source=(localdb)\\Local;Initial Catalog=IT3232Moroscallo;User ID=test;Password=test";
                }
                return _connectionString;
            }
            set => _connectionString = value;
        }
    }
}
