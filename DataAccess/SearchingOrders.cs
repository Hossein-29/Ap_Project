using CsvHelper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataAccess
{
    public class SearchingOrders
    {
        static public List<Order> SearchBySSN(string ssn, PostCompanyEntities _db)
        {
            var Orders = (from order in _db.Orders
                          where order.CustomerSSN == ssn
                          select order).ToList();
            return Orders;
        }

        static public List<Order> SearchByPrice(string price, PostCompanyEntities _db)
        {
            var Orders = (from order in _db.Orders
                          where order.FinalPrice.ToString() == price
                          select order).ToList();
            return Orders;
        }
        static public List<Order> SearchByWeight(string weight, PostCompanyEntities _db)
        {
            var Orders = (from order in _db.Orders
                          where order.Weight.ToString() == weight
                          select order).ToList();
            return Orders;
        }
        static public List<Order> SearchByPackageType(int index, PostCompanyEntities _db)
        {
            var Orders = (from order in _db.Orders
                          where order.PackageType == index
                          select order).ToList();
            return Orders;
        }
        static public List<Order> SearchByPostType(int index, PostCompanyEntities _db)
        {
            var Orders = (from order in _db.Orders
                          where order.PostType == index
                          select order).ToList();
            return Orders;
        }
        static public void SaveOrdersInCSV(List<Order> Orders, string Path)
        {
            using (var writer = new StreamWriter(Path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(Orders);
            }
            MessageBox.Show("result saved in .csv file successfully");
        }
        static public List<Order> SortListByDateTime(List<Order> list)
        {
            var Orders = list.OrderBy(x => x.CreatedAt).Select(n => n).ToList();
            return Orders;
        }
        static public List<Order> AdvancedSearch(string Price, string Weight, int PackageType, int PostType, PostCompanyEntities _db, List<Order> Orders,string UserType ,string SSN = "")
        {
            if (UserType == "Employee")
            {
                if (SSN != "")
                {
                    Orders = (from order in Orders
                              select order).Intersect(SearchBySSN(SSN, _db)).ToList();
                }
            }

            if (Price != "")
            {
                Orders = (from order in Orders
                          select order).Intersect(SearchByPrice(Price, _db)).ToList();
            }
            if (Weight != "")
            {
                Orders = (from order in Orders
                          select order).Intersect(SearchByWeight(Weight, _db)).ToList();
            }

            if (PackageType != -1)
            {
                Orders = (from order in Orders
                          select order).Intersect(SearchByPostType(PackageType, _db)).ToList();
            }
          
            if (PostType != -1)
            {
                Orders = (from order in Orders
                          select order).Intersect(SearchByPostType(PostType, _db)).ToList();
            }
            MessageBox.Show(Orders.Count.ToString());
            return Orders;
        }
    }
}
