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

        public SelectList GetCompanyData()
        {
            List<CompanyType> companyTypesList = repo.GetCompanyTypes().ToList();

            List<SelectListItem> itemsList = new List<SelectListItem>();

            foreach (CompanyType item in companyTypesList)
            {
                itemsList.Add(new SelectListItem { Value = item.CompanyTypeID.ToString(), Text = item.CompanyTypeDesc });
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

            return new SelectList(itemsList,"Value", "Text");
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

        public void CreateCompany(CompanyModel company)
        {
            //Insert Company properties into CreateCompany template
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load("Templates\\CreateCompany.xml");

            XmlElement info = (XmlElement)xmlDoc.SelectSingleNode("//CompanyInfo");
            if (info != null)
            {
                info.SetAttribute("Email", company.Email);
                info.SetAttribute("Website", "");
                info.SetAttribute("Fax", company.Fax);
                info.SetAttribute("Extension", "");
                info.SetAttribute("Phone", company.Phone);
                info.SetAttribute("CountryCode", company.Country);
                info.SetAttribute("Zip", company.Zip.ToString());
                info.SetAttribute("State", company.State);
                info.SetAttribute("City", company.City);
                info.SetAttribute("Add2", company.Address2);
                info.SetAttribute("Add1", company.Address1);
                info.SetAttribute("CompanyName", company.CompanyName);
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
            // Created an instance of SendTemplate 
            SendTemplate template = new SendTemplate();

            string[] ids = SplitCompanyIds(feature.CompanyIds);
            foreach (string id in ids)
            {
                // Send Create Company Template to Server
                template.SendAxpTemplate(CreateFeatureXML(feature, id, true), feature.EnvironmentLevel);
                //template.SendAxpTemplate(xmlString, environment.EnvironmentLevel);
            }
        }

        public void DeactivateFeature(FeatureModel feature)
        {
            // Created an instance of SendTemplate 
            SendTemplate template = new SendTemplate();

            string[] ids = SplitCompanyIds(feature.CompanyIds);
            foreach (string id in ids)
            {
                // Send Create Company Template to Server
                template.SendAxpTemplate(CreateFeatureXML(feature, id, false), feature.EnvironmentLevel);
                //template.SendAxpTemplate(xmlString, environment.EnvironmentLevel);
            }
        }

        private string CreateFeatureXML(FeatureModel feature, string id, bool activate)
        {
            //Insert Feature into Featrue template
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load("Templates\\Feature.xml");

            XmlElement company = (XmlElement)xmlDoc.SelectSingleNode("//Company");
            if (company != null)
            {
                company.SetAttribute("CompanyID", id);
            }

            XmlElement featureNode = (XmlElement)xmlDoc.SelectSingleNode("//Feature");
            if (featureNode != null)
            {
                featureNode.SetAttribute("StatusID", Convert.ToInt32(activate).ToString());
                featureNode.SetAttribute("ProdID", feature.ProdId.ToString());
                featureNode.SetAttribute("StatusID", feature.OemId.ToString());
                featureNode.SetAttribute("FeatureID", feature.FeatureId.ToString());
            }

            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmltextWriter = new XmlTextWriter(stringWriter);
            xmlDoc.WriteTo(xmltextWriter);
            return stringWriter.ToString();
        }

        private string[] SplitCompanyIds(string ids)
        {
            char[] splitters = { ',', ';', '\n' };

            return ids.Split(splitters);
        }
    }
}



