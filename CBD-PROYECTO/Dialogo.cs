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
            Console.WriteLine("Bienvenido a nuestro trabajo de CBD; una app conectada con MongoDB");
            Console.ResetColor();
            Console.WriteLine();
            Console.Write(
                "Por favor, introduzca su elección: \n\n" +
                "[0] Añadir nueva serie. \n" +
                "[1] Mostrar lista de series. \n" +
                "[2] Actualizar la informacion de una serie(por ID). \n" +
                "[3] Borrar serie (por ID). \n" +
                "[4] Salir. \n");
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
            Console.WriteLine("Menú de actores");
            Console.ResetColor();
            Console.WriteLine();
            Console.Write(
                "Por favor, introduzca su elección: \n\n" +
                "[0] Añadir nuevo actor. \n" +
                "[4] Salir. \n");
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
            Console.WriteLine("Operación completada! \n" +
                "Presione la tecla de retorno para continuar...");
            Console.Read();
        }


        public static void ShowActorAddedMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n------------------------------------------\n");
            Console.ResetColor();
            Console.WriteLine("Operación completada! \n" +
                "El actor se añadió con éxito");
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

            double d;
            while (!double.TryParse(Console.ReadLine(), out d))
            {
                Console.Write("El valor ingresado no es válido.\nIngrese un número entero: ");
            }
                
                serie.valoracion = d;




            Console.Write("Introduzca fecha de lanzamiento, siguiendo el formato dd/MM/yyyy: ");
            serie.fechaLanzamiento = Console.ReadLine();
            DateTime dt;
            while (!DateTime.TryParseExact(serie.fechaLanzamiento, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                Console.WriteLine("Invalid date, please retry, the format is dd/MM/yyyy");
                serie.fechaLanzamiento = Console.ReadLine();
            }


            Console.Write("Introduzca el número de temporadas: ");
            // int num;

            //  while (!Int32.TryParse(serie.temporada,null,null, System.Globalization.DateTimeStyles.None, out num)){


            int num;

            while (!Int32.TryParse(Console.ReadLine(), out num))
            {
                Console.Write("El valor ingresado no es válido.\nIngrese un número entero: ");
               

            }

            serie.temporada = num;

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
                        double num;

                        while (!double.TryParse(Console.ReadLine(), out num))
                        {
                            Console.Write("El valor ingresado no es válido.\nIngrese un número decimal: ");
                        }


                    //    actor.valoracion = Double.Parse(Console.ReadLine());

                        Console.Write("Introduzca la edad: ");
                        int numero;

                        while (!Int32.TryParse(Console.ReadLine(), out numero))
                        {
                            Console.Write("El valor ingresado no es válido.\nIngrese un número entero: ");
                        }

                        actor.edad = numero;

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
            ShowHeader("Lista de series");

            var table = new EstiloConsola("Id", "Titulo", "Descripcion", "Valoracion","Temporadas", "Lanzamiento");

            foreach (var serie in seriesList)
            {
                table.AddRow(serie._id, serie.titulo,  serie.descripcion, serie.valoracion, serie.temporada,serie.fechaLanzamiento);
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
            ShowHeader("Actualizar serie");

            
            Console.WriteLine("Introduzca serie Id: ");

            return Console.ReadLine();

        }

        /// <summary>
        /// Display 'Delete serie' dialog
        /// </summary>
        /// <returns></returns>
        public static string ShowDeleteSerie()
        {
            ShowHeader("Borrar serie");

            Console.Write("Introduzca serie ID: ");

            return Console.ReadLine();
        }

    }
}