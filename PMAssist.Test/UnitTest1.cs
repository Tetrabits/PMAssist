using PMAssist.Adaptors;
using PMAssist.Managers;
using PMAssist.Models;
using System.Security.Cryptography.Xml;
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
                Number = 6,
            };

            var project = new Project
            {
                Name = "Essette Upgrade 4.8",
                //Sprints = new List<Sprint> { s }
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
                Number = 7,
                StartsOn = new DateTime(2024, 04, 12),
                EndsOn = new DateTime(2024, 04, 25),
                Duration = 14
            };
            var key = y.PutSprint("essette", x).GetAwaiter().GetResult();

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

            foreach (var item in previous.Where(n => n.Title.Equals("Santosh")).OrderBy(n => n.Title).ThenBy(n => n.Start))
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
            //var sprintManager = new SprintManager();
            //var obj = await sprintManager.GetSprintData("essette20230329", "dsfsdfsdf");
        }

        [Fact]
        public async Task DeserializeProjectData()
        {
            var content = "{\"essette\":{\"name\":\"Essette Upgrade 4.8\",\"sprintduration\":14,\"sprints\":{\"essette20230329\":{\"endsOn\":\"2023-04-11T00:00:00\",\"number\":6,\"startsOn\":\"2023-03-29T00:00:00\"},\"essette20230412\":{\"endsOn\":\"2023-04-25T00:00:00\",\"number\":7,\"startsOn\":\"2023-04-12T00:00:00\"}}}}";
            var projects = JsonSerializer.Deserialize<Dictionary<string, Project>>(content);
        }

        [Fact]
        public async Task DeserializeSprintData()
        {
            var x = "{\"activities\":{\"userId\":{\"activityId\":{\"client\":true}}},\"bugs\":{\"bugId\":{\"rca\":\"rca\",\"userId\":{\"activityId\":{\"client\":true}}}},\"stories\":{\"US5589502\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"670c6a91-4b41-46a8-830c-491c52a367cf\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"670c6a91-4b41-46a8-830c-491c52a367cf\",\"plan\":0.5,\"status\":\"Planned\",\"type\":\"Code Review\",\"what\":\"\"}},\"ohN33v6NBhVv3EA0VjCkLeX5iRG2\":{\"13517e71-1bce-4d77-8221-21c6aece43a7\":{\"actuals\":{\"20230406\":2},\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"13517e71-1bce-4d77-8221-21c6aece43a7\",\"plan\":2,\"status\":\"Completed\",\"type\":\"Analysis\",\"what\":\"\"},\"7753ba05-5b49-4156-8a2e-9c22f677627a\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"7753ba05-5b49-4156-8a2e-9c22f677627a\",\"plan\":1,\"status\":\"Completed\",\"type\":\"Development\",\"what\":\"\"}}},\"US5589505\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"abac03b5-ac80-426a-8d24-544859f97d07\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"abac03b5-ac80-426a-8d24-544859f97d07\",\"plan\":0.5,\"status\":\"Planned\",\"type\":\"Code Review\",\"what\":\"\"}},\"ohN33v6NBhVv3EA0VjCkLeX5iRG2\":{\"26a976da-ce24-46e6-84ea-22272cd25a52\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"26a976da-ce24-46e6-84ea-22272cd25a52\",\"plan\":1,\"status\":\"Completed\",\"type\":\"Development\",\"what\":\"\"},\"571af33c-a937-467b-a900-a0a3f4d336f7\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"571af33c-a937-467b-a900-a0a3f4d336f7\",\"plan\":2,\"status\":\"Completed\",\"type\":\"Analysis\",\"what\":\"\"}}},\"US5589928\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"132e6a7d-5826-4d86-b894-eafdbfe5d412\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"132e6a7d-5826-4d86-b894-eafdbfe5d412\",\"plan\":2,\"status\":\"Planned\",\"type\":\"Analysis\",\"what\":\"\"},\"490889fb-9039-455e-95b3-5eb57af72b28\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"490889fb-9039-455e-95b3-5eb57af72b28\",\"plan\":1,\"status\":\"Planned\",\"type\":\"Development\",\"what\":\"\"}},\"jRgCUw4nuqhdGwXUVKtLpWzwH4O2\":{\"fbf33bbc-92af-4593-8957-f8302e28c342\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"fbf33bbc-92af-4593-8957-f8302e28c342\",\"plan\":0.5,\"status\":\"Planned\",\"type\":\"Code Review\",\"what\":\"\"}}},\"US5590197\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"727ed84b-42d1-4cad-b7ba-7fabda0bfe31\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"727ed84b-42d1-4cad-b7ba-7fabda0bfe31\",\"plan\":0.5,\"status\":\"Planned\",\"type\":\"Code Review\",\"what\":\"\"}},\"ohN33v6NBhVv3EA0VjCkLeX5iRG2\":{\"15b77f9c-296e-47e5-8c98-035c2e1e6efd\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"15b77f9c-296e-47e5-8c98-035c2e1e6efd\",\"plan\":2,\"status\":\"Completed\",\"type\":\"Analysis\",\"what\":\"\"},\"add27ad4-ef5b-400c-979a-1c6c05fc62d2\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"add27ad4-ef5b-400c-979a-1c6c05fc62d2\",\"plan\":1,\"status\":\"Completed\",\"type\":\"Development\",\"what\":\"\"}}},\"US5590199\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"85eaf97e-7372-4eb1-83cf-dfd14bb9e06c\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"85eaf97e-7372-4eb1-83cf-dfd14bb9e06c\",\"plan\":2,\"status\":\"Planned\",\"type\":\"Analysis\",\"what\":\"\"},\"c92ab7f1-b2b8-416e-9dfe-508a574042f5\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"c92ab7f1-b2b8-416e-9dfe-508a574042f5\",\"plan\":1,\"status\":\"Planned\",\"type\":\"Development\",\"what\":\"\"}},\"jRgCUw4nuqhdGwXUVKtLpWzwH4O2\":{\"e7723c78-01ec-453f-b3a2-d0921d9c6811\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"e7723c78-01ec-453f-b3a2-d0921d9c6811\",\"plan\":0.5,\"status\":\"Planned\",\"type\":\"Code Review\",\"what\":\"\"}}},\"US5590637\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"de4a2ce2-d26e-4ca0-b753-58abbbe303be\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"de4a2ce2-d26e-4ca0-b753-58abbbe303be\",\"plan\":1,\"status\":\"Planned\",\"type\":\"Development\",\"what\":\"\"}},\"jRgCUw4nuqhdGwXUVKtLpWzwH4O2\":{\"76ea84eb-2e08-4e15-99df-3c94112640f9\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"76ea84eb-2e08-4e15-99df-3c94112640f9\",\"plan\":0.5,\"status\":\"Planned\",\"type\":\"Code Review\",\"what\":\"\"}}},\"US5593026\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"41ba2681-4c71-483f-8947-34401338d69e\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"41ba2681-4c71-483f-8947-34401338d69e\",\"plan\":2,\"status\":\"Planned\",\"type\":\"Analysis\",\"what\":\"\"}}},\"US5593556\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"498e4ffb-e7dc-4da1-9e41-4fe4ebe30f04\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"498e4ffb-e7dc-4da1-9e41-4fe4ebe30f04\",\"plan\":0.5,\"status\":\"Planned\",\"type\":\"Code Review\",\"what\":\"\"}},\"ohN33v6NBhVv3EA0VjCkLeX5iRG2\":{\"6e98bde0-7ddd-4a28-9d5e-2fd2c629d952\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"6e98bde0-7ddd-4a28-9d5e-2fd2c629d952\",\"plan\":1,\"status\":\"Planned\",\"type\":\"Development\",\"what\":\"\"},\"a7f12faa-3b39-4763-afd3-5ad13bdde296\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"a7f12faa-3b39-4763-afd3-5ad13bdde296\",\"plan\":2,\"status\":\"Planned\",\"type\":\"Analysis\",\"what\":\"\"}}},\"US5593652\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"b6b31969-591f-4d92-8a02-34dc8319b035\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"b6b31969-591f-4d92-8a02-34dc8319b035\",\"plan\":0.5,\"status\":\"Planned\",\"type\":\"Code Review\",\"what\":\"\"}},\"ohN33v6NBhVv3EA0VjCkLeX5iRG2\":{\"1e6df82e-2dad-4486-9893-ecb0f02e2030\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"1e6df82e-2dad-4486-9893-ecb0f02e2030\",\"plan\":2,\"status\":\"Planned\",\"type\":\"Analysis\",\"what\":\"\"},\"6f9e94db-a804-45cc-9759-5884a95678ad\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"6f9e94db-a804-45cc-9759-5884a95678ad\",\"plan\":1,\"status\":\"Planned\",\"type\":\"Development\",\"what\":\"\"}}},\"US5593680\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"fe9380b5-3a34-4296-af4c-e382c6776309\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"fe9380b5-3a34-4296-af4c-e382c6776309\",\"plan\":0.5,\"status\":\"Planned\",\"type\":\"Code Review\",\"what\":\"\"}},\"ohN33v6NBhVv3EA0VjCkLeX5iRG2\":{\"c2da37eb-6536-411a-90c4-62de9cfc6305\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"c2da37eb-6536-411a-90c4-62de9cfc6305\",\"plan\":2,\"status\":\"Planned\",\"type\":\"Analysis\",\"what\":\"\"},\"fadf209b-b018-43a6-b96e-6e0e0f6ce42d\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"fadf209b-b018-43a6-b96e-6e0e0f6ce42d\",\"plan\":1,\"status\":\"Planned\",\"type\":\"Development\",\"what\":\"\"}}},\"US5594019\":{\"ohN33v6NBhVv3EA0VjCkLeX5iRG2\":{\"1ad2c8d1-8664-48e3-9124-9bc2ae06c898\":{\"client\":true,\"closedOn\":\"2023-03-29T00:00:00\",\"createdOn\":\"2023-03-30T00:00:00\",\"id\":\"1ad2c8d1-8664-48e3-9124-9bc2ae06c898\",\"plan\":9,\"status\":\"Planned\",\"type\":\"Development\",\"what\":\"Parser\"},\"68bfc03e-01e8-412b-afe9-5dd372a79e38\":{\"client\":true,\"closedOn\":\"2023-03-29T00:00:00\",\"createdOn\":\"2023-03-30T00:00:00\",\"id\":\"68bfc03e-01e8-412b-afe9-5dd372a79e38\",\"plan\":9,\"status\":\"Planned\",\"type\":\"Development\",\"what\":\"Parser\"}}}}}";

            try
            {
                var y = JsonSerializer.Deserialize<Sprint>(x);
                var sa = new SprintAdaptor();
                var p = sa.Adapt(y);

            }
            catch (Exception ex)
            {

                throw;
            }


            //var sprintManager = new SprintManager();
            //var obj = await sprintManager.GetSprintData("essette20230329", "dsfsdfsdf");
        }


        class Story1
        {
            public string Status { get; set; } = string.Empty;
            public short StoryPoint { get; set; } = 0;
            public Dictionary<string, Dictionary<string, Activity>> Users { get; set; } = new Dictionary<string, Dictionary<string, Activity>>();
        }

        [Fact]
        public async Task DeserializeSprintData1()
        {

            var x = "{\"US5589502\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"670c6a91-4b41-46a8-830c-491c52a367cf\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"670c6a91-4b41-46a8-830c-491c52a367cf\",\"plan\":0.5,\"status\":\"Planned\",\"type\":\"Code Review\",\"what\":\"\"}},\"ohN33v6NBhVv3EA0VjCkLeX5iRG2\":{\"13517e71-1bce-4d77-8221-21c6aece43a7\":{\"actuals\":{\"20230406\":2},\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"13517e71-1bce-4d77-8221-21c6aece43a7\",\"plan\":2,\"status\":\"Completed\",\"type\":\"Analysis\",\"what\":\"\"},\"7753ba05-5b49-4156-8a2e-9c22f677627a\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"7753ba05-5b49-4156-8a2e-9c22f677627a\",\"plan\":1,\"status\":\"Completed\",\"type\":\"Development\",\"what\":\"\"}}},\"US5589505\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"abac03b5-ac80-426a-8d24-544859f97d07\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"abac03b5-ac80-426a-8d24-544859f97d07\",\"plan\":0.5,\"status\":\"Planned\",\"type\":\"Code Review\",\"what\":\"\"}},\"ohN33v6NBhVv3EA0VjCkLeX5iRG2\":{\"26a976da-ce24-46e6-84ea-22272cd25a52\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"26a976da-ce24-46e6-84ea-22272cd25a52\",\"plan\":1,\"status\":\"Completed\",\"type\":\"Development\",\"what\":\"\"},\"571af33c-a937-467b-a900-a0a3f4d336f7\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"571af33c-a937-467b-a900-a0a3f4d336f7\",\"plan\":2,\"status\":\"Completed\",\"type\":\"Analysis\",\"what\":\"\"}}},\"US5589928\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"132e6a7d-5826-4d86-b894-eafdbfe5d412\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"132e6a7d-5826-4d86-b894-eafdbfe5d412\",\"plan\":2,\"status\":\"Planned\",\"type\":\"Analysis\",\"what\":\"\"},\"490889fb-9039-455e-95b3-5eb57af72b28\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"490889fb-9039-455e-95b3-5eb57af72b28\",\"plan\":1,\"status\":\"Planned\",\"type\":\"Development\",\"what\":\"\"}},\"jRgCUw4nuqhdGwXUVKtLpWzwH4O2\":{\"fbf33bbc-92af-4593-8957-f8302e28c342\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"fbf33bbc-92af-4593-8957-f8302e28c342\",\"plan\":0.5,\"status\":\"Planned\",\"type\":\"Code Review\",\"what\":\"\"}}},\"US5590197\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"727ed84b-42d1-4cad-b7ba-7fabda0bfe31\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"727ed84b-42d1-4cad-b7ba-7fabda0bfe31\",\"plan\":0.5,\"status\":\"Planned\",\"type\":\"Code Review\",\"what\":\"\"}},\"ohN33v6NBhVv3EA0VjCkLeX5iRG2\":{\"15b77f9c-296e-47e5-8c98-035c2e1e6efd\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"15b77f9c-296e-47e5-8c98-035c2e1e6efd\",\"plan\":2,\"status\":\"Completed\",\"type\":\"Analysis\",\"what\":\"\"},\"add27ad4-ef5b-400c-979a-1c6c05fc62d2\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"add27ad4-ef5b-400c-979a-1c6c05fc62d2\",\"plan\":1,\"status\":\"Completed\",\"type\":\"Development\",\"what\":\"\"}}},\"US5590199\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"85eaf97e-7372-4eb1-83cf-dfd14bb9e06c\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"85eaf97e-7372-4eb1-83cf-dfd14bb9e06c\",\"plan\":2,\"status\":\"Planned\",\"type\":\"Analysis\",\"what\":\"\"},\"c92ab7f1-b2b8-416e-9dfe-508a574042f5\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"c92ab7f1-b2b8-416e-9dfe-508a574042f5\",\"plan\":1,\"status\":\"Planned\",\"type\":\"Development\",\"what\":\"\"}},\"jRgCUw4nuqhdGwXUVKtLpWzwH4O2\":{\"e7723c78-01ec-453f-b3a2-d0921d9c6811\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"e7723c78-01ec-453f-b3a2-d0921d9c6811\",\"plan\":0.5,\"status\":\"Planned\",\"type\":\"Code Review\",\"what\":\"\"}}},\"US5590637\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"de4a2ce2-d26e-4ca0-b753-58abbbe303be\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"de4a2ce2-d26e-4ca0-b753-58abbbe303be\",\"plan\":1,\"status\":\"Planned\",\"type\":\"Development\",\"what\":\"\"}},\"jRgCUw4nuqhdGwXUVKtLpWzwH4O2\":{\"76ea84eb-2e08-4e15-99df-3c94112640f9\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"76ea84eb-2e08-4e15-99df-3c94112640f9\",\"plan\":0.5,\"status\":\"Planned\",\"type\":\"Code Review\",\"what\":\"\"}}},\"US5593026\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"41ba2681-4c71-483f-8947-34401338d69e\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"41ba2681-4c71-483f-8947-34401338d69e\",\"plan\":2,\"status\":\"Planned\",\"type\":\"Analysis\",\"what\":\"\"}}},\"US5593556\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"498e4ffb-e7dc-4da1-9e41-4fe4ebe30f04\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"498e4ffb-e7dc-4da1-9e41-4fe4ebe30f04\",\"plan\":0.5,\"status\":\"Planned\",\"type\":\"Code Review\",\"what\":\"\"}},\"ohN33v6NBhVv3EA0VjCkLeX5iRG2\":{\"6e98bde0-7ddd-4a28-9d5e-2fd2c629d952\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"6e98bde0-7ddd-4a28-9d5e-2fd2c629d952\",\"plan\":1,\"status\":\"Planned\",\"type\":\"Development\",\"what\":\"\"},\"a7f12faa-3b39-4763-afd3-5ad13bdde296\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"a7f12faa-3b39-4763-afd3-5ad13bdde296\",\"plan\":2,\"status\":\"Planned\",\"type\":\"Analysis\",\"what\":\"\"}}},\"US5593652\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"b6b31969-591f-4d92-8a02-34dc8319b035\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"b6b31969-591f-4d92-8a02-34dc8319b035\",\"plan\":0.5,\"status\":\"Planned\",\"type\":\"Code Review\",\"what\":\"\"}},\"ohN33v6NBhVv3EA0VjCkLeX5iRG2\":{\"1e6df82e-2dad-4486-9893-ecb0f02e2030\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"1e6df82e-2dad-4486-9893-ecb0f02e2030\",\"plan\":2,\"status\":\"Planned\",\"type\":\"Analysis\",\"what\":\"\"},\"6f9e94db-a804-45cc-9759-5884a95678ad\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"6f9e94db-a804-45cc-9759-5884a95678ad\",\"plan\":1,\"status\":\"Planned\",\"type\":\"Development\",\"what\":\"\"}}},\"US5593680\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"fe9380b5-3a34-4296-af4c-e382c6776309\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"fe9380b5-3a34-4296-af4c-e382c6776309\",\"plan\":0.5,\"status\":\"Planned\",\"type\":\"Code Review\",\"what\":\"\"}},\"ohN33v6NBhVv3EA0VjCkLeX5iRG2\":{\"c2da37eb-6536-411a-90c4-62de9cfc6305\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"c2da37eb-6536-411a-90c4-62de9cfc6305\",\"plan\":2,\"status\":\"Planned\",\"type\":\"Analysis\",\"what\":\"\"},\"fadf209b-b018-43a6-b96e-6e0e0f6ce42d\":{\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"fadf209b-b018-43a6-b96e-6e0e0f6ce42d\",\"plan\":1,\"status\":\"Planned\",\"type\":\"Development\",\"what\":\"\"}}},\"US5594019\":{\"ohN33v6NBhVv3EA0VjCkLeX5iRG2\":{\"1ad2c8d1-8664-48e3-9124-9bc2ae06c898\":{\"actuals\":{\"20232903\":4,\"20233003\":8},\"client\":true,\"closedOn\":\"2023-03-29T00:00:00\",\"createdOn\":\"2023-03-30T00:00:00\",\"id\":\"1ad2c8d1-8664-48e3-9124-9bc2ae06c898\",\"plan\":9,\"status\":\"in-progress\",\"type\":\"Development\",\"what\":\"Parser\"},\"63bb74f9-b533-4314-81e7-fbd442dd95b2\":{\"actuals\":{\"20230330\":4},\"client\":true,\"closedOn\":\"2023-03-29T00:00:00\",\"createdOn\":\"2023-03-30T00:00:00\",\"id\":\"63bb74f9-b533-4314-81e7-fbd442dd95b2\",\"plan\":9,\"status\":\"In progress\",\"type\":\"Development\",\"what\":\"Parser\"},\"68bfc03e-01e8-412b-afe9-5dd372a79e38\":{\"client\":true,\"closedOn\":\"2023-03-29T00:00:00\",\"createdOn\":\"2023-03-30T00:00:00\",\"id\":\"68bfc03e-01e8-412b-afe9-5dd372a79e38\",\"plan\":9,\"status\":\"Planned\",\"type\":\"Development\",\"what\":\"Parser\"},\"732c5f8d-15d4-4464-ac62-45d853e3bd29\":{\"actuals\":{\"20230331\":5},\"client\":true,\"closedOn\":\"2023-03-29T00:00:00\",\"createdOn\":\"2023-03-30T00:00:00\",\"id\":\"732c5f8d-15d4-4464-ac62-45d853e3bd29\",\"plan\":9,\"status\":\"In progress\",\"type\":\"Development\",\"what\":\"Parser\"}}}}";

            try
            {
                var s = new Dictionary<string, Story1>();
                var ys = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, Dictionary<string, Activity>>>>(x);
                foreach (var y in ys)
                {
                    var storyId = y.Key;

                    var story1 = new Story1 { Status = "Planned", StoryPoint = 3 };
                    foreach (var u in y.Value)
                    {
                        var userId = u.Key;
                        if (!story1.Users.ContainsKey(userId))
                        {
                            story1.Users.Add(userId, new Dictionary<string, Activity>());
                        }
                        var user = story1.Users[userId];

                        foreach (var v in u.Value)
                        {
                            user.Add(v.Key, v.Value);

                        }
                    }
                    s.Add(storyId, story1);

                }
                //var sa = new SprintAdaptor();
                //var p = sa.Adapt(y);
                var c = JsonSerializer.Serialize(s);
            }
            catch (Exception ex)
            {

                throw;
            }


            //var sprintManager = new SprintManager();
            //var obj = await sprintManager.GetSprintData("essette20230329", "dsfsdfsdf");
        }

        [Fact]
        public async Task DAMatrix()
        {
            var startDate = new DateTime(2023,03,29);
            var endDate = new DateTime(2023,04,11);
            var holidays = new List<DateTime> { new DateTime(2023, 03, 29) };
            var totalNoOfLeaves = 3;

            var content = "{\"activities\":{\"userId\":{\"activityId\":{\"client\":true}}},\"bugs\":{\"bugId\":{\"rca\":\"rca\",\"userId\":{\"activityId\":{\"client\":true}}}},\"status\":\"closed\",\"stories\":{\"US5589502\":{\"Status\":\"Planned\",\"StoryPoint\":3,\"Users\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"670c6a91-4b41-46a8-830c-491c52a367cf\":{\"actual\":0,\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"670c6a91-4b41-46a8-830c-491c52a367cf\",\"linkId\":\"\",\"plan\":0.5,\"status\":\"Planned\",\"type\":\"Code Review\",\"what\":\"\"}},\"ohN33v6NBhVv3EA0VjCkLeX5iRG2\":{\"13517e71-1bce-4d77-8221-21c6aece43a7\":{\"actual\":0,\"actuals\":{\"20230406\":2},\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"13517e71-1bce-4d77-8221-21c6aece43a7\",\"linkId\":\"\",\"plan\":2,\"status\":\"Completed\",\"type\":\"Analysis\",\"what\":\"\"},\"7753ba05-5b49-4156-8a2e-9c22f677627a\":{\"actual\":0,\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"7753ba05-5b49-4156-8a2e-9c22f677627a\",\"linkId\":\"\",\"plan\":1,\"status\":\"Completed\",\"type\":\"Development\",\"what\":\"\"}}}},\"US5589505\":{\"Status\":\"Planned\",\"StoryPoint\":3,\"Users\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"abac03b5-ac80-426a-8d24-544859f97d07\":{\"actual\":0,\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"abac03b5-ac80-426a-8d24-544859f97d07\",\"linkId\":\"\",\"plan\":0.5,\"status\":\"Planned\",\"type\":\"Code Review\",\"what\":\"\"}},\"ohN33v6NBhVv3EA0VjCkLeX5iRG2\":{\"26a976da-ce24-46e6-84ea-22272cd25a52\":{\"actual\":0,\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"26a976da-ce24-46e6-84ea-22272cd25a52\",\"linkId\":\"\",\"plan\":1,\"status\":\"Completed\",\"type\":\"Development\",\"what\":\"\"},\"571af33c-a937-467b-a900-a0a3f4d336f7\":{\"actual\":0,\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"571af33c-a937-467b-a900-a0a3f4d336f7\",\"linkId\":\"\",\"plan\":2,\"status\":\"Completed\",\"type\":\"Analysis\",\"what\":\"\"}}}},\"US5589928\":{\"Status\":\"Planned\",\"StoryPoint\":3,\"Users\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"132e6a7d-5826-4d86-b894-eafdbfe5d412\":{\"actual\":0,\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"132e6a7d-5826-4d86-b894-eafdbfe5d412\",\"linkId\":\"\",\"plan\":2,\"status\":\"Planned\",\"type\":\"Analysis\",\"what\":\"\"},\"490889fb-9039-455e-95b3-5eb57af72b28\":{\"actual\":0,\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"490889fb-9039-455e-95b3-5eb57af72b28\",\"linkId\":\"\",\"plan\":1,\"status\":\"Planned\",\"type\":\"Development\",\"what\":\"\"}},\"jRgCUw4nuqhdGwXUVKtLpWzwH4O2\":{\"fbf33bbc-92af-4593-8957-f8302e28c342\":{\"actual\":0,\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"fbf33bbc-92af-4593-8957-f8302e28c342\",\"linkId\":\"\",\"plan\":0.5,\"status\":\"Planned\",\"type\":\"Code Review\",\"what\":\"\"}}}},\"US5590197\":{\"Status\":\"Planned\",\"StoryPoint\":3,\"Users\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"727ed84b-42d1-4cad-b7ba-7fabda0bfe31\":{\"actual\":0,\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"727ed84b-42d1-4cad-b7ba-7fabda0bfe31\",\"linkId\":\"\",\"plan\":0.5,\"status\":\"Planned\",\"type\":\"Code Review\",\"what\":\"\"}},\"ohN33v6NBhVv3EA0VjCkLeX5iRG2\":{\"15b77f9c-296e-47e5-8c98-035c2e1e6efd\":{\"actual\":0,\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"15b77f9c-296e-47e5-8c98-035c2e1e6efd\",\"linkId\":\"\",\"plan\":2,\"status\":\"Completed\",\"type\":\"Analysis\",\"what\":\"\"},\"add27ad4-ef5b-400c-979a-1c6c05fc62d2\":{\"actual\":0,\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"add27ad4-ef5b-400c-979a-1c6c05fc62d2\",\"linkId\":\"\",\"plan\":1,\"status\":\"Completed\",\"type\":\"Development\",\"what\":\"\"}}}},\"US5590199\":{\"Status\":\"Planned\",\"StoryPoint\":3,\"Users\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"85eaf97e-7372-4eb1-83cf-dfd14bb9e06c\":{\"actual\":0,\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"85eaf97e-7372-4eb1-83cf-dfd14bb9e06c\",\"linkId\":\"\",\"plan\":2,\"status\":\"Planned\",\"type\":\"Analysis\",\"what\":\"\"},\"c92ab7f1-b2b8-416e-9dfe-508a574042f5\":{\"actual\":0,\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"c92ab7f1-b2b8-416e-9dfe-508a574042f5\",\"linkId\":\"\",\"plan\":1,\"status\":\"Planned\",\"type\":\"Development\",\"what\":\"\"}},\"jRgCUw4nuqhdGwXUVKtLpWzwH4O2\":{\"e7723c78-01ec-453f-b3a2-d0921d9c6811\":{\"actual\":0,\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"e7723c78-01ec-453f-b3a2-d0921d9c6811\",\"linkId\":\"\",\"plan\":0.5,\"status\":\"Planned\",\"type\":\"Code Review\",\"what\":\"\"}}}},\"US5590637\":{\"Status\":\"Planned\",\"StoryPoint\":3,\"Users\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"de4a2ce2-d26e-4ca0-b753-58abbbe303be\":{\"actual\":0,\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"de4a2ce2-d26e-4ca0-b753-58abbbe303be\",\"linkId\":\"\",\"plan\":1,\"status\":\"Planned\",\"type\":\"Development\",\"what\":\"\"}},\"jRgCUw4nuqhdGwXUVKtLpWzwH4O2\":{\"76ea84eb-2e08-4e15-99df-3c94112640f9\":{\"actual\":0,\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"76ea84eb-2e08-4e15-99df-3c94112640f9\",\"linkId\":\"\",\"plan\":0.5,\"status\":\"Planned\",\"type\":\"Code Review\",\"what\":\"\"}}}},\"US5593026\":{\"Status\":\"Planned\",\"StoryPoint\":3,\"Users\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"41ba2681-4c71-483f-8947-34401338d69e\":{\"actual\":0,\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"41ba2681-4c71-483f-8947-34401338d69e\",\"linkId\":\"\",\"plan\":2,\"status\":\"Planned\",\"type\":\"Analysis\",\"what\":\"\"}}}},\"US5593556\":{\"Status\":\"Planned\",\"StoryPoint\":3,\"Users\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"498e4ffb-e7dc-4da1-9e41-4fe4ebe30f04\":{\"actual\":0,\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"498e4ffb-e7dc-4da1-9e41-4fe4ebe30f04\",\"linkId\":\"\",\"plan\":0.5,\"status\":\"Planned\",\"type\":\"Code Review\",\"what\":\"\"}},\"ohN33v6NBhVv3EA0VjCkLeX5iRG2\":{\"6e98bde0-7ddd-4a28-9d5e-2fd2c629d952\":{\"actual\":0,\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"6e98bde0-7ddd-4a28-9d5e-2fd2c629d952\",\"linkId\":\"\",\"plan\":1,\"status\":\"Planned\",\"type\":\"Development\",\"what\":\"\"},\"a7f12faa-3b39-4763-afd3-5ad13bdde296\":{\"actual\":0,\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"a7f12faa-3b39-4763-afd3-5ad13bdde296\",\"linkId\":\"\",\"plan\":2,\"status\":\"Planned\",\"type\":\"Analysis\",\"what\":\"\"}}}},\"US5593652\":{\"Status\":\"Planned\",\"StoryPoint\":3,\"Users\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"b6b31969-591f-4d92-8a02-34dc8319b035\":{\"actual\":0,\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"b6b31969-591f-4d92-8a02-34dc8319b035\",\"linkId\":\"\",\"plan\":0.5,\"status\":\"Planned\",\"type\":\"Code Review\",\"what\":\"\"}},\"ohN33v6NBhVv3EA0VjCkLeX5iRG2\":{\"1e6df82e-2dad-4486-9893-ecb0f02e2030\":{\"actual\":0,\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"1e6df82e-2dad-4486-9893-ecb0f02e2030\",\"linkId\":\"\",\"plan\":2,\"status\":\"Planned\",\"type\":\"Analysis\",\"what\":\"\"},\"6f9e94db-a804-45cc-9759-5884a95678ad\":{\"actual\":0,\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"6f9e94db-a804-45cc-9759-5884a95678ad\",\"linkId\":\"\",\"plan\":1,\"status\":\"Planned\",\"type\":\"Development\",\"what\":\"\"}}}},\"US5593680\":{\"Status\":\"Planned\",\"StoryPoint\":3,\"Users\":{\"dIUfOTwVrrRe4lcowYEmxbSTg9L2\":{\"fe9380b5-3a34-4296-af4c-e382c6776309\":{\"actual\":0,\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"fe9380b5-3a34-4296-af4c-e382c6776309\",\"linkId\":\"\",\"plan\":0.5,\"status\":\"Planned\",\"type\":\"Code Review\",\"what\":\"\"}},\"ohN33v6NBhVv3EA0VjCkLeX5iRG2\":{\"c2da37eb-6536-411a-90c4-62de9cfc6305\":{\"actual\":0,\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"c2da37eb-6536-411a-90c4-62de9cfc6305\",\"linkId\":\"\",\"plan\":2,\"status\":\"Planned\",\"type\":\"Analysis\",\"what\":\"\"},\"fadf209b-b018-43a6-b96e-6e0e0f6ce42d\":{\"actual\":0,\"client\":true,\"closedOn\":\"0001-01-01T00:00:00\",\"createdOn\":\"2023-04-05T00:00:00\",\"id\":\"fadf209b-b018-43a6-b96e-6e0e0f6ce42d\",\"linkId\":\"\",\"plan\":1,\"status\":\"Planned\",\"type\":\"Development\",\"what\":\"\"}}}},\"US5594019\":{\"Status\":\"Planned\",\"StoryPoint\":3,\"Users\":{\"ohN33v6NBhVv3EA0VjCkLeX5iRG2\":{\"1ad2c8d1-8664-48e3-9124-9bc2ae06c898\":{\"actual\":0,\"actuals\":{\"20232903\":4,\"20233003\":8},\"client\":true,\"closedOn\":\"2023-03-29T00:00:00\",\"createdOn\":\"2023-03-30T00:00:00\",\"id\":\"1ad2c8d1-8664-48e3-9124-9bc2ae06c898\",\"linkId\":\"\",\"plan\":9,\"status\":\"in-progress\",\"type\":\"Development\",\"what\":\"Parser\"},\"63bb74f9-b533-4314-81e7-fbd442dd95b2\":{\"actual\":0,\"actuals\":{\"20230330\":4},\"client\":true,\"closedOn\":\"2023-03-29T00:00:00\",\"createdOn\":\"2023-03-30T00:00:00\",\"id\":\"63bb74f9-b533-4314-81e7-fbd442dd95b2\",\"linkId\":\"\",\"plan\":9,\"status\":\"In progress\",\"type\":\"Development\",\"what\":\"Parser\"},\"68bfc03e-01e8-412b-afe9-5dd372a79e38\":{\"actual\":0,\"client\":true,\"closedOn\":\"2023-03-29T00:00:00\",\"createdOn\":\"2023-03-30T00:00:00\",\"id\":\"68bfc03e-01e8-412b-afe9-5dd372a79e38\",\"linkId\":\"\",\"plan\":9,\"status\":\"Planned\",\"type\":\"Development\",\"what\":\"Parser\"},\"732c5f8d-15d4-4464-ac62-45d853e3bd29\":{\"actual\":0,\"actuals\":{\"20230331\":5},\"client\":true,\"closedOn\":\"2023-03-29T00:00:00\",\"createdOn\":\"2023-03-30T00:00:00\",\"id\":\"732c5f8d-15d4-4464-ac62-45d853e3bd29\",\"linkId\":\"\",\"plan\":9,\"status\":\"In progress\",\"type\":\"Development\",\"what\":\"Parser\"}}}}}}";

            var sprint = JsonSerializer.Deserialize<Sprint>(content);
            
            var duration = Math.Ceiling(sprint.Duration / 7.0).ToString();
            var res = new List<string>();
            var totalPlanned = 0.0;
            var actualEffort = 0.0;
            var reworkEffort = 0.0;
            var storyPlanned = 0;
            var storyBaselined = 0;
            var storyDelivered = 0;

            foreach (var story in sprint.Stories) 
            {
                if (story.Value.Created.Date == startDate)
                {
                    storyPlanned++;

                    if (story.Value.Points > 0)
                        storyBaselined++;
                    
                }

                if (story.Value.Status == "Closed")
                {
                    storyDelivered++;
                }

                foreach (var user in story.Value.Users) 
                {
                    if (!res.Contains(user.Key))
                        res.Add(user.Key);
                    foreach(var activity in user.Value) 
                    {
                        var activityId = activity.Key;
                        totalPlanned += activity.Value.Plan;
                        actualEffort+= activity.Value.Actuals.Sum(n=>n.Value);
                        if (activity.Value.Type == "Rework")
                        {
                            reworkEffort+= activity.Value.Actuals.Sum(n => n.Value);
                        }
                    }
                }                
            }

            foreach(var user in sprint.Activities)
            {
                if(!res.Contains(user.Key))
                    res.Add(user.Key);
                
                foreach (var activity in user.Value)
                {
                    var activityId = activity.Key;
                    totalPlanned += activity.Value.Plan;
                    actualEffort += activity.Value.Actuals.Sum(n => n.Value);
                    if (activity.Value.Type == "Rework")
                    {
                        reworkEffort += activity.Value.Actuals.Sum(n => n.Value);
                    }
                }
            }

            var numberOfResources = res.Count ;

            var totalWorkDay = 0;
            for (var i = startDate; i <= endDate; i=i.AddDays(1))
            {
                if(!(i.DayOfWeek == DayOfWeek.Sunday || i.DayOfWeek==DayOfWeek.Saturday || holidays.Contains(i)))
                {
                    totalWorkDay++;
                }
            }

            var effortCapacity = ((totalWorkDay * numberOfResources) - totalNoOfLeaves) * 8;
            var effortPlanned = totalPlanned;
            var effortActual = actualEffort;
            var effortRework = reworkEffort;
            
            
            
            var storyAccepted = string.Empty;
            var storyQATested = string.Empty;
            var storyModified = string.Empty;
            var storyPointPlanned = string.Empty;
            var storyPointBaselined = string.Empty;
            var storyPointDelivered = string.Empty;
            var storyPointAccepted = string.Empty;
            var codeReviewInternal = string.Empty;
            var codeReviewExternal = string.Empty;
            var defectQA = string.Empty;
            var defectUAT = string.Empty;
            var defectProduction = string.Empty;
            var defectReopened = string.Empty;
            var unitTestCoverage = string.Empty;



        }
    }
}
