using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using Dapper;

namespace DAO
{
    /// <summary>
    /// 資料庫界接底層
    /// </summary>
    public class _DAO : IDisposable
    {
        string cnStr = ConfigurationManager.ConnectionStrings["MyDB"].ToString();
        private bool disposed = false;
        int _CommandTimeout = 30;
        public _DAO(int CommandTimeout = 0)
        {
            _CommandTimeout = CommandTimeout>0? CommandTimeout: _CommandTimeout;
        }
        /// <summary>
        /// 查詢清單
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public List<T> QueryLists<T>(string sql, object Parameters = null)
        {
            using (var conn = new SqlConnection(cnStr))
            {
                return conn.Query<T>(sql, Parameters).ToList();
            }
        }
        /// <summary>
        /// 查詢第一筆
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public T QueryFirst<T>(string sql, object Parameters = null)
        {
            using (var conn = new SqlConnection(cnStr))
            {
                return conn.QueryFirst<T>(sql, Parameters);
            }
        }
        /// <summary>
        /// 查詢清單(dictionary)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public List<Dictionary<string,object>> QueryDictionary(string sql, object Parameters = null)
        {
            using (var conn = new SqlConnection(cnStr))
            {
               return(conn.Query(sql, Parameters) as IEnumerable<Dictionary<string, object>>).ToList();
            }
        }
        /// <summary>
        /// 查詢第一行第一列
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public T QueryScarlet<T>(string sql, object Parameters = null)
        {
            using (var conn = new SqlConnection(cnStr))
            {
                return conn.ExecuteScalar<T>(sql, Parameters);
            }
        }
        /// <summary>
        /// 執行command
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public int ExcuteNoQuery(string sql, object Parameters = null)
        {
            using (var conn = new SqlConnection(cnStr))
            {
                return conn.Execute(sql, Parameters);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 
        /// </summary>
        ~_DAO()
        {
            Dispose(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                disposed = true;
            }
        }
    }
}
