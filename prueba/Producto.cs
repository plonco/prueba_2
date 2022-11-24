using System;
using System.Collections.Generic;
using System.Text;

namespace prueba
{
    internal class Producto
    {
        #region propiedades

        private int _registro;
        public int Registro
        {
            get { return _registro; }
            set { if (value >= 0) { _registro = value; } }
        }
        public string Nombre { get; set; }
        private int _valor;
        public string Desc { get; set; }
        public string Obj1 { get; set; }
        public string Obj2 { get; set; }
        public string Obj3 { get; set; }
        public string Fecha { get; set; }

        public int Valor
        {
            get { return _valor; }
            set { if (value >= 0) { _valor = value; } }
        }
        
        #endregion

        #region metodos
        public string DatosProducto()
        {
            return Nombre +", "+ Valor +", "+ Desc +", "+ Obj1 +", "+ Obj2 +", "+ Obj3 +","+ Fecha;
        }
        #endregion

        #region Constructores
        public Producto() { }
        public Producto(int registro, string nombre, int valor, string desc, string obj1, string obj2, string obj3, string fecha)
        {
            Registro = registro;
            Nombre = nombre;
            Valor = valor;
            Desc = desc;
            Obj1 = obj1;
            Obj2 = obj2;
            Obj3 = obj3;
            Fecha = fecha;
        }
        #endregion

    }
}
