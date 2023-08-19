using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Formats.Asn1;
using System.Globalization;

namespace Solteq_assignment.Server.Controllers
{

    public class Recording
    {
        public DateTime timestamp { get; set; }
        public string reportingGroup { get; set; }
        public string locationName { get; set; }
        public double value { get; set; }
        public string unit { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ConsumptionController : Controller
    {
        // To change the date range, we need to alter the StartTime and EndTime values in the query
        private readonly string url = "https://helsinki-openapi.nuuka.cloud/api/v1.0/EnergyData/Daily/ListByProperty?Record=LocationName&SearchString=1000%20Hakaniemen%20kauppahalli&ReportingGroup=Electricity&StartTime=2019-01-01&EndTime=2019-12-31";

        [HttpGet]
        public string Get()
        {
            // To get statistics from another service as well, we need another set of these, with possible changes to accommodate for how the data is stored there
            // we also need to change the url of which the data is retrieved
            HttpClient client = new();
            var dataString = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            List<Recording> objects = JsonConvert.DeserializeObject<List<Recording>>(dataString);

            string date = DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss");

            using (var writer = new StreamWriter(date + ".csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(objects);
            }

            List<Dictionary<string, double>> list = new List<Dictionary<string, double>>();
            Dictionary<string, double> dict = new Dictionary<string, double>();

            // To get weekly data we can use the Calendar.GetWeekOfYear function to get the week number and then use the week number as
            // a key for the dictionary and otherwise have the same kind of code
            // Console.WriteLine(calendar.GetWeekOfYear(item.timestamp, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday));
            foreach (var item in objects)
            {
                switch (item.timestamp.Month)
                {
                    case 1:
                        if (!dict.ContainsKey("January"))
                        {
                            dict.Add("January", item.value);
                        }
                        else dict["January"] += item.value;
                        break;
                    case 2:
                        if (!dict.ContainsKey("February"))
                        {
                            dict.Add("February", item.value);
                        }
                        else dict["February"] += item.value;
                        break;
                    case 3:
                        if (!dict.ContainsKey("March"))
                        {
                            dict.Add("March", item.value);
                        }
                        else dict["March"] += item.value;
                        break;
                    case 4:
                        if (!dict.ContainsKey("April"))
                        {
                            dict.Add("April", item.value);
                        }
                        else dict["April"] += item.value;
                        break;
                    case 5:
                        if (!dict.ContainsKey("May"))
                        {
                            dict.Add("May", item.value);
                        }
                        else dict["May"] += item.value;
                        break;
                    case 6:
                        if (!dict.ContainsKey("June"))
                        {
                            dict.Add("June", item.value);
                        }
                        else dict["June"] += item.value;
                        break;
                    case 7:
                        if (!dict.ContainsKey("July"))
                        {
                            dict.Add("July", item.value);
                        }
                        else dict["July"] += item.value;
                        break;
                    case 8:
                        if (!dict.ContainsKey("August"))
                        {
                            dict.Add("August", item.value);
                        }
                        else dict["August"] += item.value;
                        break;
                    case 9:
                        if (!dict.ContainsKey("September"))
                        {
                            dict.Add("September", item.value);
                        }
                        else dict["September"] += item.value;
                        break;
                    case 10:
                        if (!dict.ContainsKey("October"))
                        {
                            dict.Add("October", item.value);
                        }
                        else dict["October"] += item.value;
                        break;
                    case 11:
                        if (!dict.ContainsKey("November"))
                        {
                            dict.Add("November", item.value);
                        }
                        else dict["November"] += item.value;
                        break;
                    case 12:
                        if (!dict.ContainsKey("December"))
                        {
                            dict.Add("December", item.value);
                        }
                        else dict["December"] += item.value;
                        break;
                    default:
                        break;
                }
            }

            list.Add(dict);

            string json = JsonConvert.SerializeObject(list);

            return json;
        }
    }
}
