using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace Web_scraper
{
    class Scraper
    {
        static void Main(string[] args)
        {
            //
            String urlRequest;
            String h = "https://";
            Console.WriteLine(h);
            urlRequest = Console.ReadLine();
            // Código para "minerar" informação.
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(h + urlRequest);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader stream = new StreamReader(response.GetResponseStream());
            string finalResponse = stream.ReadToEnd();

            // Seleciona apenas o texto do site com expressões regulares.(Não implementado/pronto.)
            //Regex regex = new Regex(@"\w+");
            //Match match = regex.Match(final_response);
            //Console.WriteLine(match.Value);
            // Cria uma Array com a informação retirada do site;
            string[] lines = { finalResponse };

            // Caminho onde o arquivo txt será salvo.(No caso, Desktop.)
            string meulocaltxt =
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Escreve a informação retirada em "ScraperTexto.txt".
            using (StreamWriter outputFile = new StreamWriter(meulocaltxt + @"\ScraperTexto.txt"))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }

            Console.Write("Processo Executado.");
            Console.Read();

        }
    }
}