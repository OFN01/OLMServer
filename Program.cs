using AdvancedDatasetManager;
using OLMServer.OLMData.Structures;
using System.Text;
using System.Text.Json;

namespace OLMServer
{
    using Microsoft.EntityFrameworkCore;
    using OLMServer.OLMData;
    using OLMServer.OLMData.DataBase;

    public class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            var app = builder.Build();

            app.MapControllers();

            Console.Write("Enter mail: omerfaruknehir@yaani.com\n");
            ProgramData.ProgramMail = "omerfaruknehir@yaani.com"; // Console.ReadLine();

            Console.Write("Enter password of mail: ************\n\n");
            ProgramData.ProgramMailPass = "Neden2koltuk"; // Console.ReadLine();

            DataSetManager.Init("Data", "MyDataBase");
            var x = DataSetManager.data["UsersTBL"];
            //DataSetManager.AddDataToTable(new Dictionary<string, dynamic>()
            //{
            //    {"name", "�mer Faruk" },
            //    {"surname", "Nehir" }
            //}, "Users");
            Console.WriteLine(x.length);

            DataSetManager.Init("Data", "OLMDataSet");


            Console.Title = "OLM Server";

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Response.Body.Write(File.ReadAllBytes("Public/Documents/Errors/404.html"));
                    context.Response.ContentType = "text/html";
                    await next();
                }
            });

            app.Run("http://0.0.0.0:80");

            int i = 0;
            string text = "Welcome to program! Press ALT + S for start to the server.";
            string alphabet = "qwertyuopasdfghjklizxcvbnm1234567890";
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    if (Console.ReadKey() == new ConsoleKeyInfo('s', ConsoleKey.S, false, true, false))
                    {
                        Console.Write("\r" + new string(' ', Console.BufferWidth - 0));
                        Console.WriteLine("\rStart");
                        break;
                    }
                }
                for (int vb = 0; vb < text.Length - i; vb++)
                {
                    Console.Write(alphabet[Random.Shared.Next(alphabet.Length - 1)]);
                }
                Console.Write("\r");

                Thread.Sleep(100);

                for (int y = 0; y < i; y++)
                {
                    Console.Write(text[y]);
                }
                i++;
                if (i > text.Length)
                {
                    bool br = false;
                    i = 0;
                    Thread.Sleep(80 * text.Length);
                    Console.Write("\r");
                    for (int va = 0; va < text.Length; va++)
                    {
                        if (Console.KeyAvailable)
                        {
                            if (Console.ReadKey() == new ConsoleKeyInfo('s', ConsoleKey.S, false, true, false))
                            {
                                Console.Write("\r" + new string(' ', Console.BufferWidth - 1));
                                Console.WriteLine("\rStart");
                                br = true;
                                break;
                            }
                        }
                        Console.CursorLeft = text.Length - va;
                        for (int vb = 0; vb < va - i; vb++)
                        {
                            Console.Write(alphabet[Random.Shared.Next(alphabet.Length - 1)]);
                        }
                        Console.CursorLeft = text.Length - va - 1;
                        Thread.Sleep(10);
                    }
                    if (br)
                    {
                        break;
                    }
                    Thread.Sleep(100);
                    Console.Write("\r");
                }
            }   //  !!!!!!!!!!SCIENTIFIC!!!!!DONT OPEN!!!!!XTEMELY GOOD!!!!!!!!!!

            Console.Write("\r" + new string(' ', Console.BufferWidth - 1));
        }
    }
}