using System;
using System.IO;
using System.Windows.Forms;

namespace ImageResizer
{
    public class AppConfig
    {
        public string source { get; set; }
        public string destination { get; set; }
        public string width { get; set; }
        public string height { get; set; }

        public AppConfig()
        {
            // Load configurations from the INI file during object creation
            LoadConfig();
        }

        private void LoadConfig()
        {
            string iniFilePath = Path.Combine(Application.StartupPath, "config.ini");

            if (!File.Exists(iniFilePath))
            {
                // Handle the case when the INI file is not found
                // You may want to create a default config or display an error message
                return;
            }

            // Read the INI file line by line
            foreach (string line in File.ReadLines(iniFilePath))
            {
                // Split the line into key-value pairs
                string[] parts = line.Split('=');

                if (parts.Length == 2)
                {
                    // Trim the whitespace from keys and values
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();

                    // Update the configuration properties accordingly
                    switch (key)
                    {
                        case "source":
                            source = value;
                            break;
                        case "destination":
                            destination = value;
                            break;
                        case "width":
                            width = value;
                            break;
                        case "height":
                            height = value;
                            break;
                            // Add more cases for additional settings if needed
                    }
                }
            }
        }
    }
}
