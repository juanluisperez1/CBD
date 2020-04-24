using System;

using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
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
                    case 2: // Show filter name
                        {

                            Dialogo.ShowSerieByName1();
                            
                            
                            String ser= Console.ReadLine();
                            


                          Serie s=  mongoDB.filterByName<Serie>(collectionName, ser);
                            while (s == null)
                            {
                                Console.Write("No tenemos esta serie, introduzca otra: ");
                                String ser2 = Console.ReadLine();
                                Serie s2 = mongoDB.filterByName<Serie>(collectionName, ser2);
                            
                            if(s2!=null)
                                Dialogo.ShowSerieByName(s2);

                            }

                            Dialogo.ShowSerieByName(s);

                        }
                        break;


                    case 3: // Show serie list mejores
                        {
                            var seriesList = mongoDB.listadoBestBD<Serie>(collectionName);
                           
                            
                            Dialogo.ShowSerieListMejores(seriesList);

                        }
                        break;


                    case 4: // Update serie info (by ID)
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
                                serie.fechaLanzamiento = Console.ReadLine();
                                DateTime dt;
                                while (!DateTime.TryParseExact(serie.fechaLanzamiento, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                                {
                                    Console.WriteLine("Invalid date, please retry");
                                    serie.fechaLanzamiento = Console.ReadLine();
                                }


                                Console.WriteLine("Introduzca el número de temporadas: (leave empty if no changes");
                                int numero;

                                while (!Int32.TryParse(Console.ReadLine(), out numero))
                                {
                                    Console.Write("El valor ingresado no es válido.\nIngrese un número entero: ");
                                }

                                Console.WriteLine("Introduzca los actores de la serie: (leave empty if no changes), si quiere introducir presine una tecla y enter");
                                var actor = Console.ReadLine();

                                if (!string.IsNullOrEmpty(actor) && !string.IsNullOrWhiteSpace(actor))
                                {


                                    serie.actores = Dialogo.añadirActor();

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
                    case 5: // Delete serie (by ID)
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

            } while (menuChoice != 6);


        }
    }
}
