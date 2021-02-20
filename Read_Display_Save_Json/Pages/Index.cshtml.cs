using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QuickType;
using System.Data.SqlClient;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

            using (var webclient = new WebClient())

            {
                var filePath = @"C:\Users\Niroj Humagain\Desktop\MOCK_DATA.json";
                bool r =File.Exists(filePath);

                if (r)
                {
                    var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                       var json = streamReader.ReadToEnd();
                        var welcome = Welcome.FromJson(json);
                        using (SqlConnection connection = new SqlConnection())
                        {
                            connection.ConnectionString = "Server=localhost\\MSSQLSERVER01;Database=SqlDataSave;Trusted_Connection=True;";
                            connection.Open();
                           
                            foreach (var item in welcome)
                            {
                                SqlCommand insertCommand = new SqlCommand("INSERT INTO Welcome (Id,First_Name, Last_Name, Email, Gender,Ip_Address) VALUES (@id, @fname, @lname, @email, @gender, @ip)", connection);

                                insertCommand.Parameters.Add(new SqlParameter("@id", item.Id));
                                insertCommand.Parameters.Add(new SqlParameter("@fname", item.First_Name));
                                insertCommand.Parameters.Add(new SqlParameter("@lname", item.Last_Name));
                                insertCommand.Parameters.Add(new SqlParameter("@email", item.Email));
                                insertCommand.Parameters.Add(new SqlParameter("@gender", item.Gender));
                                insertCommand.Parameters.Add(new SqlParameter("@ip", item.Ip_Address));
                                insertCommand.ExecuteNonQuery();
                            }
                            ViewData["Welcome"] = json;
                        }
                        //}
                    }
                }
                else {
                    ViewData["ErrorMessage"] = "File does not exists";

                }
                ////string jsonString = webclient.DownloadString(@"C:\Users\Niroj Humagain\Desktop\New folder (2)\WebApplication1\WebApplication1\MOCK_DATA.json");
                //if(string.IsNullOrEmpty(jsonString)) {
                //    return ; 
                //}
                //else
                //{
                //    var welcome = Welcome.FromJson(jsonString);

                //    using (SqlConnection connection = new SqlConnection())
                //    {
                //        connection.ConnectionString = "Server=localhost\\MSSQLSERVER01;Database=SqlDataSave;Trusted_Connection=True;";
                //        connection.Open();
                //        //insertCommand.Parameters.Add(new SqlParameter("@0", 1));
                //        //insertCommand.Parameters.Add(new SqlParameter("@1", "Nikesh"));
                //        //insertCommand.Parameters.Add(new SqlParameter("@2", "Niraula"));
                //        //insertCommand.Parameters.Add(new SqlParameter("@3", "aa"));
                //        //insertCommand.Parameters.Add(new SqlParameter("@4", "aa"));
                //        //insertCommand.Parameters.Add(new SqlParameter("@5", "aaaa"));
                //        //insertCommand.ExecuteNonQuery();
                //        foreach (var item in welcome)
                //        {
                //            SqlCommand insertCommand = new SqlCommand("INSERT INTO Welcome (Id,First_Name, Last_Name, Email, Gender,Ip_Address) VALUES (@id, @fname, @lname, @email, @gender, @ip)", connection);

                //            insertCommand.Parameters.Add(new SqlParameter("@id", item.Id));
                //            insertCommand.Parameters.Add(new SqlParameter("@fname", item.First_Name));
                //            insertCommand.Parameters.Add(new SqlParameter("@lname", item.Last_Name));
                //            insertCommand.Parameters.Add(new SqlParameter("@email", item.Email));
                //            insertCommand.Parameters.Add(new SqlParameter("@gender", item.Gender));
                //            insertCommand.Parameters.Add(new SqlParameter("@ip", item.Ip_Address));
                //            insertCommand.ExecuteNonQuery();
                //        }
                //        ViewData["Welcome"] = welcome;
                //    }
                //}

            }

        }
    }
}   


