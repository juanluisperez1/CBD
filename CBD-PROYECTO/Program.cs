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
            var mongoDB = new MongoConnect("CBD-GRUPO32-APP");



            const string collectionName = "Series";

            Console.Title = "Aplicación de consola de Mongo con C#, esperemos que os guste...";

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
                            String ser = Console.ReadLine();
                            Serie s = mongoDB.filterByName<Serie>(collectionName, ser);
                            if (s != null)
                            {
                                Dialogo.ShowSerieByName(s);
                            }
                            while (ser == string.Empty || s == null){
                                Console.Write("No tenemos esta serie, introduzca otra: ");
                                     ser = Console.ReadLine();
                                     s = mongoDB.filterByName<Serie>(collectionName, ser);


                                if (ser != string.Empty && s!=null){
                                 
                                    s = mongoDB.filterByName<Serie>(collectionName, ser);
                                    Dialogo.ShowSerieByName(s);


                                }
                            }
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
                                    $"Información Actual\n" +
                                    $"Título: {serie.titulo} \n" +
                                    $"Descripción: {serie.descripcion}");

                                Console.WriteLine("\n------------------------------------------\n");

                                Console.WriteLine("Introduzca un nuevo título (déjalo vacío si no quieres cambios)");
                                var titulo = Console.ReadLine();

                                if (!string.IsNullOrEmpty(titulo) && !string.IsNullOrWhiteSpace(titulo))
                                {
                                    serie.titulo = titulo;
                                }

                                Console.WriteLine("Introduzca una nueva descripción (déjalo vacío si no quieres cambios)");
                                var description = Console.ReadLine();

                                if (!string.IsNullOrEmpty(description) && !string.IsNullOrWhiteSpace(description))
                                {
                                    serie.descripcion = description;
                                }

                                Console.WriteLine("Introduzca una nueva valoración (déjalo vacío si no quieres cambios)");
                                 var valoracion = Console.ReadLine();

                                if (!string.IsNullOrEmpty(valoracion) && !string.IsNullOrWhiteSpace(valoracion))
                                {
                                    double d;
                                    while (!double.TryParse(Console.ReadLine(), out d))
                                    {
                                        Console.Write("El valor ingresado no es válido.\nIngrese un número entero: ");
                                    }

                                    serie.valoracion = d;

                                    
                                }

                                Console.WriteLine("Introduzca una nueva fecha de lanzamiento, según el patrón dd/mm/yyyy: (déjalo vacío si no quieres cambios)");
                                 var fechaLanzamiento = Console.ReadLine();
                                if (!string.IsNullOrEmpty(fechaLanzamiento) && !string.IsNullOrWhiteSpace(fechaLanzamiento)){
                                 
                                DateTime dt;
                                while (!DateTime.TryParseExact(fechaLanzamiento, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                                {
                                    Console.WriteLine("Fecha inválida, por favor inténtalo de nuevo, el formato es dd/MM/yyyy");
                                }
                                       serie.fechaLanzamiento = fechaLanzamiento;

                                }

                                Console.WriteLine("Introduzca el número de temporadas: (déjalo vacío si no quieres cambios)");
                                var temporada = Console.ReadLine();
                                int numero;
                                if (!string.IsNullOrEmpty(temporada) && !string.IsNullOrWhiteSpace(temporada))
                                {
                                    while (!Int32.TryParse(temporada, out numero))
                                    {
                                        Console.Write("El valor ingresado no es válido.\nIngrese un número entero: ");
                                    }
                                    serie.temporada = numero;
                                }

                                Console.WriteLine("Introduzca los actores de la serie: (déjalo vacío si no quieres cambios),\n si quiere introducir presione una tecla y enter");
                                var actor = Console.ReadLine();

                                if (!string.IsNullOrEmpty(actor) && !string.IsNullOrWhiteSpace(actor))
                                {


                                    serie.actores = Dialogo.añadirActor();

                                }


                                mongoDB.editarElemento<Serie>(collectionName, serie, serieIdGuid);
                            }
                            else
                            {
                                Console.WriteLine($"Excepción: '{serieId}' no es un ID de serie válido!");
                            }

                            Dialogo.ShowContinueMessage();
                        }
                        break;
                    case 5: // Elminar serie (by ID)
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
                                Console.WriteLine($"Excepción: '{serieId}' no es un ID de serie válido!");
                            }


                            Dialogo.ShowContinueMessage();
                        }
                        break;
                }

            } while (menuChoice != 6);


        }
    }
}
