using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
namespace ExtractPlayloadFromLogFile
{
    class Program
    {
        static void Main(string[] args)
        {

            try {

                int counter = 0;
                string line;
                string pattern = @"\{(.|\s)*\}";
                string markWord = ">>> POST https://asgard-au-prod.azure-api.net/digicall-aus/";

                string OfferJob = "https://asgard-au-prod.azure-api.net/digicall-aus/offer";
                string StatusJob = "https://asgard-au-prod.azure-api.net/digicall-aus/status";
                string FileJob = "https://asgard-au-prod.azure-api.net/digicall-aus/file";
                string DataJob = "https://asgard-au-prod.azure-api.net/digicall-aus/data";
                string TokenJob = "https://asgard-au-prod.azure-api.net/digicall-aus/token";

                List<string> OfferList = new List<string>();
                List<string> StatusList = new List<string>();
                List<string> FileList = new List<string>();
                List<string> DataList = new List<string>();
                List<string> TokenList = new List<string>();

                string[] JobTypes = { nameof(OfferJob), nameof(StatusJob), nameof(FileJob), nameof(DataJob), nameof(TokenJob) };
                string OutputUrl = @"C:\Users\snira\source\repos\ExtractPlayloadFromLogFile\Output\";
                // Read the file and display it line by line.  
                System.IO.StreamReader file =
                    new System.IO.StreamReader(@"C:\Users\snira\source\repos\ExtractPlayloadFromLogFile\LogFiles\Digicall0114.txt");


                while ((line = file.ReadLine()) != null)
                {
                    //Regex regex = new Regex(string.Format(pattern, line.ToString()), RegexOptions.IgnoreCase);
                    if (line.Contains(markWord))
                    {
                        Regex rx = new Regex(@"\{(.|\s)*\}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                        MatchCollection JsonText = rx.Matches(line);
                        //decide which file to write into
                        if (line.Contains(OfferJob))
                        {
                            if (JsonText.Count != 0)
                            {
                                OfferList.Add(JsonText[0].Value);
                                System.Console.WriteLine(JsonText[0].Value);
                            }

                        }
                        else if (line.Contains(StatusJob))
                        {
                            if (JsonText.Count != 0)
                            {
                                StatusList.Add(JsonText[0].Value);
                                System.Console.WriteLine(JsonText[0].Value);
                            }

                        }
                        else if (line.Contains(FileJob))
                        {
                            if (JsonText.Count != 0)
                            {
                                FileList.Add(JsonText[0].Value);
                                System.Console.WriteLine(JsonText[0].Value);
                            }
                        }
                        else if (line.Contains(DataJob))
                        {
                            if (JsonText.Count != 0)
                            {
                                DataList.Add(JsonText[0].Value);
                                System.Console.WriteLine(JsonText[0].Value);
                            }

                        }
                        else if (line.Contains(TokenJob))
                        {
                            if (JsonText.Count != 0)
                            {
                                TokenList.Add(JsonText[0].Value);
                                System.Console.WriteLine(JsonText[0].Value);
                            }

                        }

                        counter++;
                    }

                }
                File.AppendAllLines(OutputUrl + JobTypes[0] + ".txt", OfferList);
                File.AppendAllLines(OutputUrl + JobTypes[1] + ".txt", StatusList);
                File.AppendAllLines(OutputUrl + JobTypes[2] + ".txt", FileList);
                File.AppendAllLines(OutputUrl + JobTypes[3] + ".txt", DataList);
                File.AppendAllLines(OutputUrl + JobTypes[4] + ".txt", TokenList);
                ZipFile.CreateFromDirectory(OutputUrl, @"C:\Users\snira\source\repos\ExtractPlayloadFromLogFile");
                file.Close();
                System.Console.WriteLine("There were {0} lines.", counter);
                // Suspend the screen.  
                System.Console.ReadLine();



            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message , "error while extracting Json text form logs");
            }

        }
    }
}
