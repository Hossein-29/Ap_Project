using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    enum PackageType
    {
        obj,
        document,
        breakable
    }
    enum PostType
    {
        regular,
        express
    }

    public interface IPackage
    {
        int id { get; set; }
        string senderAddress { get; set; }
        string recieverAddress { get; set; }

        bool isExpensive { get; set; }
        string recieverPhoneNumber { get; set; }
    }
}
