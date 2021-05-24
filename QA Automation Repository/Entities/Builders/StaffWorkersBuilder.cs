using HW7.Entities.People;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HW7.Entities.Builders
{
    class StaffWorkersBuilder : WorkerBuilder<StaffWorker>
    {
        public override List<StaffWorker> Build(XmlDocument xmlDocument)
        {
            List<StaffWorker> staffWorkers = new List<StaffWorker>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            XmlElement xmlRoot = xmlDocument.DocumentElement;
            foreach (XmlNode xmlNode in xmlRoot)
            {
                if (xmlNode.Attributes.Count > 0)
                {
                    base.FillTheWorkerParameters(parameters, xmlNode);
                    XmlNode attribute = xmlNode.Attributes.GetNamedItem("vacancy");
                    if (attribute != null)
                    {
                        parameters.Add("vacancy", attribute.Value);
                    }
                    staffWorkers.Add(new StaffWorker(Convert.ToInt32(parameters["id"]), parameters["name"], parameters["surname"], Convert.ToInt32(parameters["age"]), Convert.ToInt32(parameters["experience"]), Convert.ToDouble(parameters["loan"]), (AdministrationDuties)Enum.Parse(typeof(AdministrationDuties), parameters["administrational_duties"]), (StaffVacancies)Enum.Parse(typeof(StaffVacancies), parameters["vacancy"])));
                }
                parameters.Clear();
            }
            return staffWorkers;
        }
    }
}
