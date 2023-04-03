using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SearchEngine
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        public static string HtmlEncode(string text, int fromN = 127)
        {
            if (text == null)
            {
                return null;
            }
            char[] chars = HttpUtility.HtmlEncode(text).ToCharArray();
            StringBuilder result = new StringBuilder(text.Length + (int)(text.Length * 0.1));

            foreach (char c in chars)
            {
                int value = Convert.ToInt32(c);
                if (value > fromN)
                    result.AppendFormat("&#{0};", value);
                else
                    result.Append(c);
            }

            return result.ToString();
        }
        public string searchOneKeyword(string keyword)
        {
            string searchTerm = HtmlEncode(keyword);
            string directoryPath = Server.MapPath("~/HTML");
            string result = "";
            IEnumerable<string> htmlFiles = Directory.GetFiles(directoryPath, "*.html", SearchOption.AllDirectories);

            foreach (string htmlFile in htmlFiles)
            {
                int lineNumber = 1;
                foreach (string line in File.ReadLines(htmlFile))
                {
                    if (line.Contains(searchTerm))
                    {
                        string href = "/HTML/" + Path.GetFileName(htmlFile);
                        string link = $"<a href='{href}'>{Path.GetFileName(htmlFile)} ({lineNumber})</a> <br>";
                        result += link;
                    }
                    lineNumber++;
                }
            }
            return result;
        }
        //public string searchOneKeyword(string keyword)
        //{
        //    string searchTerm = HtmlEncode(keyword); // replace with your search term
        //    string directoryPath = @"http://localhost:65079/HTML"; // replace with your directory path
        //    string dd = @"" + Server.MapPath("HTML");
        //    string result = "";
        //    // Get all HTML files in directory and its subdirectories
        //    IEnumerable<string> htmlFiles = Directory.GetFiles(dd, "*.html", SearchOption.AllDirectories);

        //    // Search through each HTML file and print out the filename and line number where the search term is found
        //    foreach (string htmlFile in htmlFiles)
        //    {
        //       // string nameFile = htmlFile.Split('\\')[htmlFile.Split('\\').Length - 1];
        //        int lineNumber = 1;
        //        foreach (string line in File.ReadLines(htmlFile))
        //        {
        //            if (line.Contains(searchTerm))
        //            {
        //               // result += $"<a href=\"{htmlFile}\"> {htmlFile} </a> ({lineNumber}) <br> \n\r\r";
        //                string href = "file:///" + htmlFile;
        //                string link = $"<a href='{href}'>{Path.GetFileName(htmlFile)} ({lineNumber})</a> <br>";
        //                result += link;
        //            }
        //            lineNumber++;
        //        }
        //    }
        //    return result;
        //}
        protected void DoSearch(Object sender,EventArgs e)
        {
            //hello there
            string[] arr = this.searchTerm.Text.Split(' ');
            string result = "";
            foreach(string a in arr)
            {
                result += searchOneKeyword(a);
            }
         
            this.resultsSearch.InnerHtml = result;
        }
    }
}