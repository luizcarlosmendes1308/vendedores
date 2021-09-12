using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjVendedores
{
    class Vendedores
    {
        private Vendedor[] osVendedores;
        private int max;
        private int qtde;

        public int Max 
        { 
            get => max;
        }
        public int Qtde 
        { 
            get => qtde;
        }
        internal Vendedor[] OsVendedores 
        { 
            get => osVendedores; 
        }

        public Vendedores()
        {
            this.max = 10;
            this.qtde = 0;
            this.osVendedores = new Vendedor[max];
            for(int i = 0; i < this.max; i++)
            {
                this.osVendedores[i] = new Vendedor();
            }
        }

        public bool addVendedor(Vendedor v)
        {
            bool podeAdicionar = (qtde < max);
            if(podeAdicionar)
            {
                this.osVendedores[qtde] = v;
                qtde++;
            }
            return podeAdicionar;
        }

        public bool delVendedor(Vendedor v)
        {
            bool vendedorDeletado = false;
            int i = 0;

            foreach(Vendedor vendedor in osVendedores)
            {
                // corrigindo a ordem do array após deletar um vendedor
                if(vendedorDeletado)
                {
                    if(!osVendedores[i].Equals(osVendedores[i-1]))
                    {
                        Vendedor aux = osVendedores[i-1];
                        osVendedores[i - 1] = osVendedores[i];
                        osVendedores[i] = aux;
                    }
                }

                if(vendedor.Equals(v) && vendedor.valorVendas() == 0)
                {
                    vendedor.Id = -1;
                    vendedor.Nome = "...";
                    vendedor.PercComissao = 0;
                    vendedorDeletado = true;
                    qtde--;
                }
                i++;
            }

            return vendedorDeletado;
        }

        public Vendedor searchVendedor(Vendedor v)
        {
            Vendedor vendedorAchado = new Vendedor();
            int i = 0;
            while(i < max && !osVendedores[i].Equals(v))
            {
                i++;
            }
            if(i < max)
            {
                vendedorAchado = osVendedores[i];
            }
            return vendedorAchado;
        }

        public double valorVendas()
        {
            double valorTotal = 0;
            foreach(Vendedor vendedor in osVendedores)
            {
                valorTotal += vendedor.valorVendas();
            }
            return valorTotal;
        }

        public double valorComissao()
        {
            double valorTotal = 0;
            foreach (Vendedor vendedor in osVendedores)
            {
                valorTotal += vendedor.valorComissao();
            }
            return valorTotal;
        }
    }
}
