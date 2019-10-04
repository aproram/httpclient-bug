using Foundation;
using System;
using System.IO;
using System.Net.Http;
using UIKit;

namespace httpclientbug
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            FetchtheJSON();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public async void FetchtheJSON()
        {
            HttpClient client = new HttpClient();

            var Doctor_JSON_From_API = new Uri("https://www.stanfordchildrens.org/api/m/prod-en-doctors.json");
            txtbox1.Text = "Service fetching started..";
            var response = await client.GetAsync(Doctor_JSON_From_API);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStreamAsync();
                //Console.WriteLine("JSON Is Fetched");
                using (var streamReader = new StreamReader(content))
                {
                    var content_json = streamReader.ReadToEnd();
                    //Console.WriteLine("Query Result: " + content_json);
                    txtbox1.Text = content_json;
                }

                //Console.WriteLine(content_string);
            }
        }
    }
}