using Plugin.CloudFirestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatApp.Pages
{
    public class Randomizer
    {
        private static Random random = new Random();
        public static string[] ids = { };
        
        [Obsolete]
        public async void checkID()
        {
            var documents = await CrossCloudFirestore.Current
                                  .Instance
                                  .GetCollection("contacts")
                                  .GetDocumentsAsync();

            var model = documents.ToObjects<ContactModel>();

            foreach (var data in model)
            {
                int x = 0;
                ids[x++] = data.id;
            }
        }
        [Obsolete]
        public static string generateID()
        {
            string id = generateString();

            return id;
        }

        public static string generateString()
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(characters, 10)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
