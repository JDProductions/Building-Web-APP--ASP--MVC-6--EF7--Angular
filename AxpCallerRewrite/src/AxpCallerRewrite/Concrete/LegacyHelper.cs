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
using AxpCallerRewrite.Models.Database_Models;

namespace AxpCallerRewrite.Concrete
{
    // Dont think this is right but you know, well you know - need to bind repository to Helper.
    public class LegacyHelper : ILegacyHelper
    {
        // We will parse data or get it into the correct format.

        // Create a new SQLReader object and read data from the command

        LegacyRepository repo = new LegacyRepository();
        char[] splitters = { ',', ';', '\n' };

        public SelectList GetCompanyData()
        {
            List<CompanyType> companyTypesList = repo.GetCompanyTypes().ToList();

            List<SelectListItem> itemsList = new List<SelectListItem>();

            foreach (CompanyType item in companyTypesList)
            {
                //removing Demo (1) because there is a seperate check box
                if (item.CompanyTypeID != 1)
                {
                    string text = item.CompanyTypeDesc + " (" + item.CompanyTypeID.ToString() + ")";
                    itemsList.Add(new SelectListItem { Value = item.CompanyTypeID.ToString(), Text = text });
                }
            }


            return new SelectList(itemsList, "Value", "Text");
        }

        public SelectList GetStates()
        {
            List<State> stateList = repo.GetStates().ToList();

            List<SelectListItem> itemsList = new List<SelectListItem>();

            foreach (State item in stateList)
            {
                itemsList.Add(new SelectListItem { Value = item.StateAbbr, Text = item.StateName });
            }

            return new SelectList(itemsList, "Value", "Text");
        }

        public SelectList GetOEMs()
        {
            List<OEM> oemList = repo.GetOEMs().ToList();

            List<SelectListItem> itemsList = new List<SelectListItem>();

            foreach (OEM item in oemList)
            {
                itemsList.Add(new SelectListItem { Value = item.OEMID.ToString(), Text = item.OEMLongName });
            }

            return new SelectList(itemsList, "Value", "Text");
        }

        public SelectList GetProducts()
        {
            List<Product> productList = repo.GetProducts().ToList();

            List<SelectListItem> itemsList = new List<SelectListItem>();

            foreach (Product item in productList)
            {
                itemsList.Add(new SelectListItem { Value = item.ProdID.ToString(), Text = item.DisplayName });
            }

            return new SelectList(itemsList, "Value", "Text");
        }

        public SelectList GetFeatures()
        {
            List<Feature> featureList = repo.GetFeatures().ToList();

            List<SelectListItem> itemsList = new List<SelectListItem>();

            foreach (Feature item in featureList)
            {
                itemsList.Add(new SelectListItem { Value = item.FeatureID.ToString(), Text = item.FeatureName });
            }

            return new SelectList(itemsList, "Value", "Text");
        }

        public SelectList GetProdIdLevelNum()
        {
            List<ProdIdLevelNum> idNumList = repo.GetProdIdLevelNum().ToList();

            List<SelectListItem> itemsList = new List<SelectListItem>();

            foreach (ProdIdLevelNum item in idNumList)
            {
                if (item.LegacyProductID.HasValue && item.ProductLevelNumber.HasValue)
                {
                    itemsList.Add(new SelectListItem
                    {
                        Value = item.LegacyProductID.ToString() + "," + item.ProductLevelNumber,
                        Text = item.LegacyProductName + " (" + item.LegacyProductID.ToString() + ") " +
                        item.ProductLevelKey + " (" + item.ProductLevelNumber.ToString() + ")"
                    });
                }
                else if (item.LegacyProductID.HasValue && !item.ProductLevelNumber.HasValue)
                {
                    itemsList.Add(new SelectListItem
                    { Value = item.LegacyProductID.ToString(),
                        Text = string.Format("{0} ({1})", item.LegacyProductName, item.LegacyProductID.ToString())});
                }
            }

            return new SelectList(itemsList, "Value", "Text");
        }

        public string CreateCompany(CompanyModel company)
        {
            //Insert Company properties into CreateCompany template
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load("Templates\\CreateCompany.xml");

            XmlElement info = (XmlElement)xmlDoc.SelectSingleNode("//CompanyInfo");
            if (info != null)
            {
                info.SetAttribute("Email", company.Email);
                info.SetAttribute("Website", string.Empty);
                info.SetAttribute("Fax", company.Fax);
                info.SetAttribute("Extension", string.Empty);
                info.SetAttribute("Phone", company.Phone);
                info.SetAttribute("CountryCode", company.Country);
                info.SetAttribute("Zip", company.Zip.ToString());
                info.SetAttribute("State", company.State);
                info.SetAttribute("City", company.City);
                info.SetAttribute("Add2", company.Address2);
                info.SetAttribute("Add1", company.Address1);
                info.SetAttribute("CompanyName", company.CompanyName);
            }

            XmlElement types = (XmlElement)xmlDoc.SelectSingleNode("//CompanyTypes");
            if (types != null)
            {
                if (company.Demo)
                {
                    XmlElement element = (XmlElement)xmlDoc.CreateNode("element", "CompanyType", "");
                    element.SetAttribute("Type", Convert.ToInt32(company.Demo).ToString());
                    types.AppendChild(element);
                }
                foreach (int id in company.CompanyTypes)
                {
                    XmlElement element = (XmlElement)xmlDoc.CreateNode("element", "CompanyType", "");
                    element.SetAttribute("Type", id.ToString());
                    types.AppendChild(element);
                }
            }

            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmltextWriter = new XmlTextWriter(stringWriter);
            xmlDoc.WriteTo(xmltextWriter);
            string xmlString = stringWriter.ToString();

            return CompanyResponse(repo.SendXml(xmlString, company.EnvironmentLevel));
        }

        //public string ActivateFeature(FeatureModel feature)
        //{
        //    // Created an instance of SendTemplate 
        //    SendTemplate template = new SendTemplate();

        //    string[] ids = feature.CompanyIds.Split(splitters);
        //    string messages = "";
        //    //question here
        //    foreach (string id in ids)
        //    {
        //        messages += ServerResponse(repo.SendXml(CreateFeatureXML(feature, id, true), feature.EnvironmentLevel)) + " ";
        //    }

        //    return messages;
        //}

        //public string DeactivateFeature(FeatureModel feature)
        //{
        //    // Created an instance of SendTemplate 
        //    SendTemplate template = new SendTemplate();

        //    string[] ids = feature.CompanyIds.Split(splitters);
        //    string messages = "";

        //    foreach (string id in ids)
        //    {
        //        messages += ServerResponse(repo.SendXml(CreateFeatureXML(feature, id, false), feature.EnvironmentLevel)) + " ";
        //    }
        //    return messages;
        //}

        public string ActivateProduct(ProductModel product)
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load("Templates\\ActivateProduct.xml");

            XmlElement companyInfo = (XmlElement)xmlDoc.SelectSingleNode("//Company");
            if (companyInfo != null)
            {
                companyInfo.SetAttribute("CompanyID", product.CompanyId.ToString());
            }
            XmlElement productInfo = (XmlElement)xmlDoc.SelectSingleNode("//Product");
            if (productInfo != null)
            {
                string[] ids = product.ProdIdLevelNum.Split(',');
                productInfo.SetAttribute("ProdID", ids[0]);
                if (ids.Length > 1)
                    productInfo.SetAttribute("ProdLevelID", ids[1]);
                productInfo.SetAttribute("ProdAction", "Activate");
            }

            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmltextWriter = new XmlTextWriter(stringWriter);
            xmlDoc.WriteTo(xmltextWriter);
            string xmlString = stringWriter.ToString();

            return ProductResponse(repo.SendXml(xmlString, product.EnvironmentLevel));
        }

        //private string CreateFeatureXML(FeatureModel feature, string id, bool activate)
        //{
        //    //Insert Feature into Featrue template
        //    XmlDocument xmlDoc = new XmlDocument();

        //    xmlDoc.Load("Templates\\Feature.xml");

        //    XmlElement company = (XmlElement)xmlDoc.SelectSingleNode("//Company");
        //    if (company != null)
        //    {
        //        company.SetAttribute("CompanyID", id);
        //    }

        //    XmlElement featureNode = (XmlElement)xmlDoc.SelectSingleNode("//Feature");
        //    if (featureNode != null)
        //    {
        //        featureNode.SetAttribute("StatusID", Convert.ToInt32(activate).ToString());
        //        featureNode.SetAttribute("ProdID", feature.ProdId.ToString());
        //        featureNode.SetAttribute("OEMID", feature.OemId.ToString());
        //        featureNode.SetAttribute("FeatureID", feature.FeatureId.ToString());
        //    }

        //    StringWriter stringWriter = new StringWriter();
        //    XmlTextWriter xmltextWriter = new XmlTextWriter(stringWriter);
        //    xmlDoc.WriteTo(xmltextWriter);
        //    return stringWriter.ToString();
        //}

        //private string ServerResponse(string message)
        //{
        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(message);

        //    XmlElement error = (XmlElement)doc.SelectSingleNode("//Error");
        //    //There is some kind of error
        //    if (error != null)
        //    {
        //        if (!error.GetAttribute("ErrDesc").Equals(""))
        //            return "Error: " + error.GetAttribute("ErrDesc");
        //        if (!error.GetAttribute("Description").Equals(""))
        //            return "Error: " + error.GetAttribute("Description");
        //        if (!error.GetAttribute("Desc").Equals(""))
        //            return "Error: " + error.GetAttribute("Desc");
        //    }
        //    //There is no error
        //    else
        //    {
        //        XmlElement companyInfo = (XmlElement)doc.SelectSingleNode("//CompanyInfo");
        //        if (companyInfo != null)
        //        {
        //            return "Company ID: " + companyInfo.GetAttribute("CompanyID");
        //        }
        //        else
        //        {
        //            return "Activate Successful";
        //        }
        //    }

        //    return "Something went wrong";
        //}

        private string CompanyResponse(string message)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(message);

            XmlElement error = (XmlElement)doc.SelectSingleNode("//Error");
            if (error != null)
            {
                if (!error.GetAttribute("Description").Equals(""))
                    return "Error: " + error.GetAttribute("Description");
            }
            else
            {
                XmlElement companyInfo = (XmlElement)doc.SelectSingleNode("//CompanyInfo");
                if (companyInfo != null)
                {
                    return "Company ID: " + companyInfo.GetAttribute("CompanyID");
                }
            }

            return "Something went wrong.";
        }

        private string ProductResponse(string message)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(message);

            XmlElement error = (XmlElement)doc.SelectSingleNode("//Error");
            //There is some kind of error
            if (error != null)
            {
                if (!error.GetAttribute("Desc").Equals(""))
                    return "Error: " + error.GetAttribute("Desc");
            }
            else
            {
                return "Activate Successful.";
            }

            return "Something went wrong.";
        }
    }
}



