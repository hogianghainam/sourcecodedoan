using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteBanHang.Models
{
    public class Connect
    {
        public static dbQuanLyDataContext GetConnect()
        {
            //string connectionString = "Data Source=HOGIANGHAINAMIT;Initial Catalog=QuanLyBanHang;Integrated Security=True;Encrypt=False";
            string connectionString = "Data Source=SQL8006.site4now.net;Initial Catalog=db_aa20d9_banphukienlaptop;Persist Security Info=True;User ID=db_aa20d9_banphukienlaptop_admin;Password=hainam123";
            dbQuanLyDataContext dataContext = new dbQuanLyDataContext(connectionString);
            return dataContext;
        }
    }
}