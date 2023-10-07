using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CurrencyConvertor
{
    internal class UpdateAppSetting
    {
        public static void AppSetting()
        {
            try
            {
                string json = File.ReadAllText("AppSetting.json");
                UserSecretModel userSecretModel = JsonConvert.DeserializeObject<UserSecretModel>(json);

                Console.WriteLine("Enter Your API Key:");

                string apiKey;
                while (true)
                {
                    apiKey = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(apiKey))
                    {
                        break;
                    }
                    Console.WriteLine("Key Can't be null, Enter Your API Key Again:");
                }

                userSecretModel.ApiKey = apiKey;
                Console.WriteLine("Key sets successfully.");

                string output = JsonConvert.SerializeObject(userSecretModel, Formatting.Indented);
                File.WriteAllText("AppSetting.json", output);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: Appsetting.json file not found");
            }
            catch (JsonException)
            {
                Console.WriteLine("Error in parsing Json");
            }
            catch {
                Console.WriteLine("An Unkown error occured");
            }
        }
    }
    //a75be1adb199cbb48daaaf2eaa30970f
}
