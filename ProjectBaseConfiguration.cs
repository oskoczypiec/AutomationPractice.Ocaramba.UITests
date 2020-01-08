using System.Configuration;
using System.IO;
using NUnit.Framework;
using Ocaramba;
using Ocaramba.Helpers;

namespace AutomationPractice.Ocaramba.UITests
{
    /// <summary>
    /// SeleniumConfiguration that consume app.config file
    /// </summary>
    public static class ProjectBaseConfiguration
    {
        private static readonly string CurrentDirectory = TestContext.CurrentContext.TestDirectory;
        public static string Url { get; } = ConfigurationManager.AppSettings["url"];
        public static string UsernameUser { get; } = ConfigurationManager.AppSettings["usernameUser"];
        public static string PasswordUser { get; } = ConfigurationManager.AppSettings["passwordUser"];
        /// <summary>
        /// Gets the data driven file.
        /// </summary>
        /// <value>
        /// The data driven file.
        /// </value>
        public static string DataDrivenFile
        {
            get
            {
                if (BaseConfiguration.UseCurrentDirectory)
                {
                    return Path.Combine(CurrentDirectory + ConfigurationManager.AppSettings["DataDrivenFile"]);
                }

                return ConfigurationManager.AppSettings["DataDrivenFile"];
            }
        }

        /// <summary>
        /// Gets the Excel data driven file.
        /// </summary>
        /// <value>
        /// The Excel data driven file.
        /// </value>
        public static string DataDrivenFileXlsx
        {
            get
            {
                if (BaseConfiguration.UseCurrentDirectory)
                {
                    return Path.Combine(CurrentDirectory + ConfigurationManager.AppSettings["DataDrivenFileXlsx"]);
                }

                return ConfigurationManager.AppSettings["DataDrivenFileXlsx"];
            }
        }

        /// <summary>
        /// Gets the Download Folder path
        /// </summary>
        public static string DownloadFolderPath
        {
            get { return FilesHelper.GetFolder(ConfigurationManager.AppSettings["DownloadFolder"], CurrentDirectory); }
        }
    }
}
