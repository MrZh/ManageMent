using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yang.Management.Repository
{
    public class DapperContext
    {
        public static string ConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        private readonly string _connString;
        public DapperContext(string connString)
        {
            _connString = connString;
        }

        /// <summary>
        /// 执行事务
        /// </summary>
        /// <param name="baseCommand">基础事务语句</param>
        /// <param name="commandTimeout">事务执行时间</param>
        /// <returns>是否成功</returns>
        public int ExecTransaction(BaseCommand baseCommand, int commandTimeout = 0)
        {
            int result;
            if (commandTimeout <= 0)
            {
                commandTimeout = 30;
            }
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        result = conn.Execute(baseCommand.Sql, baseCommand.Obj, trans, commandTimeout, CommandType.Text);
                    }
                    catch (DataException ex)
                    {
                        trans.Rollback();
                        throw;
                    }
                    trans.Commit();
                }

                conn.Close();
            }

            return result;
        }

        /// <summary>
        /// 执行事务
        /// </summary>
        /// <param name="baseCommand">基础事务语句</param>
        /// <param name="commandTimeout">事务执行时间</param>
        /// <returns>是否成功</returns>
        public static int BaseTransaction(BaseCommand baseCommand, int commandTimeout = 0)
        {
            int result;
            if (commandTimeout <= 0)
            {
                commandTimeout = 30;
            }
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        result = conn.Execute(baseCommand.Sql, baseCommand.Obj, trans, commandTimeout, CommandType.Text);
                    }
                    catch (DataException ex)
                    {
                        trans.Rollback();
                        throw;
                    }
                    trans.Commit();
                }

                conn.Close();
            }

            return result;
        }

        /// <summary>
        /// 执行事务
        /// </summary>
        /// <param name="baseCommands">基础事务语句</param>
        /// <param name="commandTimeout">事务执行时间</param>
        /// <returns>是否成功</returns>
        public static int BaseTransaction(List<BaseCommand> baseCommands, int commandTimeout = 0)
        {
            var result = 0;
            if (commandTimeout <= 0)
            {
                commandTimeout = 30;
            }
            using (var conn = new SqlConnection(ConnString))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        result += baseCommands.Sum(baseCommand => conn.Execute(baseCommand.Sql, baseCommand.Obj, trans, commandTimeout, CommandType.Text));
                    }
                    catch (DataException ex)
                    {
                        trans.Rollback();
                        throw;
                    }
                    trans.Commit();
                }

                conn.Close();
            }

            return result;
        }

        /// <summary>
        /// 执行事务
        /// </summary>
        /// <param name="baseCommands">基础事务语句</param>
        /// <param name="commandTimeout">事务执行时间</param>
        /// <returns>是否成功</returns>
        public int ExecTransaction(List<BaseCommand> baseCommands, int commandTimeout = 0)
        {
            var result = 0;
            if (commandTimeout <= 0)
            {
                commandTimeout = 30;
            }
            using (var conn = new SqlConnection(_connString))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        result += baseCommands.Sum(baseCommand => conn.Execute(baseCommand.Sql, baseCommand.Obj, trans, commandTimeout, CommandType.Text));
                    }
                    catch (DataException ex)
                    {
                        trans.Rollback();
                        throw;
                    }
                    trans.Commit();
                }

                conn.Close();
            }

            return result;
        }

        /// <summary>
        /// 执行Command
        /// </summary>
        /// <param name="baseComand"></param>
        /// <returns></returns>
        public int ExecCommand(BaseCommand baseComand)
        {
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                var result = conn.Execute(baseComand.Sql, baseComand.Obj);
                conn.Close();
                return result;
            }
        }

        /// <summary>
        /// 执行Command
        /// </summary>
        /// <param name="baseComand"></param>
        /// <returns></returns>
        public static int BaseCommand(BaseCommand baseComand)
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                var result = conn.Execute(baseComand.Sql, baseComand.Obj);
                conn.Close();
                return result;
            }
        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public T GetByParam<T>(BaseQuery query)
        {
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                T item = conn.Query<T>(query.Sql, query.Obj).FirstOrDefault();
                conn.Close();
                return item;
            }

        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<T> GetListByParam<T>(BaseQuery query)
        {
            using (IDbConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                List<T> item = conn.Query<T>(query.Sql, query.Obj).ToList();
                conn.Close();
                return item;
            }

        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static T BaseGetByParam<T>(BaseQuery query)
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                T item = conn.Query<T>(query.Sql, query.Obj).FirstOrDefault();
                conn.Close();
                return item;
            }

        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static List<T> BaseGetListByParam<T>(BaseQuery query)
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                List<T> item = conn.Query<T>(query.Sql, query.Obj).ToList();
                conn.Close();
                return item;
            }

        }

        public static int BaseGetCountByParam(BaseQuery query)
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                int count = conn.QueryFirst(query.Sql, query.Obj);
                conn.Close();
                return count;
            }
        }
    }
}
