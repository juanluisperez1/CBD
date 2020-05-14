using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CBD_PROYECTO
{
    class Dialogo
    {
       
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
                "[2] Buscar serie. \n" +
                "[3] Mostrar las mejores series. \n" +
                "[4] Actualizar la informacion de una serie(por ID). \n" +
                "[5] Borrar serie (por ID). \n" +
                "[6] Salir. \n");
            Console.WriteLine("-------------------------------");

            var entry = Console.ReadLine();
            if (!int.TryParse(entry, out choice))
            {
                choice = 7;
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

       
        public static Serie ShowAddNewSerie()
        {
            ShowHeader("Añadir nueva serie");

            var serie = new Serie();

            Console.Write("Introduzca el título de la serie: ");
            var titulo = Console.ReadLine();

            while (string.IsNullOrEmpty(titulo) && string.IsNullOrWhiteSpace(titulo))
            {
                Console.Write("Introduce un titulo (Este campo es obligatorio): ");
                titulo = Console.ReadLine();
                serie.titulo = titulo;
            }
            serie.titulo = titulo;

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
                Console.WriteLine("Fecha inválida, por favor inténtalo de nuevo, el formato es dd/MM/yyyy");
                serie.fechaLanzamiento = Console.ReadLine();
            }


            Console.Write("Introduzca el número de temporadas: ");
            

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
                        var nombre = Console.ReadLine();

                        while(string.IsNullOrEmpty(nombre) && string.IsNullOrWhiteSpace(nombre))
                        {
                            Console.Write("Introduce un nombre (Este campo es obligatorio): ");
                            nombre = Console.ReadLine();
                            actor.nombre = nombre;
                        }
                        actor.nombre = nombre;

                        Console.Write("Introduzca los apellidos del actor: ");
                        var apellidos = Console.ReadLine();

                        while (string.IsNullOrEmpty(apellidos) && string.IsNullOrWhiteSpace(apellidos))
                        {
                            Console.Write("Introduce unos apellidos (Este campo es obligatorio): ");
                            apellidos = Console.ReadLine();
                            actor.apellidos = apellidos;
                        }
                        actor.apellidos = apellidos;


                        Console.Write("Introduzca su valoración: ");
                        double num;

                        while (!double.TryParse(Console.ReadLine(), out num))
                        {
                            Console.Write("El valor ingresado no es válido.\nIngrese un número decimal: ");
                        }
                        actor.valoracion = num;


                        Console.Write("Introduzca la edad: ");
                        int numero;

                        while (!Int32.TryParse(Console.ReadLine(), out numero))
                        {
                            Console.Write("El valor ingresado no es válido.\nIngrese un número entero: ");
                        }

                        actor.edad = numero;




                        Console.Write("Introduzca el lugar de nacimiento: ");
                        var lugar = Console.ReadLine();

                        while (string.IsNullOrEmpty(lugar) && string.IsNullOrWhiteSpace(lugar))
                        {
                            Console.Write("Introduce un lugar valido: ");
                            lugar = Console.ReadLine();
                            actor.lugarNacimiento = lugar;
                        }
                        actor.lugarNacimiento = lugar;


                        actores.Add(actor);

                        ShowActorAddedMessage();
                        break;



            }
            

            } while (menuChoice != 4);

            return actores.ToArray();
        }


                   


       
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

        public static void ShowSerieListMejores(List<Serie> seriesList)
        {
            ShowHeader("Lista de las mejores series");

            var table = new EstiloConsola("Id", "Titulo", "Descripcion", "Valoracion", "Temporadas", "Lanzamiento");

            foreach (var serie in seriesList)
            {
                table.AddRow(serie._id, serie.titulo, serie.descripcion, serie.valoracion, serie.temporada, serie.fechaLanzamiento);
            }
            table.Print();

            ShowContinueMessage();
        }
        public static void ShowSerieByName(Serie serie)
        {
            ShowHeader("SERIE");

            var table = new EstiloConsola("Id", "Titulo", "Descripcion", "Valoracion", "Temporadas", "Lanzamiento");
         
       
            table.AddRow(serie._id, serie.titulo, serie.descripcion, serie.valoracion, serie.temporada, serie.fechaLanzamiento);
            
            table.Print();

            ShowContinueMessage();

        }
        public static void ShowSerieByName1()
        {
            ShowHeader("Buscar serie");

            Console.Write("Introduzca nombre: ");

          
        }

    



public static string ShowUpdateSerie()
        {
            ShowHeader("Actualizar serie");

            
            Console.WriteLine("Introduzca serie ID: ");

            return Console.ReadLine();

        }

        
        public static string ShowDeleteSerie()
        {
            ShowHeader("Borrar serie");

            Console.Write("Introduzca serie ID: ");

            return Console.ReadLine();
        }

    }
}