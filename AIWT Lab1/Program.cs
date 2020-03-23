using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace AIWT_Lab1
{
    public static class CSV_to_HTML
    {
        public static void Main(string[] args)
        {
            konwertuj("Import_User_Sample_en.csv", "HTMLImport_User_Sample_en.html");
        }

        public static void konwertuj(string plik_wej, string plik_wyj)
        {
            string[] wiersze = File.ReadAllLines(plik_wej);
            List<string[]> lista = new List<string[]>();
            foreach (string wiersz in wiersze)
            {
                lista.Add(wiersz.Split(','));
            }
            StringBuilder html = new StringBuilder();

            html.Append("<!DOCTYPE html><html><head><style>table{" + "font-family:Times New Roman, Times, serif;border-collapse" + ":collapse;width:100%;}td,th{border:1px solid" + " #dddddd;text-align:center;padding:8px;}tr:nth" + "-child(even){background-color:Orange;}</style></head>");
            html.Append("<body>");
            html.Append("<table>");
            bool pierwszyWiersz = true;

            foreach (string[] wiersz in lista)
            {
                html.Append("<tr>");
                foreach (string zawartosc in wiersz)
                {
                    if (pierwszyWiersz)
                    {
                        html.Append("<th>");
                        html.Append(zawartosc);
                        html.Append("</th>");
                    }
                    else
                    {
                        html.Append("<td>");
                        html.Append(zawartosc);
                        html.Append("</td>");
                    }

                    pierwszyWiersz = false;
                }
                html.Append("</tr>");
            }

            html.Append("</table>");
            html.Append("</body></html>");

            File.WriteAllText(plik_wyj, html.ToString());
        }
    }
}