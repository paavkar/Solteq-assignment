using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Solteq_assignment.Server.Models;
using System.Globalization;

namespace Solteq_assignment.Server.Controllers
{
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

            // To get weekly data we can use the Calendar.GetWeekOfYear function to get the week number
            // and then set the week number as currently the month is set
            // Console.WriteLine(calendar.GetWeekOfYear(item.timestamp, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday));
            foreach (var item in objects)
            {
                if (list.Find(listItem => listItem.month == item.timestamp.Month) == null)
                {
                    list.Add(new Item
                    {
                        month = item.timestamp.Month,
                        location = item.locationName,
                        value = item.value
                    });
                }
                else
                {
                    Item foundItem = list.Find(listItem => listItem.month == item.timestamp.Month);
                    foundItem.value += item.value;
                }
            }

            string jsonString = JsonConvert.SerializeObject(list);

            return jsonString;
        }
    }
}
