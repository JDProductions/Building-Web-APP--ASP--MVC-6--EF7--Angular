using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using AxpCallerRewrite.Concrete;
using AxpCallerRewrite.Interfaces;
using Newtonsoft.Json.Bson;
using Microsoft.AspNet.Mvc.Rendering;
using AxpCallerRewrite.Models;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace AxpCallerRewrite.Concrete
{
    // Dont think this is right but you know, well you know - need to bind repository to Helper.
    public class LegacyHelper : ILegacyHelper
    {
        // We will parse data or get it into the correct format.

        // Create a new SQLReader object and read data from the command

        LegacyRepository repo = new LegacyRepository();

        //I think this should return a SelectList to be used in a dropdown
        public SelectList GetCompanyData()
        {

            // Need access to db

            List<SelectListItem> companyTypes = new List<SelectListItem>();

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

                    //Add the company type to the list. Assuming type name is in column 1 and list value is column 0
                    companyTypes.Add(new SelectListItem { Text = rowInfo[1], Value = rowInfo[0] });
                }

                

                return new SelectList(companyTypes, "Value", "Text");
            }
        }

        public void CreateCompany(CompanyModel company)
        {
            //Convert company to XML string
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load("Templates\\CreateCompany.xml");

            XmlElement info = (XmlElement)xmlDoc.SelectSingleNode("//CompanyInfo");
            if (info != null)
            {
                info.SetAttribute("Email", "");
                info.SetAttribute("StatusID", ""); // Set to new value.
                info.SetAttribute("Website", "");
                info.SetAttribute("Fax", company.Fax); // Set to new value.
                info.SetAttribute("Extension", ""); // Set to new value.
                info.SetAttribute("Phone", company.Phone); // Set to new value.
                info.SetAttribute("Country", company.Country); // Set to new value.
                info.SetAttribute("Zip", company.Zip.ToString()); // Set to new value.
                info.SetAttribute("State", company.State); // Set to new value.
                info.SetAttribute("City", company.City); // Set to new value.
                info.SetAttribute("Add2", ""); // Set to new value.
                info.SetAttribute("Add1", company.Address); // Set to new value.
                info.SetAttribute("CompanyName", company.CompanyName); // Set to new value.
            }
            XmlElement type = (XmlElement)xmlDoc.SelectSingleNode("//CompanyType");
            if (type != null)
            {
                type.SetAttribute("Type", company.CompanyType); // Set to new value.
            }

            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmltextWriter = new XmlTextWriter(stringWriter);
            xmlDoc.WriteTo(xmltextWriter);
            string xmlString = stringWriter.ToString();

            // Created an instance of SendTemplate 
            SendTemplate template = new SendTemplate();
            // Send Create Company Template to Server
            template.SendAxpTemplate(xmlString, company.EnvironmentLevel);
            //template.SendAxpTemplate(xmlString, environment.EnvironmentLevel);
        }

        public void ActivateFeature(FeatureModel feature)
        {
            //Convert company to XML string
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load("Templates\\Feature.xml");

            XmlElement info = (XmlElement)xmlDoc.SelectSingleNode("//Feature");
            if (info != null)
            {
                info.SetAttribute("ProdID", feature.ProdId.ToString());
                info.SetAttribute("DirtyFlag", feature.DirtyFlag.ToString()); // Set to new value.
                info.SetAttribute("StatusID", feature.OemId.ToString());
                info.SetAttribute("FeatureID", feature.FeatureId.ToString()); // Set to new value.
            }

            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmltextWriter = new XmlTextWriter(stringWriter);
            xmlDoc.WriteTo(xmltextWriter);
            string xmlString = stringWriter.ToString();
            // Created an instance of SendTemplate 
            SendTemplate template = new SendTemplate();
            // Send Create Company Template to Server
            template.SendAxpTemplate(xmlString, feature.EnvironmentLevel);
            //template.SendAxpTemplate(xmlString, environment.EnvironmentLevel);
            // return RedirectToAction("Axprevamp");
        }

        //Need to make this differnt from activate feature somehow
        public void DeactivateFeature(FeatureModel feature)
        {
            //Convert company to XML string
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load("Templates\\Feature.xml");

            XmlElement info = (XmlElement)xmlDoc.SelectSingleNode("//Feature");
            if (info != null)
            {
                info.SetAttribute("ProdID", feature.ProdId.ToString());
                info.SetAttribute("DirtyFlag", feature.DirtyFlag.ToString()); // Set to new value.
                info.SetAttribute("StatusID", feature.OemId.ToString());
                info.SetAttribute("FeatureID", feature.FeatureId.ToString()); // Set to new value.
            }

            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmltextWriter = new XmlTextWriter(stringWriter);
            xmlDoc.WriteTo(xmltextWriter);
            string xmlString = stringWriter.ToString();
            // Created an instance of SendTemplate 
            SendTemplate template = new SendTemplate();
            // Send Create Company Template to Server
            template.SendAxpTemplate(xmlString, feature.EnvironmentLevel);
            //template.SendAxpTemplate(xmlString, environment.EnvironmentLevel);
            // return RedirectToAction("Axprevamp");
        }
    }
}



