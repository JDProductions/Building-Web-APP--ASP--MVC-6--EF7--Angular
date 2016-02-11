using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using AxpCallerRewrite.Concrete;
using AxpCallerRewrite.Interfaces;
using Newtonsoft.Json.Bson;

namespace AxpCallerRewrite.Concrete
{
    // Dont think this is right but you know, well you know - need to bind repository to Helper.
    public class LegacyHelper : ILegacyHelper
    {
        // We will parse data or get it into the correct format.

        // Create a new SQLReader object and read data from the command

        LegacyRepository repo = new LegacyRepository();

        public void GetCompanyData()
        {
            using (SqlDataReader reader = repo.GetCompanyTypes().ExecuteReader())
            {
                while (reader.Read())
                {
                    // write the data on to the screen
                    Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3}",
                    // call the objects from their index
                    reader[0], reader[1], reader[2], reader[3]));
                }
            }
        }
    }

    }



