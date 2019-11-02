using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insertBD
{
    class ObVentas
    {
        //Iniciaice las variales globales.
        private String NoTiket = "", idTienda = "", idProducto = "", idnom = "TK";
        private int precio_venta = 0, cantidad = 0, idnum = 1;
        private Random numRan = new Random();
        private DateTime idTiempo = new DateTime();

        //Arreglos de PKs de las otras tuplas
        private String[] idTiendas = { "T1", "T2", "T3", "T4", "T5", "T6", "T7", "T8", "T9", "T10",
                               "T11", "T12", "T13", "T14", "T15", "T16", "T17", "T18", "T19", "T20",
                               "T21", "T22", "T23", "T24", "T25", "T26", "T27", "T28", "T29", "T30",
                               "T31", "T32", "T33", "T34", "T35", "T36", "T37", "T38", "T39", "T40",
                               "T41", "T42", "T43", "T44", "T45"};

        private String[] idProductos = { "P1", "P2", "P3", "P4", "P5", "P6", "P7", "P8", "P9", "P10",
                                 "P11", "P12", "P13", "P14", "P15", "P16", "P17", "P18", "P19", "P20",
                                 "P21", "P22", "P23", "P24", "P25", "P26", "P27", "P28", "P29", "P30"};

        //Arreglo de precios para productos
        private Int32[] precios = {12,54,76,12,456,78,96,123,125,23,
                           12,75,245,76,23,45,234,47,34,52,
                           12,123,546,6,72,23,56,234,12,34};

        //Refrescar valores random
        public void refrescar(){
            NoTiket = varNoTiket();
            idTienda = varidTienda();
            idProducto = varidProducto();
            cantidad = varCantidad();
            idTiempo = varFecha();
        }

        //Método que genera un numero ranjo entre un intervalo
        private Int32 numeroRandom(int min, int max)
        {
            Int32 rand = numRan.Next(min, max);

            return rand;
        }

        //Metodos para asignar valores a las variables de manera aleatoria pero controlada
        private string varNoTiket()
        {
            return NoTiket = idnom + "" + idnum;
        }

        private string varidTienda()
        {
            idTienda = idTiendas[numeroRandom(0, idTiendas.Length)];

            return idTienda;
        }

        private string varidProducto()
        {
            int numero = numeroRandom(0, idProductos.Length);
            idProducto = idProductos[numero];
            precio_venta = varPrecio_venta(numero);

            return idProducto;
        }

        private int varCantidad()
        {
            return cantidad = numeroRandom(1, 20);
        }

        private int varPrecio_venta(int a)
        {
            return precio_venta = precios[a];
        }

        private DateTime varFecha()
        {
            Int32 dia = numeroRandom(1, 29);
            Int32 mes = numeroRandom(1, 11);
            Int32 hora = numeroRandom(0, 23);
            Int32 minuto = numeroRandom(0, 59);
            Int32 segundo = numeroRandom(0, 59);
            idTiempo = new DateTime(2018, mes, dia, hora, minuto, segundo);

            return idTiempo;
        }

        //Setter y Getters de varibles globales
        public void setidNum(int idnum){
            this.idnum=idnum;
        }

        public string getNoTiket(){
             return NoTiket;
        }

        public string getidTienda(){
             return idTienda;
        }

        public string getidProducto(){
             return idProducto;
        }

        public int getcantidad(){
             return cantidad;
        }

        public int getprecio_venta(){
            return precio_venta;
        }

        public DateTime getidTiempo(){
            return idTiempo;
        }
    }
}