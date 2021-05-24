using HW7.Entities.Education;
using HW7.Entities.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace HW7.Entities.Builders
{
    class ScienceWorkersBuilder : WorkerBuilder<ScienceWorker>
    {
        public List<AcademicSubject> Subjects { get; set; }

        public ScienceWorkersBuilder(List<AcademicSubject> subjects)
        {
            Subjects = subjects;
        }

        public override List<ScienceWorker> Build(XmlDocument xmlDocument)
        {
            List<ScienceWorker> scienceWorkers = new List<ScienceWorker>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            XmlElement xmlRoot = xmlDocument.DocumentElement;
            foreach (XmlNode xmlNode in xmlRoot)
            {
                if (xmlNode.Attributes.Count > 0)
                {
                    base.FillTheWorkerParameters(parameters, xmlNode);
                    XmlNode attribute = xmlNode.Attributes.GetNamedItem("science_degree");
                    if (attribute != null)
                    {
                        parameters.Add("science_degree", attribute.Value);
                    }
                    attribute = xmlNode.Attributes.GetNamedItem("diploma_protection_year");
                    if (attribute != null)
                    {
                        parameters.Add("diploma_protection_year", attribute.Value);
                    }
                    attribute = xmlNode.Attributes.GetNamedItem("diploma_theme");
                    if (attribute != null)
                    {
                        parameters.Add("diploma_theme", attribute.Value);
                    }
                    List<AcademicSubject> subjects = new List<AcademicSubject>();
                    foreach (XmlNode childNode in xmlNode.ChildNodes)
                    {
                        if (childNode.Name == "subjects")
                        {
                            foreach (XmlNode childOfChild in childNode.ChildNodes)
                            {
                                subjects.AddRange(Subjects.Where(x => x.Id == Convert.ToInt32(childOfChild.Attributes.GetNamedItem("id").Value)));
                            }
                        }
                    }
                    scienceWorkers.Add(new ScienceWorker(Convert.ToInt32(parameters["id"]), parameters["name"], parameters["surname"], Convert.ToInt32(parameters["age"]), Convert.ToInt32(parameters["experience"]), Convert.ToDouble(parameters["loan"]), (AdministrationDuties)Enum.Parse(typeof(AdministrationDuties), parameters["administrational_duties"]), (ScienceDegrees)Enum.Parse(typeof(ScienceDegrees), parameters["science_degree"]), Convert.ToInt32(parameters["diploma_protection_year"]), parameters["diploma_theme"], subjects));
                }
                parameters.Clear();
            }
            return scienceWorkers;
        }
    }
}
