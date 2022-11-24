using SpreadsheetLight;
using System;
using System.Collections.Generic;

namespace prueba
{
    class Program
    {

        static void Main(string[] args)
        {

            Dueño dueño = new Dueño(1, "Pedro", "Morales");

            CargarDatos(dueño);

            bool menu = true;
            while (menu)
            {
                menu = MenuApp(dueño);
            }
        }

        static bool MenuApp(Dueño du)
        {
            Console.Clear();
            Console.WriteLine("       MENU EL TRUEQUE\n");
            Console.WriteLine("1 = Agregar Producto");
            Console.WriteLine("2 = Ver Productos antiguos");
            Console.WriteLine("3 = ofertas");
            Console.WriteLine("4 = Hacer Trueque");
            Console.WriteLine("5 = Salir\n\n\n");
            Console.Write("Escriba el numero de una opcion del 1 al 5 y presione Enter....");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    AgregarProducto(du);
                    return true;
                case "2":
                    Console.Clear();
                    BuscarProducto(du);
                    return true;
                case "3":
                    Console.Clear();
                    Ofertas(du);
                    Console.ReadKey();
                    return true;
                case "4":
                    Console.Clear();
                    //HacerTrueque(du);
                    return true;
                case "5":
                    return false;
                default:
                    Console.Clear();
                    Console.WriteLine("Digite una tecla del 1 al 5....");
                    Console.ReadKey();
                    return true;
            }

        }

        static bool AgregarProducto(Dueño du)
        {
            // Menu 1

            string strRegistro, nombre, strValor, desc, obj1, obj2, obj3, strDia, strMes, strAnio, strFecha;
            int registro, valor, dia, mes, anio;
            try
            {
                Console.WriteLine("               Ingresando Datos de Producto\n\n\n");

                Console.Write("Registro              : "); strRegistro = Console.ReadLine();
                if (!int.TryParse(strRegistro, out registro))
                {
                    Console.WriteLine("El valor de registro debe ser númerico...");
                    Console.ReadKey();
                    return false;
                }

                if (du.BuscarProductos(registro) != null) // Se Valida que el registro no exista en el arrelgo de los Equipos
                {
                    Console.WriteLine("El registro ingresado ya existe...");
                    Console.ReadKey();
                    return false;
                }

                Console.Write("Nombre                : "); nombre = Console.ReadLine();
                Console.Write("valor                : "); strValor = Console.ReadLine();
                if (!int.TryParse(strValor, out valor))
                {
                    Console.WriteLine("El valor debe ser númerico...");
                    Console.ReadKey();
                    return false;
                }
                Console.Write("Descripción                : "); desc = Console.ReadLine();
                Console.Write("Objeto a intercambio 1                 : "); obj1 = Console.ReadLine();
                Console.Write("Objeto a intercambio 2                 : "); obj2 = Console.ReadLine();
                Console.Write("Objeto a intercambio 3                 : "); obj3 = Console.ReadLine();
                Console.WriteLine("////// Fecha //////");
                Console.Write("Día                 : "); strDia = Console.ReadLine();
                
                if (!int.TryParse(strDia, out dia))
                {
                    Console.WriteLine("El valor debe ser númerico...");
                    Console.ReadKey();
                    return false;
                }
                if(dia <=0 || dia > 31)
                {
                    Console.WriteLine("Día incorrecto...");
                    Console.ReadKey();
                    return false;
                }
                Console.Write("mes                 : "); strMes = Console.ReadLine();
                if (!int.TryParse(strMes, out mes))
                {
                    Console.WriteLine("El valor debe ser númerico...");
                    Console.ReadKey();
                    return false;
                }
                if (mes <= 0 || mes > 12)
                {
                    Console.WriteLine("Mes incorrecto...");
                    Console.ReadKey();
                    return false;
                }
                Console.Write("año                 : "); strAnio = Console.ReadLine();
                if (!int.TryParse(strAnio, out anio))
                {
                    Console.WriteLine("El valor debe ser númerico...");
                    Console.ReadKey();
                    return false;
                }
                if (anio <= 0)
                {
                    Console.WriteLine("Año incorrecto...");
                    Console.ReadKey();
                    return false;
                }
                DateTime fecha = new DateTime(anio, mes, dia);
                strFecha = fecha.ToString();
            }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("!!! ... Error de Ingreso ...!!!");
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
                return false;
            }
            
            du.AgregarProducto2(registro, nombre, valor, desc, obj1, obj2, obj3, strFecha);
            
            return true;

        }
        static bool BuscarProducto(Dueño du)
        {
            Console.WriteLine("////// productos antiguos //////");
            du.BuscarProductoAntiguo();
            Console.ReadKey();
            return true;
        }
        static bool Ofertas(Dueño du)
        {
            Console.WriteLine("////// Ofertas //////");
            du.Ofertas();
            Console.ReadKey();
            return true;
        }
        static void CargarDatos(Dueño du)
        {
            string nombre, desc, obj1, obj2, obj3, fecha;
            int registro, valor;
            string pathFile = AppDomain.CurrentDomain.BaseDirectory + "excel.xlsx";
            SLDocument slDocument = new SLDocument(pathFile);
            
            int valore = 2;

            while (!string.IsNullOrEmpty(slDocument.GetCellValueAsString(valore, 1)))
            {
                registro = Int32.Parse(slDocument.GetCellValueAsString(valore, 1));
                nombre = slDocument.GetCellValueAsString(valore, 2);
                valor = Int32.Parse(slDocument.GetCellValueAsString(valore, 3));
                desc = slDocument.GetCellValueAsString(valore, 4);
                obj1 = slDocument.GetCellValueAsString(valore, 5);
                obj2 = slDocument.GetCellValueAsString(valore, 6);
                obj3 = slDocument.GetCellValueAsString(valore, 7);
                fecha = slDocument.GetCellValueAsString(valore, 8);


                du.AgregarProducto(registro, nombre, valor, desc, obj1, obj2, obj3, fecha);
                valore++;
            }

        }
    }
}
