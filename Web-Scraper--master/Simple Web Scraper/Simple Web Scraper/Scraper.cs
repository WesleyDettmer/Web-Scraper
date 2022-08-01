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
            String u;
            String h = "https://";
            Console.WriteLine(h);
            u = Console.ReadLine();
            // Código para "minerar" informação.
            HttpWebRequest r = (HttpWebRequest)WebRequest.Create(h + u);
            HttpWebResponse resposta = (HttpWebResponse)r.GetResponse();

            StreamReader stream = new StreamReader(resposta.GetResponseStream());
            string final_response = stream.ReadToEnd();

            // Seleciona apenas o texto do site.(Não implementado/pronto.)
            //Regex regex = new Regex(@"\w+");
            //Match match = regex.Match(final_response);
            //Console.WriteLine(match.Value);
            // Cria uma Array com a informação retirada do site;
            string[] lines = { final_response };

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