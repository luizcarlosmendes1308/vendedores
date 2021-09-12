using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjVendedores
{
    class Vendedor
    {
        private int id;
        private string nome;
        private double percComissao;
        private Venda[] asVendas;

        public int Id 
        { 
            get => id; 
            set => id = value; 
        }
        public string Nome 
        { 
            get => nome; 
            set => nome = value; 
        }
        public double PercComissao 
        { 
            get => percComissao; 
            set => percComissao = value; 
        }
        public Venda[] AsVendas 
        { 
            get => asVendas; }

        public Vendedor(int id, string nome, double percComissao)
        {
            this.id = id;
            this.nome = nome;
            this.percComissao = percComissao;
            initAsVendas(31);
        }
        public Vendedor() : this(-1, "...", 0)
        { }

        private void initAsVendas(int qtdeDia)
        {
            asVendas = new Venda[qtdeDia];
            for(int i = 0; i < qtdeDia; i++)
            {
                asVendas[i] = new Venda();
            }
        }

        public void registrarVenda(int dia, Venda venda)
        {
            if(dia >= 1 && dia <= asVendas.Length)
            {
                asVendas[dia - 1] = venda;
            }
        }

        public double valorVendas()
        {
            double valorTotal = 0;

            foreach(Venda venda in asVendas)
            {
                valorTotal += venda.Valor;
            }

            return valorTotal;
        }

        public double valorComissao()
        {
            return valorVendas() * (percComissao / 100);
        }

        public override bool Equals(object obj)
        {
            return obj is Vendedor vendedor &&
                   id.Equals(vendedor.id);
        }
    }
}
