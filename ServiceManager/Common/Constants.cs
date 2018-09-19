using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceManager.Common
{
    public class Constants
    {
        #region WINDOWS_SERVICE_STATE

        public enum ServiceStateValue
        {
            STOPPED = 1,
            START_PENDING = 2,
            STOP_PENDING = 3,
            RUNNING = 4
        }

        #endregion

        #region COMMAND_OUTPUT

        public const string SC_QUERY_INVALID_SERVICE_NAME = "service does not exist";
        public const string NET_INVALID_SERVICE_NAME = "The service name is invalid";
        public const string NET_ACCESS_DENIED = "Access is denied";
        public const string NET_SERVICE_STARTED = "service was started successfully";
        public const string NET_ALREADY_STARTED = "The requested service has already been started";
        public const string NET_SERVICE_STOPPED = "service was stopped successfully";
        public const string NET_ALREADY_STOPPED = "service is not started";

        #endregion

        #region COMMANDS

        public const string QUERY_SERVICE = "SC QUERY \"{0}\"";
        public const string START_SERVICE = "NET START \"{0}\"";
        public const string STOP_SERVICE  = "NET STOP \"{0}\" /yes";
        public const string GET_ALL_SERVICES = "WMIC SERVICE GET NAME,DISPLAYNAME"; //Get the names & display names of all services

        #endregion

        #region PATHS
        
        public const string RUNNING_PATH = @"Resources\status_running.png";
        public const string STOPPED_PATH = @"Resources\status_stopped.png";
        public const string PENDING_PATH = @"Resources\status_starting_stopping.png";
        public const string ERROR_PATH = @"Resources\status_idle.png";
        public const string LOADING_PATH = @"Resources\loading.gif";

        #endregion


    }
}
