using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CBD_PROYECTO
{
    class Dialogo
    {
        /// <summary>
        /// Display the main menu
        /// </summary>
        /// <returns>Menu Selection</returns>
        public static int ShowMainMenu()
        {
            int choice;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(20, 0);
            Console.WriteLine("Welcome to a cli app connected with MongoDB");
            Console.ResetColor();
            Console.WriteLine();
            Console.Write(
                "Please enter your choice: \n\n" +
                "[0] Add new serie. \n" +
                "[1] Show series list. \n" +
                "[2] Update serie info (by ID). \n" +
                "[3] Delete serie (by ID). \n" +
                "[4] Exit. \n");
            Console.WriteLine("-------------------------------");

            var entry = Console.ReadLine();
            if (!int.TryParse(entry, out choice))
            {
                choice = 5;
            }
            return choice;

        }


        public static int ActorsMainMenu()
        {
            int choice;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(20, 0);
            Console.WriteLine("Actors menu");
            Console.ResetColor();
            Console.WriteLine();
            Console.Write(
                "Please enter your choice: \n\n" +
                "[0] Add new Actor. \n" +
                "[4] Exit. \n");
            Console.WriteLine("-------------------------------");

            var entry = Console.ReadLine();
            if (!int.TryParse(entry, out choice))
            {
                choice = 5;
            }
            return choice;

        }

        /// <summary>
        /// Show current page title
        /// </summary>
        /// <param name="title"></param>
        private static void ShowHeader(string title)
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(20, 0);
            Console.WriteLine(title);
            Console.ResetColor();
            Console.WriteLine();
        }


        /// <summary>
        /// Display continue message
        /// </summary>
        public static void ShowContinueMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n------------------------------------------\n");
            Console.ResetColor();
            Console.WriteLine("Operation completed! \n" +
                "Press return key to continue...");
            Console.Read();
        }


        public static void ShowActorAddedMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n------------------------------------------\n");
            Console.ResetColor();
            Console.WriteLine("Operation completed! \n" +
                "Actor succefully addded");
            Console.Read();
        }

        /// <summary>
        /// display 'add new serie' dialog
        /// </summary>
        /// <returns></returns>
        public static Serie ShowAddNewSerie()
        {
            ShowHeader("Añadir nueva serie");

            var serie = new Serie();

            Console.Write("Introduzca el título de la serie: ");
            serie.titulo = Console.ReadLine();

            Console.Write("Introduzca una descripcion: ");
            serie.descripcion = Console.ReadLine();

            Console.Write("Introduzca su valoración: ");
            serie.valoracion = Double.Parse(Console.ReadLine());

            Console.Write("Introduzca se fecha de lanzamiento, según el patrón dd-mm-yyyy: ");
            serie.fechaLanzamiento = DateTime.ParseExact(Console.ReadLine(),
                                            "dd-MM-yyyy",
                                            CultureInfo.InvariantCulture);

            Console.Write("Introduzaca el número de temporadas: ");
            serie.temporada = Convert.ToInt32(Console.ReadLine());

            Console.Write("Introduzca los actores de la serie: ");
            serie.actores=añadirActor();


            return serie;
        }

        public static Actor[] añadirActor()
        {
            ShowHeader("Añadir actores a la serie");
            List<Actor> actores = new List<Actor>();
             int menuChoice;
            do{
                menuChoice = ActorsMainMenu();

                switch (menuChoice) {


                    case 0:
                        var actor = new Actor();

                        Console.Write("Introduzca el nombre del actor: ");
                        actor.nombre = Console.ReadLine();

                        Console.Write("Introduzca los apellidos: ");
                        actor.apellidos = Console.ReadLine();

                        Console.Write("Introduzca su valoración: ");
                        actor.valoracion = Double.Parse(Console.ReadLine());

                        Console.Write("Introduzca la edad: ");
                        actor.edad = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Introduzca el lugar de nacimiento: ");
                        actor.lugarNacimiento = Console.ReadLine();

                        actores.Add(actor);

                        ShowActorAddedMessage();
                        break;



            }
            

            } while (menuChoice != 4);

            return actores.ToArray();
        }


        /// <summary>
        /// Display 'show serie list' dialog
        /// </summary>
        /// <param name="seriesList"></param>
        public static void ShowSerieList(List<Serie> seriesList)
        {
            ShowHeader("Series list");

            var table = new EstiloConsola("Id", "Titulo", "Valoracion", "Descripcion","Lanzamiento");

            foreach (var serie in seriesList)
            {
                table.AddRow(serie._id, serie.titulo, serie.valoracion, serie.descripcion, serie.fechaLanzamiento);
            }
            table.Print();

            ShowContinueMessage();
        }

        /// <summary>
        /// Display 'Update serie' dialog
        /// </summary>
        /// <returns></returns>
        public static string ShowUpdateSerie()
        {
            ShowHeader("Update Serie");

            Console.WriteLine("Enter serie Id: ");

            return Console.ReadLine();

        }

        /// <summary>
        /// Display 'Delete serie' dialog
        /// </summary>
        /// <returns></returns>
        public static string ShowDeleteSerie()
        {
            ShowHeader("Delete Serie");

            Console.Write("Enter serie ID: ");

            return Console.ReadLine();
        }

    }
}