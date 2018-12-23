﻿using Newtonsoft.Json;
using ReportingTasksWinform.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ReportingTasksWinform.Reqests
{
    public class WokrerToProjectRequst
    {
        public static List<WorkerToProject> GetWorkersToProjects()
        {
            HttpWebRequest request;
            HttpWebResponse response;
            string content;
            List<WorkerToProject> workersToProject = new List<WorkerToProject>();
            try
            {
                request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/WorkerToProject/GetAllWorkersToProject");
                response = (HttpWebResponse)request.GetResponse();

                content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                workersToProject = JsonConvert.DeserializeObject<List<WorkerToProject>>(content);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }

            return workersToProject;
        }
        public static bool AddWorkerToProject(WorkerToProject workerToProject)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:56028/api/WorkerToProject/AddWorkerToProject/" + Global.UserId);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(workerToProject);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();

                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.Created)
                {
             
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {

                MessageBox.Show("error", ex.Message.ToString());
                return false;

            }
       
        }


       public static bool UpdateWorkerToProject(WorkerToProject workerToProject)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:56028/api/WorkerToProject/UpdateWorkerToProject");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(workerToProject);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();

                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    {
                        var result = streamReader.ReadToEnd();
                      if(httpResponse.StatusCode==HttpStatusCode.OK)
                        { MessageBox.Show("ok");
                            return true;
                        }
                      else
                        {
                            MessageBox.Show("error");
                            return false;
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("error");
                return false;
            }
        }
    }
}
