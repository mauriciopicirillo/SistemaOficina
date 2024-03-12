using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaOficina.Models
{
    public class Orcamento
    {
        public Orcamento()
        {
        }

        public Orcamento(int idos, DateTime data, string tipo, string situacao, string nomecli,
            string telefonecli, string modelo, string placa, string marca, string ano, string motor,
            string cor, string defeito, string descricao, int quantidade, decimal valor_unitario,
            decimal valor_total, decimal total, string mecanico, string observacao, int idcli)
        {
            IdOs = idos;
            Data = data;
            Tipo = tipo;
            Situacao = situacao;
            Nomecli = nomecli;
            Telefonecli = telefonecli;
            Modelo = modelo;
            Placa = placa;
            Marca = marca;
            Descricao = descricao;
            Quantidade = quantidade;
            Valor_unitario = valor_unitario;
            Valor_total = valor_total;
            Total = total;
            Mecanico = mecanico;
            Observacao = observacao;
            IdCli = idcli;

        }
        public int IdOs { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; }
        public string Situacao { get; set; }
        public string Nomecli { get; set;}
        public string Telefonecli { get;set;}
        public string Modelo { get; set;}   
        public string Placa { get; set;}
        public string Marca { get; set;}
        public string Descricao { get; set;}
        public int Quantidade { get; set;}
        public decimal Valor_unitario { get; set; }
        public decimal Valor_total { get; set; }
        public decimal Total { get; set;}
        public string Mecanico { get; set;}
        public string Observacao { get;set;}
        public int IdCli { get; set;}
    }
}
