﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prueba
{
    internal class Dueño
    {
        private List<Producto> productos = new List<Producto>();
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
        public void AgregarProducto(int registro, string nombre, int valor, string desc, string obj1, string obj2, string obj3)
        {
            productos.Add(new Producto(registro, nombre, valor, desc, obj1, obj2, obj3));
        }

        public Producto BuscarProductos(int registro)
        {
            Producto prod = productos.Find(prod=> prod.Registro.Equals(registro));
            return prod;
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
