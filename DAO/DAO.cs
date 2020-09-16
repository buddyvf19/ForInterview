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
    public class _DAO :IDAC
    {
        protected string cnStr = ConfigurationManager.ConnectionStrings["MyDB"].ToString();
        protected string sql;
        int _CommandTimeout = 30;
        public _DAO(int CommandTimeout = 0)
        {
            _CommandTimeout = CommandTimeout > 0 ? CommandTimeout : _CommandTimeout;
        }
        /// <summary>
        /// 查詢清單
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        protected List<T> QueryLists<T>(string sql, object Parameters = null)
        {
            using (var conn = new SqlConnection(cnStr))
            {
                return conn.Query<T>(sql, Parameters, null, true, _CommandTimeout).ToList();
            }
        }
        /// <summary>
        /// 查詢第一筆
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        protected T QueryFirst<T>(string sql, object Parameters = null)
        {
            using (var conn = new SqlConnection(cnStr))
            {
                return conn.Query<T>(sql, Parameters, null, true, _CommandTimeout).FirstOrDefault();
            }
        }
        /// <summary>
        /// 查詢清單(dictionary)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        protected List<Dictionary<string, object>> QueryDictionary(string sql, object Parameters = null)
        {
            using (var conn = new SqlConnection(cnStr))
            {
                return (conn.Query(sql, Parameters, null, true, _CommandTimeout) as IEnumerable<Dictionary<string, object>>).ToList();
            }
        }
        /// <summary>
        /// 查詢第一行第一列
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        protected T QueryScarlet<T>(string sql, object Parameters = null)
        {
            using (var conn = new SqlConnection(cnStr))
            {
                return conn.ExecuteScalar<T>(sql, Parameters, null, _CommandTimeout);
            }
        }
        /// <summary>
        /// 執行command
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        protected int ExcuteNoQuery(string sql, object Parameters = null)
        {
            using (var conn = new SqlConnection(cnStr))
            {
                return conn.Execute(sql, Parameters, null, _CommandTimeout);
            }
        }

        public virtual List<T> GetList<T>(T Model)
        {
            return new List<T>();
        }
        public virtual List<T> GetList<T>()
        {
            return new List<T>();
        }
        public virtual T GetFirst<T>(T Model)
        {
            return Model;
        }
        public virtual T GetFirst<T>(int id)
        {
            return default ;
        }
        public virtual void Insert<T>(T Model)
        {
        }
        public virtual void Update<T>(T Model)
        {
        }
        public virtual void Delete(int[] id)
        { 
        }
    }
}
