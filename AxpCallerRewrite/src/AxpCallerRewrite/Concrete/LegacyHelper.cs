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
                //a list to keep track of the rows and their values
                List<Object> rowList = new List<Object>();

                while (reader.Read())
                {
                    //creates an array obect the size of the number of columns
                    object[] values = new object[reader.FieldCount];
                    //inserts the column values into the object array for the current row
                    reader.GetValues(values);
                    //add the row to the list
                    rowList.Add(values);
                }

                foreach (object[] row in rowList)
                {
                    // Create a string array large enough to hold all the column values in this array
                    string[] rowInfo = new string[row.Length];
                    // Create a column index into the array
                    int columnIndex = 0;
                    // Now process each column value
                    foreach (object column in row)
                    {
                        // Convert the value to a string and stick it in the string array
                        rowInfo[columnIndex++] = Convert.ToString(column);

                    }

                    //Do stuff with data depending on what is given from the database
                    //Example: CompanyTypeList.Add(rowInfo[0])
                }
            }
        }
    }
}



