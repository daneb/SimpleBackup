using System;
using System.IO;
using Newtonsoft.Json;
using SimpleBackup;

namespace ConsoleApplication
{
    public class Program
    {

        public static void Main(string[] args)
        {
            BackupConfig bkp = new BackupConfig();
            string config_file = "./config.json";

            try
            {
                 if (args.Length > 0) 
                {
                    config_file = args[0];
                 }

                bkp = read_configuration_file(config_file);     
                backup_data(bkp.source, bkp.destination);
                Console.WriteLine($"Successfully backed up your data from {bkp.source} to {bkp.destination}");
            }
            catch (System.Exception error)
            {
                Console.WriteLine("Unexpected error " + error.Message);
            }


        }

        private static BackupConfig read_configuration_file(string config_file)
        {
            BackupConfig bkp = new BackupConfig();

            if (File.Exists(config_file))
            {
                bkp = JsonConvert.DeserializeObject<BackupConfig>(File.ReadAllText(config_file));
            }

            return bkp;
        }

        private static void backup_data(string source, string destination)
        {
            string strCmdText;
            strCmdText = $"-rvf {source} {destination}";
            System.Diagnostics.Process.Start("/bin/cp", strCmdText); 
        }
    }
}
