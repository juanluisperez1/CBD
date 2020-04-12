using System;

using System;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace CBD_PROYECTO
{
    partial class Program
    {
        static void Main(string[] args)
        {
            // Establecemos conexion con la base de datos
            var mongoDB = new MongoConnect("Entrega");

            const string collectionName = "Series";

            Console.Title = "Aplicación de consola de Mongo con C#, espermos que os guste...";

            int menuChoice;

            do
            {
                menuChoice = Dialogo.ShowMainMenu();
                switch (menuChoice)
                {
                    case 0: // Add new serie
                        {
                           var elemento = Dialogo.ShowAddNewSerie();

                            mongoDB.insertarElemento(collectionName,elemento);

                            Dialogo.ShowContinueMessage();
                        }
                        break;
                    case 1: // Show serie list
                        {
                            var seriesList = mongoDB.listadoBD<Serie>(collectionName);
                            Dialogo.ShowSerieList(seriesList);

                        }
                        break;
                    case 2: // Update serie info (by ID)
                        {
                            var serieId = Dialogo.ShowUpdateSerie();
                            ObjectId serieIdGuid;
                            bool isValidGuid = ObjectId.TryParse(serieId, out serieIdGuid);
                            if (isValidGuid)
                            {
                                var serie = mongoDB.mostrarElementoPorId<Serie>(collectionName, serieIdGuid);
                                Console.Write($"\n" +
                                    $"Current info\n" +
                                    $"Name: {serie.titulo} \n" +
                                    $"Email: {serie.descripcion}");

                                Console.WriteLine("\n------------------------------------------\n");

                                Console.WriteLine("Enter new full name (leave empty if no changes");
                                var fullName = Console.ReadLine();

                                if (!string.IsNullOrEmpty(fullName) && !string.IsNullOrWhiteSpace(fullName))
                                {
                                    serie.titulo = fullName;
                                }

                                Console.WriteLine("Enter new email (leave empty if no changes");
                                var email = Console.ReadLine();

                                if (!string.IsNullOrEmpty(email) && !string.IsNullOrWhiteSpace(email))
                                {
                                    serie.descripcion = email;
                                }

                                mongoDB.editarElemento<Serie>(collectionName, serie, serieIdGuid);
                            }
                            else
                            {
                                Console.WriteLine($"Exception: '{serieId}' is not a valid Guid!");
                            }

                            Dialogo.ShowContinueMessage();
                        }
                        break;
                    case 3: // Delete serie (by ID)
                        {
                            var serieId = Dialogo.ShowDeleteSerie();

                            ObjectId serieIdGuid;

                            bool isValidGuid = ObjectId.TryParse(serieId, out serieIdGuid);
                            if (isValidGuid)
                            {
                                mongoDB.eliminarElemento<Serie>(collectionName, serieIdGuid);
                            }
                            else
                            {
                                Console.WriteLine($"Exception: '{serieId}' is not a valid Guid!");
                            }


                            Dialogo.ShowContinueMessage();
                        }
                        break;
                }

            } while (menuChoice != 4);


        }
    }
}
