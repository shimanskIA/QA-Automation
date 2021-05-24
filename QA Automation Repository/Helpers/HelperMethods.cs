﻿using HW7.Entities.Departments;
using HW7.Entities.People;
using HW7.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace HW7.Helpers
{
    public static class HelperMethods
    {
        public static void ClearXMLFile(string fileName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//" + fileName);
            XmlElement xmlRoot = xmlDocument.DocumentElement;
            xmlRoot.RemoveAll();
            xmlDocument.Save("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//" + fileName);
        }

        public static void FillXMLElement<T>(XmlDocument xmlDocument, XmlElement groupElement, string elementName, string propertyName, string attributeName, List<T> elements) where T : class
        {
            foreach (var element in elements)
            {
                XmlElement singleElement = xmlDocument.CreateElement(elementName);
                XmlText singleText = xmlDocument.CreateTextNode(element.GetType().GetProperty(propertyName).GetValue(element).ToString());
                XmlAttribute singleAttribute = xmlDocument.CreateAttribute(attributeName);
                singleAttribute.AppendChild(singleText);
                singleElement.Attributes.Append(singleAttribute);
                groupElement.AppendChild(singleElement);
            }
        }

        public static void SaveToFile<T>(List<T> serializables) where T : class
        {
            foreach (var element in serializables)
            {
                if (element.GetType().GetInterfaces().Contains(typeof(ISerializable)))
                {
                    (element as ISerializable).Serialize();
                }
            }
        }
    }
}
