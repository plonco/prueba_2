﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpreadsheetLight;

namespace prueba
{
    internal class Dueño
    {
        public Producto prod = new Producto();
        public List<Producto> productos = new List<Producto>();
        #region Propiedades
        public int _id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Id
        {
            get { return _id; }
            set { if (value >= 0) { _id = value; } }
        }
        #endregion
        #region Metodos
        


        public void AgregarProducto(int registro, string nombre, int valor, string desc, string obj1, string obj2, string obj3, string fecha)
        {
            productos.Add(new Producto(registro, nombre, valor, desc, obj1, obj2, obj3, fecha));
        }
        public void AgregarProducto2(int registro, string nombre, int valor, string desc, string obj1, string obj2, string obj3, string fecha)
        {
            string pathFile = AppDomain.CurrentDomain.BaseDirectory + "excel.xlsx";
            SLDocument slDocument = new SLDocument();
            System.Data.DataTable dt = new System.Data.DataTable();
            System.Data.DataRow dr;

            dt.Columns.Add("Registro", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Valor", typeof(int));
            dt.Columns.Add("Descripción", typeof(string));
            dt.Columns.Add("Objeto a intercambio 1", typeof(string));
            dt.Columns.Add("Objeto a intercambio 2", typeof(string));
            dt.Columns.Add("Objeto a intercambio 3", typeof(string));
            dt.Columns.Add("Fecha", typeof(string));

            foreach (Producto produ in productos)
            {
                dt.Rows.Add(produ.Registro, produ.Nombre,produ.Valor, produ.Desc, produ.Obj1, produ.Obj2, produ.Obj3, produ.Fecha);
            }

            dt.Rows.Add(registro, nombre, valor, desc, obj1, obj2, obj3, fecha);

            slDocument.ImportDataTable(1, 1, dt, true);
            slDocument.SaveAs(pathFile);
            productos.Add(new Producto(registro, nombre, valor, desc, obj1, obj2, obj3, fecha));
        }
        public Producto BuscarProductos(int registro)
        {
            Producto prod = productos.Find(prod=> prod.Registro.Equals(registro));
            return prod;
        }
        public void BuscarProductoAntiguo()
        {
            Producto[] antiguo = (from num in productos
                          where num.Registro >=0
                          orderby num.Fecha 
                          select num).ToArray();
            foreach (Producto a in antiguo)
                Console.WriteLine(a.Nombre + " " + a.Fecha);
        }
        public void Ofertas()
        {
            double nume = 0;
            Producto[] ofer = (from num in productos
                                  where num.Registro >=0
                                  orderby num.Fecha
                                  select num).ToArray();
            foreach (Producto a in ofer)
            {
                if(a.Valor >= 15000 && a.Valor <= 30000)
                {
                    nume = (a.Valor)*0.3;
                    Console.WriteLine(a.Nombre + " " + Convert.ToInt32(nume) + " Descuento 30%"); ;
                }else if(a.Valor >=10000 && a.Valor <= 14999)
                {
                    nume = (a.Valor)*0.2;
                    Console.WriteLine(a.Nombre + " " + Convert.ToInt32(nume) + " " + " Descuento 20%");
                }
                else if(a.Valor >=5000 && a.Valor <= 9999)
                {
                    nume = (a.Valor)*0.1;
                    Console.WriteLine(a.Nombre + " " + Convert.ToInt32(nume) + " " + " Descuento 10%");
                }
                else
                {
                    nume = a.Valor;
                    Console.WriteLine(a.Nombre + " " + Convert.ToInt32(nume) + " " + "descuento 0%");
                }
                
            }
                
        }
        #endregion
        #region Constructores
        public Dueño()
        {

        }
        public Dueño(int id, string nombre, string apellido)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
        }
        #endregion
    }
}
