using QueryApi.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
//using System.Web.Script.Serialization;

namespace QueryApi.Service
{
    public interface IUserService
    {
        //public string ToJson(DataTable value);
        //public string ToJson(DataSet value);
    }

    public class UserService : IUserService
    {
        //public string ToJson(DataTable value)
        //{
        //    JavaScriptSerializer serializer = new JavaScriptSerializer();
        //    serializer.MaxJsonLength = 2147483647;

        //    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        //    Dictionary<string, object> row;
        //    foreach (DataRow dr in value.Rows)
        //    {
        //        row = new Dictionary<string, object>();
        //        foreach (DataColumn col in value.Columns)
        //        {
        //            row.Add(col.ColumnName, dr[col]);
        //        }
        //        rows.Add(row);
        //    }

        //    return serializer.Serialize(rows);
        //}

        //public string ToJson(DataSet value)
        //{
        //    System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        //    serializer.MaxJsonLength = 2147483647;

        //    Dictionary<string, List<Dictionary<string, object>>> dsList = new Dictionary<string, List<Dictionary<string, object>>>();
        //    List<Dictionary<string, object>> rows;
        //    Dictionary<string, object> row;

        //    foreach (DataTable dt in value.Tables)
        //    {
        //        rows = new List<Dictionary<string, object>>();
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            row = new Dictionary<string, object>();
        //            foreach (DataColumn col in dt.Columns)
        //            {
        //                row.Add(col.ColumnName, dr[col]);
        //            }
        //            rows.Add(row);
        //        }
        //        dsList.Add(dt.TableName, rows);
        //    }

        //    return serializer.Serialize(dsList);
        //}
    }
}
