using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceManager.Model;
using ServiceManager.Common;

namespace ServiceManager.Forms
{
    public partial class Service_UserControl : UserControl
    {
        #region GLOBAL_VARIABLES

        Service _Service;

        #endregion

        #region CONSTRUCTORS
        public Service_UserControl()
        {
            InitializeComponent();
        }

        public Service_UserControl(Service service)
        {
            InitializeComponent();
            _Service = service;
            LoadInitialValues();
        }

        private void LoadInitialValues()
        {
            string path;
            lblServiceName.Text = _Service.DisplayName.Trim();
            _Service.State = Helper.QueryService(_Service.Name.Trim());

            path = Helper.GetStatusImagePath(_Service.State);
            pbColorStatus.Image = Image.FromFile(path);
            pbColorStatus.ErrorImage = Image.FromFile(path);
        }

        #endregion

        #region OTHER_METHODS

        private async void btnStart_Click(object sender, EventArgs e)
        {
            int state;
            string path;
            Control control = btnStart.Parent;
            state = Helper.QueryService(control.Name);
            if (state == (int)Constants.ServiceStateValue.STOPPED)
            {
                await Task.Run(() => Helper.StartService(control.Name));

                state = Helper.QueryService(control.Name);
                path = Helper.GetStatusImagePath(state);
                pbColorStatus.Image = Image.FromFile(path);
                pbColorStatus.ErrorImage = Image.FromFile(path);
            }
        }

        private async void btnStop_Click(object sender, EventArgs e)
        {
            string path;
            int state;
            Control control = btnStart.Parent;
            
            state = Helper.QueryService(control.Name);
            if (state == (int)Constants.ServiceStateValue.RUNNING)
            {
                await Task.Run(() => Helper.StopService(control.Name));

                state = Helper.QueryService(control.Name);
                path = Helper.GetStatusImagePath(state);
                pbColorStatus.Image = Image.FromFile(path);
                pbColorStatus.ErrorImage = Image.FromFile(path);
            }
        }

        #endregion
    }
}
