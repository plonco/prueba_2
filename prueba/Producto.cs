using System;
using System.Collections.Generic;
using System.Text;

namespace prueba
{
    internal class Producto
    {
        #region propiedades

        public string Registro {get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }
        public string Desc { get; set; }
        public string Obj1 { get; set; }
        public string Obj2 { get; set; }
        public string Obj3 { get; set; }
        public string Fecha { get; set; }


        #endregion

        #region metodos
        public string DatosProducto()
        {
            return Nombre +", "+ Valor +", "+ Desc +", "+ Obj1 +", "+ Obj2 +", "+ Obj3 +","+ Fecha;
        }
        #endregion

        #region Constructores
        public Producto() { }
        public Producto(string registro, string nombre, string valor, string desc, string obj1, string obj2, string obj3, string fecha)
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
