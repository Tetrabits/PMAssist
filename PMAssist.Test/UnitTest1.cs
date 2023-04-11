using PMAssist.Managers;
using PMAssist.Models;
using System.Text.Json;

namespace PMAssist.Test
{
    public class UnitTest1
    {
        [Fact]
        public void BaseData()
        {
            var s = new Sprint
            {
                StartsOn = new DateTime(2023, 03, 29),
                EndsOn = new DateTime(2023, 04, 11),
                SprintNumber = 6,
            };

            var project = new Project
            {
                Name = "Essette Upgrade 4.8",
                Sprints = new List<Sprint> { s }
            };

            var content = JsonSerializer.Serialize(project);

            //var x = new ProjectManager();
            //var key = x.GetSprintKey("essette", new DateTime(2023, 3, 30)).GetAwaiter().GetResult();

        }

        [Fact]
        public void AddSprint()
        {
            //var s = new Sprint
            //{
            //    StartsOn = new DateTime(2023, 03, 29),
            //    EndsOn = new DateTime(2023, 04, 11),
            //    SprintNumber = 6,
            //};

            //var project = new Project
            //{
            //    Name = "Essette Upgrade 4.8",
            //    Sprints = new List<Sprint> { s }
            //};

            //var content = JsonSerializer.Serialize(project);
            var y = new ProjectManager();
            var x = new Sprint
            {
                SprintNumber = 7,
                StartsOn = new DateTime(2024,04,12),
                EndsOn = new DateTime(2024, 04, 25),
                Duration = 14
            };
            var key = y.PutSprint("essette",x ).GetAwaiter().GetResult();

        }

        [Fact]
        public void Test1()
        {
            var x = "[{\"ID\":\"20230227|ykMAMMJFHcbrejMH6X234ntl1952\",\"Start\":\"2023-02-27T00:00:00\",\"End\":\"2023-02-27T00:00:00\",\"AllDay\":true,\"Title\":\"Santosh\"},{\"ID\":\"20230228|ykMAMMJFHcbrejMH6X234ntl1952\",\"Start\":\"2023-02-28T00:00:00\",\"End\":\"2023-02-28T00:00:00\",\"AllDay\":true,\"Title\":\"Santosh\"},{\"ID\":\"20230306|5niN9sfEzZeGS5ZUM3GlVuqVKoX2\",\"Start\":\"2023-03-06T00:00:00\",\"End\":\"2023-03-06T00:00:00\",\"AllDay\":true,\"Title\":\"Hari\"},{\"ID\":\"20230307|5niN9sfEzZeGS5ZUM3GlVuqVKoX2\",\"Start\":\"2023-03-07T00:00:00\",\"End\":\"2023-03-07T00:00:00\",\"AllDay\":true,\"Title\":\"Hari\"},{\"ID\":\"20230308|5niN9sfEzZeGS5ZUM3GlVuqVKoX2\",\"Start\":\"2023-03-08T00:00:00\",\"End\":\"2023-03-08T00:00:00\",\"AllDay\":true,\"Title\":\"Hari\"},{\"ID\":\"20230309|5niN9sfEzZeGS5ZUM3GlVuqVKoX2\",\"Start\":\"2023-03-09T00:00:00\",\"End\":\"2023-03-09T00:00:00\",\"AllDay\":true,\"Title\":\"Hari\"},{\"ID\":\"20230310|5niN9sfEzZeGS5ZUM3GlVuqVKoX2\",\"Start\":\"2023-03-10T00:00:00\",\"End\":\"2023-03-10T00:00:00\",\"AllDay\":true,\"Title\":\"Hari\"},{\"ID\":\"20230313|5niN9sfEzZeGS5ZUM3GlVuqVKoX2\",\"Start\":\"2023-03-13T00:00:00\",\"End\":\"2023-03-13T00:00:00\",\"AllDay\":true,\"Title\":\"Hari\"},{\"ID\":\"20230314|5niN9sfEzZeGS5ZUM3GlVuqVKoX2\",\"Start\":\"2023-03-14T00:00:00\",\"End\":\"2023-03-14T00:00:00\",\"AllDay\":true,\"Title\":\"Hari\"},{\"ID\":\"20230315|5niN9sfEzZeGS5ZUM3GlVuqVKoX2\",\"Start\":\"2023-03-15T00:00:00\",\"End\":\"2023-03-15T00:00:00\",\"AllDay\":true,\"Title\":\"Hari\"},{\"ID\":\"20230329|5niN9sfEzZeGS5ZUM3GlVuqVKoX2\",\"Start\":\"2023-03-29T00:00:00\",\"End\":\"2023-03-29T00:00:00\",\"AllDay\":true,\"Title\":\"Hari\"},{\"ID\":\"20230316|ED17HoP7ZWc24S8LPbV3tjEPo5d2\",\"Start\":\"2023-03-16T00:00:00\",\"End\":\"2023-03-16T00:00:00\",\"AllDay\":true,\"Title\":\"Suhaib\"},{\"ID\":\"20230317|ED17HoP7ZWc24S8LPbV3tjEPo5d2\",\"Start\":\"2023-03-17T00:00:00\",\"End\":\"2023-03-17T00:00:00\",\"AllDay\":true,\"Title\":\"Suhaib\"},{\"ID\":\"20230323|ED17HoP7ZWc24S8LPbV3tjEPo5d2\",\"Start\":\"2023-03-23T00:00:00\",\"End\":\"2023-03-23T00:00:00\",\"AllDay\":true,\"Title\":\"Suhaib\"},{\"ID\":\"20230315|jRgCUw4nuqhdGwXUVKtLpWzwH4O2\",\"Start\":\"2023-03-15T00:00:00\",\"End\":\"2023-03-15T00:00:00\",\"AllDay\":true,\"Title\":\"Gajanan\"},{\"ID\":\"20230320|jRgCUw4nuqhdGwXUVKtLpWzwH4O2\",\"Start\":\"2023-03-20T00:00:00\",\"End\":\"2023-03-20T00:00:00\",\"AllDay\":true,\"Title\":\"Gajanan\"},{\"ID\":\"20230321|jRgCUw4nuqhdGwXUVKtLpWzwH4O2\",\"Start\":\"2023-03-21T00:00:00\",\"End\":\"2023-03-21T00:00:00\",\"AllDay\":true,\"Title\":\"Gajanan\"},{\"ID\":\"20230322|jRgCUw4nuqhdGwXUVKtLpWzwH4O2\",\"Start\":\"2023-03-22T00:00:00\",\"End\":\"2023-03-22T00:00:00\",\"AllDay\":true,\"Title\":\"Gajanan\"},{\"ID\":\"20230323|jRgCUw4nuqhdGwXUVKtLpWzwH4O2\",\"Start\":\"2023-03-23T00:00:00\",\"End\":\"2023-03-23T00:00:00\",\"AllDay\":true,\"Title\":\"Gajanan\"},{\"ID\":\"20230324|jRgCUw4nuqhdGwXUVKtLpWzwH4O2\",\"Start\":\"2023-03-24T00:00:00\",\"End\":\"2023-03-24T00:00:00\",\"AllDay\":true,\"Title\":\"Gajanan\"},{\"ID\":\"20230327|jRgCUw4nuqhdGwXUVKtLpWzwH4O2\",\"Start\":\"2023-03-27T00:00:00\",\"End\":\"2023-03-27T00:00:00\",\"AllDay\":true,\"Title\":\"Gajanan\"},{\"ID\":\"20230328|jRgCUw4nuqhdGwXUVKtLpWzwH4O2\",\"Start\":\"2023-03-28T00:00:00\",\"End\":\"2023-03-28T00:00:00\",\"AllDay\":true,\"Title\":\"Gajanan\"},{\"ID\":\"20230329|jRgCUw4nuqhdGwXUVKtLpWzwH4O2\",\"Start\":\"2023-03-29T00:00:00\",\"End\":\"2023-03-29T00:00:00\",\"AllDay\":true,\"Title\":\"Gajanan\"},{\"ID\":\"20230330|jRgCUw4nuqhdGwXUVKtLpWzwH4O2\",\"Start\":\"2023-03-30T00:00:00\",\"End\":\"2023-03-30T00:00:00\",\"AllDay\":true,\"Title\":\"Gajanan\"},{\"ID\":\"20230331|jRgCUw4nuqhdGwXUVKtLpWzwH4O2\",\"Start\":\"2023-03-31T00:00:00\",\"End\":\"2023-03-31T00:00:00\",\"AllDay\":true,\"Title\":\"Gajanan\"},{\"ID\":\"20230301|ykMAMMJFHcbrejMH6X234ntl1952\",\"Start\":\"2023-03-01T00:00:00\",\"End\":\"2023-03-01T00:00:00\",\"AllDay\":true,\"Title\":\"Santosh\"},{\"ID\":\"20230309|ykMAMMJFHcbrejMH6X234ntl1952\",\"Start\":\"2023-03-09T00:00:00\",\"End\":\"2023-03-09T00:00:00\",\"AllDay\":true,\"Title\":\"Santosh\"}]";

            var previous = JsonSerializer.Deserialize<List<EventApi>>(x) ?? new List<EventApi>();

            var final = new List<EventApi>();
            var title = string.Empty;
            var currentDate = DateTime.Today;
            EventApi? leave = null;

            foreach (var item in previous.Where(n=>n.Title.Equals("Santosh")).OrderBy(n => n.Title).ThenBy(n => n.Start))
            {
                if (item.Title.Equals(title))
                {
                    //This is the same person
                    var date1 = (item.Start ?? DateTime.MinValue).Date;
                    if (date1 == currentDate.AddDays(1))
                    {
                        if (leave != null)
                        {
                            leave.End = new DateTime(date1.Year, date1.Month, date1.Day, 23, 59, 59);
                        }
                        currentDate = date1;
                    }
                    else
                    {
                        if (leave != null)
                        {
                            leave.End = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 23, 59, 59);
                            final.Add(leave);
                        }

                        leave = new EventApi
                        {
                            ID = item.ID,
                            AllDay = item.AllDay,
                            Title = item.Title,
                            Start = item.Start,
                            End = item.End
                        };

                        title = item.Title;
                        currentDate = item.Start ?? DateTime.MinValue;
                    }
                }
                else
                {
                    //Person has changed, Add the leave info and then create a Leave Object
                    if (leave != null)
                    {
                        leave.End = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 23, 59, 59);
                        final.Add(leave);
                    }

                    leave = new EventApi
                    {
                        ID = item.ID,
                        AllDay = item.AllDay,
                        Title = item.Title,
                        Start = item.Start,
                        End = item.End
                    };

                    title = item.Title;
                    currentDate = item.Start ?? DateTime.MinValue;
                }
            }

        }

        [Fact]
        public async Task Test_SprintData()
        {
            var sprintManager = new SprintManager();
            var obj = await sprintManager.GetSprintData("essette20230329", "dsfsdfsdf");
        }

    }
}
