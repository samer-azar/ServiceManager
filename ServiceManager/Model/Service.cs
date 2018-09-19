using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServiceManager.Model
{
    [Serializable()]
    public class Service
    {
        public Service() { }
        public Service(string name, string displayName)
        {
            this.Name = name;
            this.DisplayName = displayName;
        }


        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "DisplayName")]
        public string DisplayName { get; set; }
        
        public int State { get; set; }
    }

    [Serializable()]
    [System.Xml.Serialization.XmlRoot("ServiceCollection")]
    public class ServiceCollection
    {
        [XmlArray("ServiceList")]
        [XmlArrayItem("Service", typeof(Service))]
        public List<Service> Services { get; set; }
    }
}