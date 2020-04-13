using System;

using System;
using System.Globalization;
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
                                    $"Título: {serie.titulo} \n" +
                                    $"Descripción: {serie.descripcion}");

                                Console.WriteLine("\n------------------------------------------\n");

                                Console.WriteLine("Introduzca un nuevo título (leave empty if no changes");
                                var titulo = Console.ReadLine();

                                if (!string.IsNullOrEmpty(titulo) && !string.IsNullOrWhiteSpace(titulo))
                                {
                                    serie.titulo = titulo;
                                }

                                Console.WriteLine("Introduzca una nueva descripcion (leave empty if no changes");
                                var description = Console.ReadLine();

                                if (!string.IsNullOrEmpty(description) && !string.IsNullOrWhiteSpace(description))
                                {
                                    serie.descripcion = description;
                                }

                                Console.WriteLine("Introduzca una nueva valoracion (leave empty if no changes");
                                var valoracion = Console.ReadLine();

                                if (!string.IsNullOrEmpty(valoracion) && !string.IsNullOrWhiteSpace(valoracion))
                                {

                                    serie.valoracion = Double.Parse(valoracion); 
                                }

                                Console.WriteLine("Introduzca una nueva fecha de Lanzamiento, según el patrón dd-mm-yyyy: (leave empty if no changes");
                                var fechaLanzamiento = Console.ReadLine();

                                if (!string.IsNullOrEmpty(fechaLanzamiento) && !string.IsNullOrWhiteSpace(fechaLanzamiento))
                                {

                                    serie.fechaLanzamiento = DateTime.ParseExact(fechaLanzamiento,
                                            "dd-MM-yyyy",
                                            CultureInfo.InvariantCulture);
                                }


                                Console.WriteLine("Introduzca el número de temporadas: (leave empty if no changes");
                                var temporadas = Console.ReadLine();

                                if (!string.IsNullOrEmpty(temporadas) && !string.IsNullOrWhiteSpace(temporadas))
                                {

                                    serie.temporada = Convert.ToInt32(Console.ReadLine());
                                }


                                Console.WriteLine("Introduzca los atores de la serie: (leave empty if no changes");

                                
                                    serie.actores = Dialogo.añadirActor();
                                



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
