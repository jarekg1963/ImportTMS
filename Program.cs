using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using c_;
using Nest;
namespace c_
{
    class Program
    {

        static string url = "http://localhost:9200/testy/shipment/";

        static void Main(string[] args)
        {



            string responseString = string.Empty;
            using (var webClient = new WebClient())
            {
                string tmsUrlBezDaty = "http://tpvlogistics.eu/mmd/DashBoard_1.php?date=";

                DateTime dataPoczatkowa = DateTime.Now;
                

                // DateTime dataPoczatkowa = Convert.ToDateTime("2019-01-01");

                

                while (dataPoczatkowa <= DateTime.Now)

                {

                    var cl1 = new System.Net.WebClient();

                    cl1.Headers.Clear();
                    cl1.Headers.Add("Content-Type", "application/json");

                    string baseUrl = tmsUrlBezDaty + dataPoczatkowa.ToString("yyyy-MM-dd");

                    var clt = new System.Net.WebClient();
                    responseString = clt.DownloadString(baseUrl);

                    List<ShipmentImport> TablicaShipmentow = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ShipmentImport>>(responseString);


                    for (int i = 0; i < TablicaShipmentow.LongCount(); i++)
                    {
                        var clkabana = new System.Net.WebClient();
                        clkabana.Headers.Clear();
                        clkabana.Headers.Add("Content-Type", "application/json");
                        string zmId;
                        zmId = TablicaShipmentow[i].ID_UNIQUE;
                        Console.WriteLine(zmId);
                        TablicaShipmentow[i].DATA = dataPoczatkowa;
                        var json = Newtonsoft.Json.JsonConvert.SerializeObject(TablicaShipmentow[i]);
                        var url1 = url + zmId;
                        clkabana.UploadData(url1, "POST", System.Text.UTF8Encoding.UTF8.GetBytes(json));

                    }
                    dataPoczatkowa = dataPoczatkowa.Add(new TimeSpan(864000000000));
                     Console.WriteLine(dataPoczatkowa);
                }

            }


        }


    }
}

            //  getShipmentValues();



            // SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            // builder.DataSource = "DESKTOP-M9PRPPC\\MSSQLSERVER01";   // update me
            // builder.IntegratedSecurity = true;

            // builder.InitialCatalog = "TMS";
            // Console.Write("Connecting to SQL Server ... ");
            // using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            // {
            //     connection.Open();
            //     String sql = "SELECT * FROM TmsShipments;";
            //     using (SqlCommand command = new SqlCommand(sql, connection))
            //     {
            //         using (SqlDataReader reader = command.ExecuteReader())
            //         {
            //             while (reader.Read())
            //             {
            //                 var item = new Dictionary<string, object>(reader.FieldCount - 1);
            //                 for (var i = 0; i < reader.FieldCount; i++)
            //                 {
            //                     // item[reader.GetName(i)] = $"{ reader.GetValue(i)}".Trim();
            //                     item[reader.GetName(i)] = reader.GetValue(i);
            //                 }
            //                 var json = Newtonsoft.Json.JsonConvert.SerializeObject(item);
            //                 var cl = new System.Net.WebClient();
            //                 System.Console.WriteLine(json);
            //                 cl.Headers.Clear();
            //                 cl.Headers.Add("Content-Type", "application/json");
            //                 var url1 = url + reader.GetValue(0).ToString();
            //                 System.Console.WriteLine(url1);
            //                 cl.UploadData(url1, "POST", System.Text.UTF8Encoding.UTF8.GetBytes(json));
            //             }
            //         }
            //     }

            // }







// ----------------------------------------------------------------------------------------------

// Nowa funkcja wykorzystujaca entity framework 


// private static void getShipmentValues()
// {
//     System.Console.WriteLine("Loading custom values");

//     using (var db = new ShipmentContext())
//     {
//         List<Shipment> shipmentValues = db.Shipments.ToList();
//         foreach (Shipment val in shipmentValues)
//         {
//             var content = Newtonsoft.Json.JsonConvert.SerializeObject(val);
//             System.Console.WriteLine($"Uploading data id: {val.id}");
//             var cl = new System.Net.WebClient();
//             cl.Headers.Clear();
//             cl.Headers.Add("Content-Type", "application/json");
//             cl.UploadData(url + val.id.ToString(), "POST", System.Text.UTF8Encoding.UTF8.GetBytes(content));

//         }

//     }
// }


//-----------------------------------------------------------------------------------
// Poczatek funkcji do czytania z Shipmentow TMS 

// string responseString = string.Empty;
//     using (var webClient = new WebClient())
//     {
//         string tmsUrlBezDaty = "http://tpvlogistics.eu/mmd/DashBoard_1.php?date=";
//         DateTime dataPoczatkowa = Convert.ToDateTime("2019-10-07");
//         string baseUrl = tmsUrlBezDaty + dataPoczatkowa.ToString("yyyy-MM-dd");
//         var clt = new System.Net.WebClient();
//         responseString = clt.DownloadString(baseUrl);
//         Console.Write(responseString);
//         List<ShipmentImport> TablicaShipmentow = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ShipmentImport>>(responseString);
//          var cl = new System.Net.WebClient();
//         cl.Headers.Clear();
//         cl.Headers.Add("Content-Type", "application/json");
//         for (int i = 0; i < TablicaShipmentow.LongCount(); i++)
//         {
//             string zmName;
//             zmName = TablicaShipmentow[i].NAME.Replace('"', ' ').Replace(',', ' ');
//         }

//     }





