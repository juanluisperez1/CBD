using System;

using System;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace CBD_PROYECTO
{
    partial class Program
    {

        static void Main(string[] args)
        {
            // Establecemos conexion con la base de datos
            var mongoDB = new MongoConnect("CBD");

            /*
          
            //cargamos los datos de un episodio
            Episodios e1 = new Episodios("Efectuar lo acordado", "El profesor recluta a una joven ladrona y otros siete delincuentes para un gran atraco, dirigido a la Casa de la Moneda Real de España."
              , 4.2, DateTime.Parse("2017-05-02"));
            Episodios e2 = new Episodios("Imprudencias letales", "La negociadora de rehenes Raquel hace contacto inicial con el profesor. Uno de los rehenes es una parte crucial de los planes de los ladrones."
                , 4.4, DateTime.Parse("2017-05-09"));

            //cargamos datos referentes a la temporada
            Temporada t1 = new Temporada("Temporada 1", 4.5, new Episodios[] { e1, e2 }, DateTime.Parse("2017-05-02"));


            // cargamos los datos de una serie
            Serie s1 = new Serie("La casa de papel", "Un grupo inusual de ladrones intenta llevar a cabo el robo más perfecto de la historia española: robar 2.400 millones de euros de la Royal Mint de España.",
              4.8, new string[] { "Úrsula Corberó", "Álvaro Morte", "Itziar Ituño", "Pedro Alonso", "Alba Flores", "Miguel Herrán", "Jaime Lorente" }, "Álex Pina", DateTime.Parse("2013-05-09T18:17:07.000Z"), t1);


            //Metodo preparado para insertar peliculas o episosios en nuestra base de datos
            mongoDB.insertarElemento("Series", s1);


            //Metodo de listar elementos de la base de datos


            var lista = mongoDB.listadoBD<Serie>("Series");
            Console.WriteLine("En nuestra base de datos existen todas estas personas: ");
            foreach (var personas in lista)
            {

                Console.WriteLine("------------------------------------------");
                Console.WriteLine($"{personas.creador}");
            }

            

            //Metodo de upgrade una serie

            //Metodo de delete de una serie

            */
            // Nuestro programa

            Console.WriteLine("Hola Bienvenidos a el programa desarrollado para CBD: ");

            Console.WriteLine("1) Pulse la tecla 1 para ver todos los datos de las Base de Datos ");
            Console.WriteLine("2) Pulse la tecla 2 para insertar una serie Base de Datos ");
            Console.WriteLine("3) Pulse la tecla 3 para editar una serie Base de Datos ");
            Console.WriteLine("4) Pulse la tecla 4 para eliminar una serie Base de Datos ");


            ConsoleKeyInfo info = Console.ReadKey();
            switch (info.KeyChar)
            {
                case '1':

                    Console.Clear();
                    Console.WriteLine("Usted a selecionado la opcion 1, vamos a proceder a listar todos las series del sistema");
                    Console.WriteLine("En nuestra base de datos existen todas estas personas: ");
                    var series = mongoDB.listadoBD<Serie>("Series");
                    foreach (var personas in series)
                    {

                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine($"{personas.creador}");
                    }
                    break;

                case '2':
                    Console.WriteLine("Usted a selecionado la opcion 2, vamos a proceder a introducir usuarios en nuestro sistema");

                    Console.WriteLine("Introduzca Titulo");
                    String texto;
                    texto = Console.ReadLine();
                    Console.WriteLine("Introduzca Descripcion");
                    String texto2;
                    texto2 = Console.ReadLine();
                    String val;
                    val = Console.ReadLine();
                    break;





            }
        }
    }
}
