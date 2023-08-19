using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

    public class Item
    {
        public string month { get; set; }
        public string location { get; set; }
        public double value { get; set; }
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
            // To get statistics from another service as well, we need another set of these, the parsing part can be similarly done depending on the format data is stored in the service
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

            List<Item> list = new List<Item>();

            // To get weekly data we can use the Calendar.GetWeekOfYear function to get the week number and then use the week number as
            // a key for the dictionary and otherwise have the same kind of code
            // Console.WriteLine(calendar.GetWeekOfYear(item.timestamp, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday));
            foreach (var item in objects)
            {
                switch (item.timestamp.Month)
                {
                    case 1:
                        if (list.Find(item => item.month == "January") == null)
                        {
                            list.Add(new Item {
                                month = "January",
                                location = item.locationName,
                                value = item.value
                            });
                        }
                        else
                        {
                            Item foundItem = list.Find(item => item.month == "January");
                            foundItem.value += item.value;
                        }
                        break;
                    case 2:
                        if (list.Find(item => item.month == "February") == null)
                        {
                            list.Add(new Item
                            {
                                month = "February",
                                location = item.locationName,
                                value = item.value
                            });
                        }
                        else
                        {
                            Item foundItem = list.Find(item => item.month == "February");
                            foundItem.value += item.value;
                        }

                        break;
                    case 3:
                        if (list.Find(item => item.month == "March") == null)
                        {
                            list.Add(new Item
                            {
                                month = "March",
                                location = item.locationName,
                                value = item.value
                            });
                        }
                        else
                        {
                            Item foundItem = list.Find(item => item.month == "March");
                            foundItem.value += item.value;
                        }

                        break;
                    case 4:
                        if (list.Find(item => item.month == "April") == null)
                        {
                            list.Add(new Item
                            {
                                month = "April",
                                location = item.locationName,
                                value = item.value
                            });
                        }
                        else
                        {
                            Item foundItem = list.Find(item => item.month == "April");
                            foundItem.value += item.value;
                        }
                        break;
                    case 5:
                        if (list.Find(item => item.month == "May") == null)
                        {
                            list.Add(new Item
                            {
                                month = "May",
                                location = item.locationName,
                                value = item.value
                            });
                        }
                        else
                        {
                            Item foundItem = list.Find(item => item.month == "May");
                            foundItem.value += item.value;
                        }
                        break;
                    case 6:
                        if (list.Find(item => item.month == "June") == null)
                        {
                            list.Add(new Item
                            {
                                month = "June",
                                location = item.locationName,
                                value = item.value
                            });
                        }
                        else
                        {
                            Item foundItem = list.Find(item => item.month == "June");
                            foundItem.value += item.value;
                        }
                        break;
                    case 7:
                        if (list.Find(item => item.month == "July") == null)
                        {
                            list.Add(new Item
                            {
                                month = "July",
                                location = item.locationName,
                                value = item.value
                            });
                        }
                        else
                        {
                            Item foundItem = list.Find(item => item.month == "July");
                            foundItem.value += item.value;
                        }
                        break;
                    case 8:
                        if (list.Find(item => item.month == "August") == null)
                        {
                            list.Add(new Item
                            {
                                month = "August",
                                location = item.locationName,
                                value = item.value
                            });
                        }
                        else
                        {
                            Item foundItem = list.Find(item => item.month == "August");
                            foundItem.value += item.value;
                        }
                        break;
                    case 9:
                        if (list.Find(item => item.month == "September") == null)
                        {
                            list.Add(new Item
                            {
                                month = "September",
                                location = item.locationName,
                                value = item.value
                            });
                        }
                        else
                        {
                            Item foundItem = list.Find(item => item.month == "September");
                            foundItem.value += item.value;
                        }
                        break;
                    case 10:
                        if (list.Find(item => item.month == "October") == null)
                        {
                            list.Add(new Item
                            {
                                month = "October",
                                location = item.locationName,
                                value = item.value
                            });
                        }
                        else
                        {
                            Item foundItem = list.Find(item => item.month == "October");
                            foundItem.value += item.value;
                        }
                        break;
                    case 11:
                        if (list.Find(item => item.month == "November") == null)
                        {
                            list.Add(new Item
                            {
                                month = "November",
                                location = item.locationName,
                                value = item.value
                            });
                        }
                        else
                        {
                            Item foundItem = list.Find(item => item.month == "November");
                            foundItem.value += item.value;
                        }
                        break;
                    case 12:
                        if (list.Find(item => item.month == "December") == null)
                        {
                            list.Add(new Item
                            {
                                month = "December",
                                location = item.locationName,
                                value = item.value
                            });
                        }
                        else
                        {
                            Item foundItem = list.Find(item => item.month == "December");
                            foundItem.value += item.value;
                        }
                        break;
                    default:
                        break;
                }
            }

            string jsonString = JsonConvert.SerializeObject(list);

            return jsonString;
        }
    }
}
