using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public interface IPerson
    {
        string id { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }
        string email { get; set; }
        string userName { get; set; }
        string password { get; set; }
    }
}
