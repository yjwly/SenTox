using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbType = SqlSugar.DbType;

namespace SenToxRepository.Base
{
    public static class SugarConfig
    {
        public static ISqlSugarClient GetInstance(string connStr)
        {
            var db = new SqlSugarClient(new ConnectionConfig
            {
                ConnectionString = connStr,
                DbType = DbType.MySql,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });                   


            //开发环境打印执行SQL，方便调试
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql);
            };
            return db;
        }
    }
}
