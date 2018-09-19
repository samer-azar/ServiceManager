using ServiceManager.Common;
using ServiceManager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ServiceManager.Forms
{
    public partial class Configuration : Form
    {
        #region GLOBAL_VARIABLES

        List<Service> _AllServices;
        List<Service> _PickedServices;
        string _LogDirectoryPath;

        #endregion

        public Configuration()
        {
            InitializeComponent();
            LoadServicesTab();
        }

        #region FORM_EVENTS

        private void tbConfiguration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbConfiguration.SelectedIndex == 0)
            {
                LoadServicesTab();
            }
            else if (tbConfiguration.SelectedIndex == 1)
            {
                LoadInitialSettingValues();
            }
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            if (tbConfiguration.SelectedIndex == 0)
                WriteServicesToXml(_PickedServices);
            else if (tbConfiguration.SelectedIndex == 1)
                SaveGeneralSettings();

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (tbConfiguration.SelectedIndex == 0)
                WriteServicesToXml(_PickedServices);
            else if (tbConfiguration.SelectedIndex == 1)
                SaveGeneralSettings();

            btnApply.Enabled = false;
        }

        #endregion

        #region SERVICES

        private void LoadServicesTab()
        {
            LoadPickedServices();
            LoadAllServices();
            DisplayListBoxItemCounter();
        }

        private void LoadPickedServices()
        {
            lbPickedServices.DisplayMember = "DisplayName";
            lbPickedServices.ValueMember = "Name";

            _PickedServices = Helper.GetXmlServices();

            if (_PickedServices != null)
            {
                lbPickedServices.Items.Clear();
                foreach (Service service in _PickedServices)
                {
                    lbPickedServices.Items.Add(service);
                }

                if (lbPickedServices.Items.Count > 0)
                    lbPickedServices.SelectedIndex = 0;
            }
        }

        private void LoadAllServices()
        {
            lbAllServices.DisplayMember = "DisplayName";
            lbAllServices.ValueMember = "Name";
            _AllServices = Helper.GetAllServices();

            if (_AllServices != null)
            {
                _AllServices = _AllServices.OrderBy(o => o.DisplayName).ToList();

                //Load all services except the picked ones to monitor
                if (_PickedServices != null)
                {
                    foreach (Service pickedService in _PickedServices)
                        _AllServices.Remove(_AllServices.FirstOrDefault(u => u.Name == pickedService.Name));
                }

                lbAllServices.Items.Clear();

                foreach (Service service in _AllServices)
                {
                    lbAllServices.Items.Add(service);
                }

                if (lbAllServices.Items.Count > 0)
                    lbAllServices.SelectedIndex = 0;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Service selectedItem;
            int index;

            if (lbAllServices.Items.Count > 0)
            {
                selectedItem = (Service)lbAllServices.SelectedItem;
                index = lbAllServices.SelectedIndex;
                if (selectedItem != null)
                    MoveItem(true, selectedItem);

                if (lbPickedServices.Items.Count == 1)
                {
                    lbPickedServices.SelectedIndex = 0;
                }

                if (lbAllServices.Items.Count > 0)
                {
                    if ((index + 1) <= lbAllServices.Items.Count)
                        lbAllServices.SelectedIndex = index;
                    else
                        lbAllServices.SelectedIndex = index - 1;
                }

                if (!btnApply.Enabled)
                    btnApply.Enabled = true;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Service selectedItem;
            int index;

            if (lbPickedServices.Items.Count > 0)
            {
                selectedItem = (Service)lbPickedServices.SelectedItem;
                index = lbPickedServices.SelectedIndex;
                if (selectedItem != null)
                    MoveItem(false, selectedItem);

                if (lbAllServices.Items.Count == 1)
                {
                    lbAllServices.SelectedIndex = 0;
                }

                if (lbPickedServices.Items.Count > 0)
                {
                    if ((index + 1) <= lbPickedServices.Items.Count)
                        lbPickedServices.SelectedIndex = index;
                    else
                        lbPickedServices.SelectedIndex = index - 1;
                }

                if (!btnApply.Enabled)
                    btnApply.Enabled = true;
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            List<Service> pickedServices;

            if (lbPickedServices.Items.Count > 0)
            {
                pickedServices = new List<Service>();
                foreach (Service pickedServiceItem in lbPickedServices.Items)
                {
                    pickedServices.Add(pickedServiceItem);
                }

                foreach (Service pickedServiceItem in pickedServices)
                {
                    MoveItem(false, pickedServiceItem);
                }

                if (!btnApply.Enabled)
                    btnApply.Enabled = true;
            }
        }

        private void MoveItem(bool isAddingItem, Service serviceItem)
        {
            Service movedService;

            if (isAddingItem)
            {
                movedService = _AllServices.First(s => s.Name == serviceItem.Name);

                _AllServices.Remove(movedService);
                _PickedServices.Add(movedService);

                lbAllServices.Items.Remove(movedService);
                lbPickedServices.Items.Add(movedService);
            }
            else
            {
                movedService = _PickedServices.First(s => s.Name == serviceItem.Name);

                _PickedServices.Remove(movedService);
                _AllServices.Add(movedService);

                lbPickedServices.Items.Remove(movedService);
                lbAllServices.Items.Add(movedService);
                lbAllServices.Sorted = true;
            }

            DisplayListBoxItemCounter();
        }

        private void DisplayListBoxItemCounter()
        {
            lblAllServicesCount.Text = _AllServices.Count.ToString();
            lblPickedServicesCount.Text = _PickedServices.Count.ToString();
        }

        private void WriteServicesToXml(List<Service> ServiceList)
        {
            if (_PickedServices != null)
            {
                StringBuilder xmlStringBuilder = new StringBuilder("<?xml version=\"1.0\" encoding=\"UTF-8\"?><ServiceCollection><ServiceList>");
                foreach (Service service in _PickedServices)
                    xmlStringBuilder.Append(string.Format("<Service><Name>{0}</Name><DisplayName>{1}</DisplayName></Service>", service.Name, service.DisplayName));

                xmlStringBuilder.Append("</ServiceList></ServiceCollection>");

                Helper.SaveToXmlFile(xmlStringBuilder);
            }
        }

        #endregion

        #region GENERAL_CONFIGURATION

        private void LoadInitialSettingValues()
        {
            txtLogFileDirectoryPath.Text = Properties.Settings.Default.LOGFILE_PATH;
            nuTimerIntervalInSeconds.Value = (decimal)((Properties.Settings.Default.TIMER_INTERVAL) / 1000);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            btnApply.Enabled = true;

            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtLogFileDirectoryPath.Text = folderBrowserDialog.SelectedPath;
                _LogDirectoryPath = folderBrowserDialog.SelectedPath;
            }
        }

        private void SaveGeneralSettings()
        {
            if (_LogDirectoryPath != null)
                Properties.Settings.Default.LOGFILE_PATH = _LogDirectoryPath;

            Properties.Settings.Default.TIMER_INTERVAL = (int)(nuTimerIntervalInSeconds.Value * 1000);

            Properties.Settings.Default.Save();
        }

        private void nuTimerIntervalInSeconds_ValueChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        #endregion





    }
}
