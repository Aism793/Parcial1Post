using NUnit.Framework;
using ProductoDomain;
using System;
using System.Collections.Generic;

namespace ProductoSolutionTDD
{
    public class ProductoSolutionTest
    {
        /*
         HU1. ENTRADA DE PRODUCTO 
        (1.5) COMO USUARIO QUIERO REGISTRAR LA ENTRADA PRODUCTOS  
        CRITERIOS DE ACEPTACIÓN    
        1. La cantidad de la entrada de debe ser mayor a 0    
        2. La cantidad de la entrada se le aumentará a la cantidad existente del producto
         */
        /*
        Escenario: Valor de ingreso -1
        H1: COMO USUARIO QUIERO REGISTRAR LA ENTRADA PRODUCTOS  
        Criterio de Aceptación:
        1. La cantidad de la entrada de debe ser mayor a 0 
        //El ejemplo o escenario
        Dado El cliente tiene un producto 
        Id 1, Nombre “Gaseosa”, Categoria "VentaDirecta"
        Cuando Va a ingresar una cantidad -1
        Entonces El sistema presentará el mensaje. “La cantidad a ingresar es incorrecta”
         */
        [Test]
        public void NoPuedeIngresarCantidadProductosDeMenosUno()
        {
            var productoSimple = new ProductoSimple(id: "1", nombre: "Gaseosa", categoria: "VENTADIRECTA", costo: 2000, precio: 5000);
            int cantidadProducto = -1;
            string respuesta = productoSimple.Ingresar(cantidadProducto: cantidadProducto, productoSimple);
            Assert.AreEqual("La cantidad a ingresar es incorrecta", respuesta);
        }

        /*
        Escenario: Valor de ingreso 50
        H1: COMO USUARIO QUIERO REGISTRAR LA ENTRADA PRODUCTOS  
        Criterio de Aceptación:
        1. La cantidad de la entrada de debe ser mayor a 0 
        2. La cantidad de la entrada se le aumentará a la cantidad existente del producto
        //El ejemplo o escenario
        Dado El cliente tiene un producto 
        Id 1, Nombre “Salchicha”, Categoria "Preparacion", Cantidad 50
        Cuando Va a ingresar una cantidad 30
        Entonces El sistema la sumará a la cantidad existente
        and presentará el mensaje. “La cantidad actual del producto es 80”
         */
        [Test]
        public void PuedeIngresarCantidadProductosCincuentaCorrecta()
        {
            var productoSimple = new ProductoSimple(id: "1", nombre: "Gaseosa", categoria: "VENTADIRECTA", costo: 2000, precio: 5000);
            int cantidadProducto = 50;
            productoSimple.Ingresar(cantidadProducto: cantidadProducto, productoSimple);
            string respuesta = productoSimple.Ingresar(cantidadProducto: 30, productoSimple);
            Assert.AreEqual("La cantidad actual del producto Gaseosa es 80", respuesta);
        }

        //--------------------------------------------------------------------------------------------------

        //PRUEBAS PARA SALIDA DE PRODUCTOS
        /*
         HU1. SALIDA DE PRODUCTO 
        (3.5) COMO USUARIO QUIERO REGISTRAR LA SALIDA PRODUCTOS  
        CRITERIOS DE ACEPTACIÓN 
        1. La cantidad de la salida de debe ser mayor a 0 
        2. En caso de un producto sencillo la cantidad de la salida se le disminuirá a la cantidad existente 
        del producto. 
        3. En caso de un producto compuesto la cantidad de la salida se le disminuirá a la cantidad existente 
        de cada uno de su ingrediente 
        4. Cada salida debe registrar el costo del producto y el precio de la 
        venta 
        5. El costo de los productos compuestos corresponden al costo de sus ingredientes por la cantidad de 
        estos. 
         */
        /*
        /*
        Escenario: Valor de venta -1
        H1: (3.5) COMO USUARIO QUIERO REGISTRAR LA SALIDA PRODUCTOS   
        Criterio de Aceptación:
        1. La cantidad de la salida de debe ser mayor a 0 
        //El ejemplo o escenario
        Dado El cliente va a comprar un producto 
        Id 1, Nombre “Gaseosa”, Categoria "VentaDirecta"
        Cuando Va a ingresar una cantidad -1
        Entonces El sistema presentará el mensaje. “La cantidad a vender es incorrecta”
         */
        [Test]
        public void NoPuedeVenderCantidadProductosDeMenosUno()
        {
            var productoSimple = new ProductoSimple(id: "1", nombre: "Gaseosa", categoria: "VENTADIRECTA", costo: 2000, precio: 5000);
            int cantidadProducto = -1;
            string respuesta = productoSimple.Vender(cantidadProducto: cantidadProducto);
            Assert.AreEqual("La cantidad a vender es incorrecta", respuesta);
        }

        /*
        Escenario: Valor de venta 2 Producto sencillo
        H1: (3.5) COMO USUARIO QUIERO REGISTRAR LA SALIDA PRODUCTOS   
        Criterio de Aceptación:
        1. La cantidad de la salida de debe ser mayor a 0 
        2. En caso de un producto sencillo la cantidad de la salida se le disminuirá a la cantidad existente 
        del producto. 
        //El ejemplo o escenario
        Dado El cliente va a comprar un producto 
        Id 1, Nombre “Gaseosa”, Categoria "VentaDirecta", Cantidad 30
        Cuando Va a ingresar una cantidad 2
        Entonces El sistema disminuirá la cantidad de dicho producto
        and presentará el mensaje. “La cantidad actual del producto es 28”
         */
        [Test]
        public void PuedeVenderCantidadProductoSencilloCorrecta()
        {
            var productoSimple = new ProductoSimple(id: "1", nombre: "Gaseosa", categoria: "VENTADIRECTA", costo: 2000, precio: 5000);
            int cantidadProducto = 30;
            productoSimple.Ingresar(cantidadProducto: cantidadProducto, productoSimple);

             int cantidadVenta = 2;
            string respuesta = productoSimple.Vender(cantidadProducto: cantidadVenta);
            Assert.AreEqual("La cantidad actual del producto es 28", respuesta);
        }

        /*
       Escenario: Valor de venta 2 Producto compuesto
       H1: (3.5) COMO USUARIO QUIERO REGISTRAR LA SALIDA PRODUCTOS   
       Criterio de Aceptación:
       1. La cantidad de la salida de debe ser mayor a 0 
       3. En caso de un producto compuesto la cantidad de la salida se le disminuirá a la cantidad existente 
        de cada uno de su ingrediente 
       //El ejemplo o escenario
       Dado El cliente va a comprar un producto 
       Id 2, Nombre “Perro Sencillo”, Categoria "Preparado"
       Cuando Va a vender una cantidad 2
       Entonces El sistema disminuirá la cantidad de los productos necesarios para su elaboración
       and presentará el mensaje. “La cantidad actual del producto es 28”
        */
        [Test]
        public void PuedeVenderCantidadProductoCompuestoCorrecta()
        {
            List<ProductoSimple> productosSimples = new List<ProductoSimple>();
            var salchicha = new ProductoSimple(id: "1", nombre: "Salchicha", categoria: "PREPARACION", costo: 1000, precio: 0);
            salchicha.Ingresar(cantidadProducto: 30, salchicha);
            var panPerro = new ProductoSimple(id: "2", nombre: "PanPerros", categoria: "PREPARACION", costo: 1000, precio: 0);
            salchicha.Ingresar(cantidadProducto: 30, panPerro);
            var laminaQueso = new ProductoSimple(id: "3", nombre: "LaminaQueso", categoria: "PREPARACION", costo: 1000, precio: 0);
            salchicha.Ingresar(cantidadProducto: 30, laminaQueso);
            productosSimples.Add(salchicha);
            productosSimples.Add(panPerro);
            productosSimples.Add(laminaQueso);

            var productoCompuesto = new ProductoCompuesto(id: "4", nombre: "Perro sencillo", categoria: "PREPARADOS");
            int cantidadVenta = 2;
            List<int> cantidadesDisminuir = new List<int>() { 1, 1, 1 };
            string respuesta = productoCompuesto.Vender(cantidadProducto: cantidadVenta, precio: 5000, productoSimples: productosSimples, nombre: productoCompuesto.Nombre, cantidadesDisminuir: cantidadesDisminuir);
            Assert.AreEqual("El costo total es 6000 pesos", respuesta);
        }

        /*
       Escenario: Valor de venta 2 Producto compuesto
       H1: (3.5) COMO USUARIO QUIERO REGISTRAR LA SALIDA PRODUCTOS   
       Criterio de Aceptación:
       1. La cantidad de la salida de debe ser mayor a 0 
       3. En caso de un producto compuesto la cantidad de la salida se le disminuirá a la cantidad existente 
        de cada uno de su ingrediente 
       //El ejemplo o escenario
       Dado El cliente va a comprar un producto 
       Id 2, Nombre “Perro Sencillo”, Categoria "Preparado"
       Cuando Va a vender una cantidad 2
       Entonces El sistema disminuirá la cantidad de los productos necesarios para su elaboración
       and presentará el mensaje. “La cantidad actual del producto es 28”
        */
       /* [Test]
        public void PuedeVenderCantidadProductoCompuestoCorrect()
        {
            List<ProductoSimple> productosSimples = new List<ProductoSimple>();
            var salchicha = new ProductoSimple(id: "1", nombre: "SalchichaRanchera", categoria: "PREPARACION", costo: 2000, precio: 0);
            salchicha.Ingresar(cantidadProducto: 30, salchicha);
            var panPerro = new ProductoSimple(id: "2", nombre: "PanExtra", categoria: "PREPARACION", costo: 2000, precio: 0);
            salchicha.Ingresar(cantidadProducto: 30, panPerro);
            var laminaQueso = new ProductoSimple(id: "3", nombre: "LaminaQueso", categoria: "PREPARACION", costo: 1000, precio: 0);
            salchicha.Ingresar(cantidadProducto: 30, laminaQueso);
            productosSimples.Add(salchicha);
            productosSimples.Add(panPerro);
            productosSimples.Add(laminaQueso);

            var productoCompuesto = new ProductoCompuesto(id: "4", nombre: "Perro sencillo", categoria: "PREPARADOS");
            int cantidadVenta = 1;
            string respuesta = productoCompuesto.Vender(cantidadProducto: cantidadVenta, precio: 8000, productoSimples: productosSimples, nombre: productoCompuesto.Nombre);
            Assert.AreEqual("El costo total es 6000 pesos", respuesta);
        }*/

    }

    
}