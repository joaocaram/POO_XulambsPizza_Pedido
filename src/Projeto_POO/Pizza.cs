﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace XulambsFoods_2025_1.src {
    /** 
    * MIT License
    *
    * Copyright(c) 2024 João Caram <caram@pucminas.br>
    *
    * Permission is hereby granted, free of charge, to any person obtaining a copy
    * of this software and associated documentation files (the "Software"), to deal
    * in the Software without restriction, including without limitation the rights
    * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    * copies of the Software, and to permit persons to whom the Software is
    * furnished to do so, subject to the following conditions:
    *
    * The above copyright notice and this permission notice shall be included in all
    * copies or substantial portions of the Software.
    *
    * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    * SOFTWARE.
    */

    /// <summary>
    /// Classe Pizza para a Xulambs Pizza. Uma pizza tem um preço base e pode ter até 8 ingredientes adicionais. Cada ingrediente tem custo fixo.
    /// A pizza deve emitir uma nota de compra com os seus detalhes.
    /// </summary>

    
    public class Pizza {

        #region Constantes
        private const string Descricao = "Pizza";
        private const int MaxIngredientes = 8;
        private const double PrecoBase = 29d;
        private const double ValorPorAdicional = 5d;
        #endregion

        #region Atributos
        private int _quantidadeIngredientes;
        #endregion

        #region Construtores
        /// <summary>
        /// Construtor padrão.Cria uma pizza sem adicionais.
        /// </summary>
        public Pizza() {
            Init(0);
        }

        /// <summary>
        /// Cria uma pizza com a quantidade de adicionais pré-definida.Em caso de valor inválido, a pizza será criada sem adicionais.
        /// </summary>
        /// <param name="quantosAdicionais">Quantidade de adicionais (entre 0 e 8, limites inclusivos)</param>
        public Pizza(int quantosAdicionais) {
            Init(quantosAdicionais);
        }

        /// <summary>
        /// Inicializador privado da pizza: valida a quantidade de adicionais. Em caso de não validação, a pizza será criada sem adicionais.
        /// </summary>
        /// <param name="quantosAdicionais">Quantos adicionais para iniciar a pizza. Em caso de não validação, a pizza será criada sem adicionais.</param>
        private void Init(int quantosAdicionais) {
            if (PodeAdicionar(quantosAdicionais))
                _quantidadeIngredientes = quantosAdicionais;
        }
        #endregion

        #region Métodos de negócio
        /// <summary>
        /// Calcula o valor dos adicionais para o preço final da pizza. Atualmente o valor dos adicionais é a multiplicação da quantidade de adicionais por seu valor unitário
        /// </summary>
        /// <returns>Double com o valor a ser cobrado pelos adicionais.</returns>
        private double ValorAdicionais() {
            return _quantidadeIngredientes * ValorPorAdicional;
        }

        /// <summary>
        ///Faz a verificação de limites para adicionar ingredientes na pizza.Retorna TRUE/FALSE conforme seja possível ou não adicionar 
        ///esta quantidade de ingredientes.
        /// </summary>
        /// <param name="quantos">Quantidade de ingredientes a adicionar.</param>
        /// <returns>TRUE/FALSE conforme seja possível ou não adicionar esta quantidade de ingredientes.</returns>
        private bool PodeAdicionar(int quantos) {
            return (quantos + _quantidadeIngredientes >= 0 &&
                    quantos + _quantidadeIngredientes <= MaxIngredientes);
        }
        
        /// <summary>
        /// Retorna o valor final da pizza, incluindo seus adicionais.
        /// </summary>
        /// <returns>Double com o valor final da pizza.</returns>
        public double ValorFinal() {
            return PrecoBase + ValorAdicionais();
        }

        /// <summary>
        /// Tenta adicionar ingredientes na pizza.Caso a adição seja inválida(ultrapassando limites ou com valores negativos), mantém
        /// a quantidade atual de ingredientes.Retorna a quantidade de ingredientes após a execução do método.
        /// </summary>
        /// <param name="quantos">Quantos ingredientes a serem adicionados (>0)</param>
        /// <returns>Quantos ingredientes a pizza tem após a execução</returns>
        public int AdicionarIngredientes(int quantos) {
            if (PodeAdicionar(quantos)) {
                _quantidadeIngredientes += quantos;
            }
            return _quantidadeIngredientes;
        }

        /// <summary>
        /// Nota simplificada de compra: descrição da pizza, dos ingredientes e do preço.
        /// </summary>
        /// <returns>String no formato "<DESCRICAO> <PRECO> com <QUANTIDADE> ingredientes <PRECO></PRECO>, no valor total de <VALOR>"</returns>
        public string NotaDeCompra() {
            return $"{Descricao} ({PrecoBase:C2}) com {_quantidadeIngredientes} ingredientes ({ValorAdicionais():C2}), no valor total de {ValorFinal():C2}.";
        }
        #endregion
    }

}
