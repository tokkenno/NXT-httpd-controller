using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Lib_HTTPd
{
    public class httpd
    {

        private Configure conf = new Configure();

        TcpListener httpServer;

        Thread listeningThread;

        public httpd()
        {
            httpServer = new TcpListener(IPAddress.Any, conf.PORT);
        }

        public Boolean Start()
        {
            try
            {
                httpServer.Start();

                try
                {
                    listeningThread = new Thread(new ThreadStart(StartListen));
                    listeningThread.Start();

                    Messages.log("Escuchando en el puerto " + conf.PORT);
                    return true;
                }
                catch
                {
                    Messages.log("Error al inicializar el servidor");
                    return false;
                }
            }
            catch
            {
                Messages.log("El puerto " + conf.PORT + "ya está en uso");
                return false;
            }
        }

        public Boolean Stop()
        {
            httpServer.Stop();
            return true;
        }

        public void StartListen()
        {
            // Guarda la valided de la peticion actual.
            Boolean valPeticion;

            while (true)
            {
                int iStartPos = 0;
                String sRequest = String.Empty;
                String sHttpVersion = String.Empty;

                // Archivo y directorio requerido en la consulta
                String sRequestedFile = String.Empty;
                String sDirName = String.Empty;

                // Archivo y directorio local
                String sLocalDir = String.Empty;

                // Creamos y Aceptamos una nueva conexion
                Socket listener = httpServer.AcceptSocket();
                valPeticion = true;

                // Si se genera la conexion
                if (listener.Connected)
                {
                    Messages.con("Nueva Conexión -> IP: " + listener.RemoteEndPoint);

                    //Recibimos los datos enviados por el cliente
                    Byte[] bReceive = new Byte[1024];
                    Int32 i = listener.Receive(bReceive, bReceive.Length, 0);

                    //Convertimos la peticion de array de Bytes a String
                    string sBuffer = Encoding.ASCII.GetString(bReceive);

                    //Comprobamos si es una funcion GET
                    if (sBuffer.Substring(0, 3) != "GET")
                    {
                        Messages.con("Petición incorrecta. Cerrando conexión...");
                        listener.Close();
                        valPeticion = false;
                    }

                    if (valPeticion)
                    {
                        // Buscamos una petición HTTP
                        iStartPos = sBuffer.IndexOf("HTTP", 1);


                        // Obtener la versión del HTTP e.j. devolvera "HTTP/1.1"
                        sHttpVersion = sBuffer.Substring(iStartPos, 8);


                        // Extraemos la ruta del archivo pedido
                        sRequest = sBuffer.Substring(0, iStartPos - 1);


                        //Reemplazamos las barras
                        sRequest.Replace("\\", "/");


                        //Si no se pide ningún archivo, establecer como ruta básica el directorio principal del servidor
                        if ((sRequest.IndexOf(".") < 1) && (!sRequest.EndsWith("/")))
                        {
                            sRequest = sRequest + "/";
                        }


                        //Extraemos el nombre del fichero requerido
                        iStartPos = sRequest.LastIndexOf("/") + 1;
                        sRequestedFile = sRequest.Substring(iStartPos);

                        NXTRemoteSC.Manager.HttpCommand(sRequestedFile);


                        //Extraemos el nombre del directorio requerido
                        sDirName = sRequest.Substring(sRequest.IndexOf("/"), sRequest.LastIndexOf("/") - 3);

                        // Establecemos y comprobamos la existencia del directorio
                        if (sDirName == "/")
                            sLocalDir = conf.PATH;
                        else
                        {
                            sLocalDir = conf.PATH + sDirName;
                        }


                        if (sLocalDir[sLocalDir.Length - 1] != '/')
                        {
                            sLocalDir += "/";
                        }

                        if (!Directory.Exists(sLocalDir))
                        {
                            String sErrorMessage = "<html><head><title>Error 404</title></head><body><H2>Error 404! No se ha encontrado el archivo.</H2></body></html>";
                            http_trans.SendHeader(sHttpVersion, "", sErrorMessage.Length, " 404 Not Found", ref listener);
                            http_trans.SendToBrowser(sErrorMessage, ref listener);
                            listener.Close();
                            valPeticion = false;
                        }
                    }

                    if (valPeticion)
                    {
                        // Comprobamos que fichero se debe responder en caso de que no se especifique
                        if (sRequestedFile.Length == 0)
                        {
                            sRequestedFile = "index.html";  //Mejorar si se requiere

                            if (!File.Exists(sLocalDir + sRequestedFile))
                            {
                                String sErrorMessage = "<html><head><title>Error 404</title></head><body><H2>Error 404! No se ha encontrado el archivo.</H2></body></html>";
                                http_trans.SendHeader(sHttpVersion, "", sErrorMessage.Length, " 404 Not Found", ref listener);
                                http_trans.SendToBrowser(sErrorMessage, ref listener);
                                listener.Close();
                                valPeticion = false;
                            }
                        }
                    }

                    if (valPeticion)
                    {
                        Byte[] file = Utils.loadFile(sLocalDir + sRequestedFile);

                        if (file != null)
                        {
                            if (http_trans.SendHeader(sHttpVersion, "text/html", file.Length, " 200 OK", ref listener))
                            {
                                if (!http_trans.SendToBrowser(file, ref listener))
                                {
                                    Messages.con("ERROR: No se pudo enviar el stream de datos");
                                }
                            }
                            else
                            {
                                Messages.con("ERROR: No se pudo enviar el stream de datos de la cabecera");
                            }
                        }
                        else
                        {
                            Messages.con("ERROR: No se pudo responder a la peticion del archivo" + sLocalDir + sRequestedFile + ".");
                        }
                        listener.Close();
                    }
                }
            }
        }
    }
}
