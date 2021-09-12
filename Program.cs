using System;

namespace ProjVendedores
{
    class Program
    {
        static void Main(string[] args)
        {
            bool sair = false;
            int op;

            Vendedores vendedores = new Vendedores();

            while(!sair)
            {

                Console.WriteLine("\n0. Sair \n1.Cadastrar vendedor \n2.Consultar vendedor \n3.Excluir vendedor \n4.Registrar venda \n5.Listar vendedores");
                op = int.Parse(Console.ReadLine());
                

                switch(op)
                {
                    case 0:
                        sair = true;
                        break;
                    case 1:
                        cadastrarVendedor(vendedores);
                        break;
                    case 2:
                        consultarVendedor(vendedores);
                        break;
                    case 3:
                        excluirVendedor(vendedores);
                        break;
                    case 4:
                        registrarVenda(vendedores);
                        break;
                    case 5:
                        listarVendedores(vendedores);
                        break;
                    default:
                        Console.WriteLine("Digite uma opção válida.");
                        break;
                }
            }

            void cadastrarVendedor(Vendedores vendedores)
            {
                Console.WriteLine("\nId do vendedor: ");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Nome do vendedor: ");
                string nome = Console.ReadLine();

                Console.WriteLine("Percentual de comissão do vendedor: ");
                double percComissao = double.Parse(Console.ReadLine());

                Console.WriteLine(vendedores.addVendedor(new Vendedor(id, nome, percComissao)) ? "Vendedor adicionado" : "Não foi possível adicionar, máximo de vendedores atingido.");
            }

            void consultarVendedor(Vendedores vendedores)
            {
                Console.WriteLine("\nDigite o id do vendedor para busca: ");
                int id = int.Parse(Console.ReadLine());

                Vendedor vAchado = vendedores.searchVendedor(new Vendedor(id, "", 0));

                if(vAchado.Id == -1)
                {
                    Console.WriteLine("Vendedor não encontrado.");
                    return;
                }
                
                Console.WriteLine($"\nId: {vAchado.Id} \nNome: {vAchado.Nome} \nValor total das vendas: R$ {vAchado.valorVendas()} \nValor da comissão: R$ {vAchado.valorComissao()}");
                Console.WriteLine("Valor médio das vendas diárias: ");
                int dia = 1;
                foreach(Venda venda in vAchado.AsVendas)
                {
                    if(venda.Valor > 0)
                    {
                        Console.WriteLine($"{dia}° dia: {venda.valorMedio()}");
                    }
                    dia++;
                }
            }

            void excluirVendedor(Vendedores vendedores)
            {
                Console.WriteLine("\nDigite o id do vendedor para ser deletado: ");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine(vendedores.delVendedor(new Vendedor(id, "", 0)) ? "Vendedor deletado." : "Não foi possível deletar.");
            }

            void registrarVenda(Vendedores vendedores)
            {
                int dia;

                Console.WriteLine("\nDigite o id do vendedor: ");
                int id = int.Parse(Console.ReadLine());
                do
                {
                    Console.WriteLine("Digite o dia (1-31): ");
                    dia = int.Parse(Console.ReadLine());
                } while (dia < 1 || dia > 31);

                Console.WriteLine("Digite a quantidade de vendas: ");
                int qtde = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o valor de venda do dia: ");
                double valor = double.Parse(Console.ReadLine());

                Vendedor v = vendedores.searchVendedor(new Vendedor(id, "", 0));
                if(v.Id == -1)
                {
                    Console.WriteLine("Vendedor não encontrado.");
                    return;
                }

                v.registrarVenda(dia, new Venda(qtde, valor));
                Console.WriteLine("Venda registrada com sucesso.");
            }

            void listarVendedores(Vendedores vendedores)
            {
                foreach(Vendedor v in vendedores.OsVendedores)
                {
                    if(v.Id != -1)
                    {
                        Console.WriteLine($"\nId: {v.Id} \nNome: {v.Nome} \nValor total das vendas: R$ {v.valorVendas()} \nValor da comissão: R$ {v.valorComissao()}");
                    }
                }

                Console.WriteLine($"\nValor total das vendas de todos os vendedores: {vendedores.valorVendas()}");
                Console.WriteLine($"Valor total das comissões de todos os vendedores: {vendedores.valorComissao()}");
            }
        }
    }
}
