using ServiceManager.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace ServiceManager.Common
{
    public static class Helper
    {
        #region LOGGING
        public static void Logger(string MethodName, string Exception, string StackTrace)
        {
            string fileName, fullPath, log;
            try
            {
                fileName = string.Format("LOGS_{0}_{1}_{2}.txt", DateTime.Today.Month.ToString("00"), DateTime.Today.Day.ToString("00"), DateTime.Today.Year);
                fullPath = Path.Combine(Properties.Settings.Default.LOGFILE_PATH, fileName);

                //Manually create the directories if path or part of the path does not exist
                if (!Directory.Exists(Properties.Settings.Default.LOGFILE_PATH))
                    Directory.CreateDirectory(Properties.Settings.Default.LOGFILE_PATH);

                //Automatically create the file if does not exist and write/append log to it
                using (StreamWriter file = new StreamWriter(fullPath, true))
                {
                    log = string.Format(@"At {0}  Method: {1} - Exception: {2} - Stack Trace: {3}.", DateTime.Now.ToString(@"HH:mm"), MethodName, Exception, StackTrace);
                    file.WriteLine(log);
                    file.WriteLine();
                }
            }
            catch (Exception)
            { throw; }
        }

        public static string GetCurrentMethod()
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(1);
            return stackFrame.GetMethod().Name;
        }

        public static string GetCurrentAsyncMethod([CallerMemberName]string name = "")
        {
            return name;
        }

        #endregion

        public static List<Service> GetXmlServices()
        {
            List<Service> services = new List<Service>();
            string fileName, basePath, fullPath;
            ServiceCollection servicesCollection;

            try
            {
                fileName = "ServiceList.xml";
                basePath = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\", string.Empty);
                fullPath = Path.Combine(basePath, @"Common\", fileName);

                XmlSerializer serializer = new XmlSerializer(typeof(ServiceCollection));

                StreamReader reader = new StreamReader(fullPath);
                servicesCollection = (ServiceCollection)serializer.Deserialize(reader);
                reader.Close();

                if (servicesCollection.Services.Count > 0)
                {
                    services = new List<Service>();
                    foreach (Service service in servicesCollection.Services)
                    {
                        services.Add(new Service(service.Name.Trim(), service.DisplayName.Trim()));
                    }
                }
                return services;
            }
            catch (Exception ex)
            {
                Helper.Logger(GetCurrentMethod(), ex.Message, ex.StackTrace);
                throw;
            }
        }

        public static void SaveToXmlFile(StringBuilder xmlStringBuilder)
        {
            string fileName, basePath, fullPath;

            try
            {
                fileName = "ServiceList.xml";
                basePath = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\", string.Empty);
                fullPath = Path.Combine(basePath, @"Common\", fileName);

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xmlStringBuilder.ToString());
                xmlDocument.Save(fullPath);
            }
            catch (Exception ex)
            {
                Helper.Logger(GetCurrentMethod(), ex.Message, ex.StackTrace);
                throw;
            }
        }

        public static List<Service> GetAllServices()
        {
            List<Service> allServices;
            ServiceController[] services = null;

            try
            {
                allServices = new List<Service>();

                services = ServiceController.GetServices();

                if (services != null)
                {
                    allServices = new List<Service>();
                    foreach (ServiceController service in services)
                    {
                        allServices.Add(new Service(service.ServiceName, service.DisplayName));
                    }
                }
                return allServices;
            }
            catch (Exception ex)
            {
                Helper.Logger(GetCurrentMethod(), ex.Message, ex.StackTrace);
                throw;
            }
        }

        public static string RunCommand(string Command)
        {
            string result = string.Empty;
            ProcessStartInfo procStartInfo;
            try
            {
                procStartInfo = new ProcessStartInfo("cmd", "/c " + Command);

                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                procStartInfo.RedirectStandardError = true;

                // Wrap IDisposable into using (in order to release process 
                using (Process process = new Process())
                {
                    process.StartInfo = procStartInfo;
                    process.Start();

                    // Wait until process does its work
                    process.WaitForExit(30000);

                    // And only then read the result
                    result = process.StandardOutput.ReadToEnd();
                    if (result.Equals(string.Empty))
                        result = process.StandardError.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Helper.Logger(GetCurrentMethod(), ex.Message, ex.StackTrace);
                throw;
            }
            return result;
        }

        public static int QueryService(string serviceName)
        {
            int state = -1;
            string result;

            result = RunCommand(string.Format(Constants.QUERY_SERVICE, serviceName));

            if (result.Contains(Constants.SC_QUERY_INVALID_SERVICE_NAME))
                state = -1;
            else if (result.Contains(Constants.ServiceStateValue.STOPPED.ToString()))
                state = (int)Constants.ServiceStateValue.STOPPED;
            else if (result.Contains(Constants.ServiceStateValue.START_PENDING.ToString()))
                state = (int)Constants.ServiceStateValue.START_PENDING;
            else if (result.Contains(Constants.ServiceStateValue.STOP_PENDING.ToString()))
                state = (int)Constants.ServiceStateValue.STOP_PENDING;
            else if (result.Contains(Constants.ServiceStateValue.RUNNING.ToString()))
                state = (int)Constants.ServiceStateValue.RUNNING;

            return state;
        }

        public static string GetStatusImagePath(int State)
        {
            string path = string.Empty;

            switch (State)
            {
                case (int)Constants.ServiceStateValue.STOPPED:
                    path = Constants.STOPPED_PATH;
                    break;
                case (int)Constants.ServiceStateValue.START_PENDING:
                    path = Constants.PENDING_PATH;
                    break;
                case (int)Constants.ServiceStateValue.STOP_PENDING:
                    path = Constants.PENDING_PATH;
                    break;
                case (int)Constants.ServiceStateValue.RUNNING:
                    path = Constants.RUNNING_PATH;
                    break;
                case -1:
                    path = Constants.ERROR_PATH;
                    break;
            }

            return GetServerPath(path);
        }

        public static string GetServerPath(string Path)
        {
            return System.IO.Path.GetFullPath(Path).Replace("bin\\Debug\\", string.Empty).ToString();
        }

        public static async void StartService(string serviceName)
        {
            string result;
            result = RunCommand(string.Format(Constants.START_SERVICE, serviceName));
        }

        public static async void StopService(string serviceName)
        {
            string result;
            result = RunCommand(string.Format(Constants.STOP_SERVICE, serviceName));
        }

    }
}
