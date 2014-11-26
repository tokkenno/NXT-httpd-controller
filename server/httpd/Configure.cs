using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Xml;
using System.Xml.Linq;

namespace Lib_HTTPd
{
    public class Configure
    {
        private Int16 Port = 80;
        private String Path = "";

        public Configure()
        {
            OnLoad();
        }

        private void OnLoad()
        {
            // Si no existe la carpeta de configuracion o un archivo de configuración, los creamos.
            if (!Directory.Exists("./conf"))
            {
                Directory.CreateDirectory("./conf");
            }

            if (Utils.fileList("./conf").Length < 1)
            {
                createConfigureDefaults();
            }

            // Cargamos los archivos de configuración
            foreach (String ruta in Utils.fileList("./conf"))
            {
                if (ruta.Contains(".xml") || ruta.Contains(".XML"))
                    ReadConf(ruta);
            }
        }

        private void ReadConf(String file)
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(file);

                XmlNodeList Configuration = xmldoc.GetElementsByTagName("Configuration");

                foreach (XmlElement nodo in Configuration)
                {
                    try
                    {
                        XmlNodeList xPort = nodo.GetElementsByTagName("Port");
                        this.Port = System.Convert.ToInt16(xPort[0].InnerText);
                    }
                    catch { }

                    try
                    {
                        XmlNodeList xPath = nodo.GetElementsByTagName("Path");
                        this.Path = xPath[0].InnerText;
                    }
                    catch { }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("\nConfiguration file (" + file + ") not found.");
            }
        }

        private void createConfigureDefaults()
        {
            XDocument miXML = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Configuration",
                    new XElement("Port", "8081"),
                    new XElement("Path", "./serverdir"))
                );

            if (!Directory.Exists("./conf"))
            {
                Directory.CreateDirectory("./conf");
            }

            miXML.Save("./conf/conf.xml");
        }

        public Int16 PORT
        {
            get { return this.Port; }
        }

        public String PATH
        {
            get { return this.Path; }
        }
    }
}
