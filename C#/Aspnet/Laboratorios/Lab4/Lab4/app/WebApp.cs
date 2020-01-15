using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Lab4.app
{
    public class WebApp
    {
        private static string ComentarioArquivo
        {
            get{
                return HttpContext.Current.Server.MapPath("~/comentarios.txt");
            }
        }

        public static void ComentarioIncluir(string nome, string comentario)
        {
            using(var writter = new StreamWriter(ComentarioArquivo, true, Encoding.UTF8))
            {
                writter.WriteLine("{0:dd/MM/yyyy} - {0:HH/mm/ss}", DateTime.Now);
                writter.WriteLine("{0} : {1}\r\n", nome, comentario);
            }
        }

        public static string ComentariosObter()
        {
            string texto = string.Empty;

            if (File.Exists(ComentarioArquivo))
            {
                using (var reader = new StreamReader(ComentarioArquivo))
                {
                    texto = reader.ReadToEnd();
                }
            }
            
            return texto;
        }
    }
}