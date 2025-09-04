using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XulambsFoods_2025_1.src {
    public class Pedido {
        private static int s_ultimoPedido = 0;
        
        private int _idPedido;
        private DateOnly _data;
        private LinkedList<Pizza> _pizzas;
        private bool _aberto;

        public Pedido() {
            //TODO
        }

        private bool PodeAdicionar() {
            //TODO
            return false;
        }

        public int Adicionar(Pizza pizza) {
            //TODO
            return 0;
        }

        public void FecharPedido() {
            //TODO

        }

        public double PrecoAPagar() {
            //TODO
            return 0;
        }

        public string Relatorio() {
            //TODO
            return "";
        }
    }
}
