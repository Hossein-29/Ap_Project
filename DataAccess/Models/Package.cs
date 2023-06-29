using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Package : IPackage
    {
        public int id { get; set; }
        public string senderAddress { get; set; }
        public string recieverAddress { get; set; }
        public bool isExpensive { get; set; }
        public string recieverPhoneNumber { get; set; }
        public static int num = 1;
        public static ObservableCollection<Package> packages = new ObservableCollection<Package>();

        public Package(string senderAddress, string recieverAddress, bool isExpensive, string recieverPhoneNumber)
        {
            this.id = num++;
            this.senderAddress = senderAddress;
            this.recieverAddress = recieverAddress;
            this.isExpensive = isExpensive;
            this.recieverPhoneNumber = recieverPhoneNumber;
            packages.Add(this);
        }
    }
}
