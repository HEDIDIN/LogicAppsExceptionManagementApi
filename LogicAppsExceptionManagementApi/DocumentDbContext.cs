using System;
using System.Configuration;

namespace LogicAppsExceptionManagementApi
{
    /// <summary>
    /// 
    /// </summary>
    public class DocumentDbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public static string EndPoint = ConfigurationManager.AppSettings["EndPoint"];

        /// <summary>
        /// 
        /// </summary>
        public static string AuthKey = ConfigurationManager.AppSettings["AuthKey"];

        /// <summary>
        /// 
        /// </summary>
        public static string KeyType = ConfigurationManager.AppSettings["KeyType"];

        /// <summary>
        /// 
        /// </summary>
        public static string TokenVersion = ConfigurationManager.AppSettings["TokenVersion"];

        /// <summary>
        /// 
        /// </summary>
        public static string DatabaseId = ConfigurationManager.AppSettings["DatabaseId"];

        /// <summary>
        /// 
        /// </summary>
        public static string CollectionId = ConfigurationManager.AppSettings["CollectionId"];

        /// <summary>
        /// 
        /// </summary>
        public static string ProcedureId = ConfigurationManager.AppSettings["ProcedureId"];


        /// <summary>
        /// 
        /// </summary>
        public static string LogsCollectionId = ConfigurationManager.AppSettings["LogsCollectionId"];



    }
}