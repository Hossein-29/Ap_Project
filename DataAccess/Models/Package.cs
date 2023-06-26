using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Package : IPackage
    {
        public int id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string senderAddress { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string recieverAddress { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool isExpensive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string recieverPhoneNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
