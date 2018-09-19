using ServiceManager.Common;
using ServiceManager.Forms;
using ServiceManager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace ServiceManager
{
    public partial class ServiceManager : Form
    {
        #region GLOBAL_VARIABLES

        System.Timers.Timer _Timer;
        List<Service> _Services;

        #endregion

        #region CONSTRUCTOR
        public ServiceManager()
        {
            InitializeComponent();
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Width - this.Width - 5, workingArea.Height - this.Height - 5);
            LoadServices();
            InitializeQueryTimer(Properties.Settings.Default.TIMER_INTERVAL);
        }

        #endregion

        #region FORM_METHODS

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ServiceManager_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon.Visible = true;
                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon.Visible = false;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void btnConfiguration_Click(object sender, EventArgs e)
        {
            if (_Timer != null)
            {
                _Timer.Enabled = false;
                _Timer.Dispose();
            }

            Configuration serviceListForm = new Configuration();
            serviceListForm.ShowDialog();

            pnlServiceControls.Controls.Clear();
            LoadServices();

            InitializeQueryTimer(Properties.Settings.Default.TIMER_INTERVAL);
        }

        #endregion

        #region OTHER_METHODS
        private void LoadServices()
        {
            int counter;
            Service_UserControl ucGenericService;

            _Services = Helper.GetXmlServices();
            if (_Services != null)
            {
                counter = 0;
                foreach (Service service in _Services)
                {
                    ucGenericService = new Service_UserControl(service);
                    ucGenericService.Location = new Point(0, (ucGenericService.Height * counter));
                    ucGenericService.Name = service.Name.Trim();
                    pnlServiceControls.Controls.Add(ucGenericService);
                    counter++;
                }
            }
        }

        private async void btnQueryAll_Click(object sender, EventArgs e)
        {
            pbLoading.Image = Image.FromFile(Helper.GetServerPath(Constants.LOADING_PATH));
            pbLoading.ErrorImage = Image.FromFile(Helper.GetServerPath(Constants.LOADING_PATH));

            if (_Services == null)
                _Services = Helper.GetXmlServices();

            await Task.Run(() => QueryAllServices(_Services));

            pbLoading.Image = null;
            pbLoading.ErrorImage = null;
        }

        public async void QueryAllServices(List<Service> Services)
        {
            int state;
            try
            {
                if (Services != null)
                {
                    foreach (Service service in Services)
                    {
                        state = Helper.QueryService(service.Name.Trim());
                        var uc = pnlServiceControls.Controls.Find(service.Name.Trim(), true);
                        var pb = uc[0].Controls.Find("pbColorStatus", true);

                        PictureBox statusLight = (PictureBox)pb[0];

                        statusLight.Image = Image.FromFile(Helper.GetStatusImagePath(state));
                        statusLight.ErrorImage = Image.FromFile(Helper.GetStatusImagePath(state));
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.Logger(Helper.GetCurrentAsyncMethod(), ex.Message, ex.StackTrace);
                throw;
            }
        }

        private async void btnStartAll_Click(object sender, EventArgs e)
        {
            pbLoading.Image = Image.FromFile(Helper.GetServerPath(Constants.LOADING_PATH));
            pbLoading.ErrorImage = Image.FromFile(Helper.GetServerPath(Constants.LOADING_PATH));

            if (_Services == null)
                _Services = Helper.GetXmlServices();

            await Task.Run(() => StartAllServices(_Services));

            pbLoading.Image = null;
            pbLoading.ErrorImage = null;
        }

        public async void StartAllServices(List<Service> Services)
        {
            int state;
            foreach (Service service in Services)
            {
                state = Helper.QueryService(service.Name.Trim());

                if (state == (int)Constants.ServiceStateValue.STOPPED || state == (int)Constants.ServiceStateValue.STOP_PENDING)
                    await Task.Run(() => Helper.StartService(service.Name.Trim()));
            }
        }

        private async void btnStopAll_Click(object sender, EventArgs e)
        {
            pbLoading.Image = Image.FromFile(Helper.GetServerPath(Constants.LOADING_PATH));
            pbLoading.ErrorImage = Image.FromFile(Helper.GetServerPath(Constants.LOADING_PATH));

            if (_Services == null)
                _Services = Helper.GetXmlServices();

            await Task.Run(() => StopAllServices(_Services));

            pbLoading.Image = null;
            pbLoading.ErrorImage = null;
        }

        public async void StopAllServices(List<Service> Services)
        {
            int state;
            foreach (Service service in Services)
            {
                state = Helper.QueryService(service.Name.Trim());

                if (state == (int)Constants.ServiceStateValue.RUNNING || state == (int)Constants.ServiceStateValue.START_PENDING)
                    await Task.Run(() => Helper.StopService(service.Name.Trim()));
            }
        }

        private void InitializeQueryTimer(int MilliSeconds)
        {
            _Timer = new System.Timers.Timer();
            _Timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            _Timer.Interval = MilliSeconds;
            _Timer.Enabled = true;
        }

        private async void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (_Services == null)
                _Services = Helper.GetXmlServices();

            await Task.Run(() => QueryAllServices(_Services));
        }

        #endregion

    }
}
