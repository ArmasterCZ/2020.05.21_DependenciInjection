using _2020._05._21_DependenciInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace _2020._05._21_DependenciInjection
{
    
    internal class XmlWorker : IXmlWorker
    {
        /// <summary>
        /// Deserialize file to xml
        /// </summary>
        /// <param name="path">cesta k datům</param>
        public T LoadXmlFile<T>(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                T loaded = (T)serializer.Deserialize(reader);
                return loaded;
            }
        }

        /// <summary>
        /// Serialize object to xml file
        /// </summary>
        /// <param name="path">path of new xml</param>
        /// <param name="data">data for serialization</param>
        public void SaveXmlFile(string path, object data)
        {
            path = path.Trim();

            XmlSerializer serializer = new XmlSerializer(data.GetType());
            using (StringWriter sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    serializer.Serialize(writer, data);
                    string xml = sww.ToString();
                    System.IO.File.WriteAllText(path, xml);
                }
            }
        }

        /// <summary>
        /// Deserialize odject from Xml
        /// </summary>
        /// <typeparam name="T">type of deserialized object</typeparam>
        /// <param name="xmlText">text in xml format</param>
        /// <returns>deserialized object</returns>
        public T LoadFromXmlString<T>(string xmlText)
        {
            using (var stringReader = new System.IO.StringReader(xmlText))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
        }

        public object LoadFromXmlString(string xmlText, object obj)
        {
            using (var stringReader = new System.IO.StringReader(xmlText))
            {
                var serializer = new XmlSerializer(obj.GetType());
                return serializer.Deserialize(stringReader);
            }
        }

        /// <summary>
        /// Serialize object to xml string
        /// </summary>
        /// <param name="data">data for serialization</param>
        public string CreateXmlString(object data)
        {
            using (var sw = new System.IO.StringWriter())
            {
                XmlSerializer serializer = new XmlSerializer(data.GetType());
                serializer.Serialize(sw, data);
                return sw.ToString();
            }
        }

        /// <summary>
        /// Format xml string to readeble form
        /// </summary>
        /// <param name="xml">xmt text</param>
        /// <returns>formated xml text</returns>
        public string FormatXmlString(string xmlText)
        {
            try
            {
                XDocument doc = XDocument.Parse(xmlText);
                return doc.ToString();
            }
            catch (Exception)
            {
                return xmlText;
            }
        }


    }
    
}
