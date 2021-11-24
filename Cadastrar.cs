using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Limpex
{
     class Cadastrar
    {
        public List<Cliente> cliente = new List<Cliente>();
        private List<Diarista> diarista = new List<Diarista>();


        public Cadastrar()
        {

        }

        public List<Cliente> getCliente()
        {
            return cliente;
        }

        public void setCliente(Cliente c)
        {
            cliente.Add(c);

        }
        public List<Diarista> getDiarista()
        {
            return diarista;
        }

        public void setDiarista(Diarista d)
        {
            diarista.Add(d);

        }

        public void RegistrarCliente()
        {
            FileStream Arq1 = new FileStream("../../Cliente.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw1 = new StreamWriter(Arq1, Encoding.UTF8);
            foreach (var i in cliente)
            {
                sw1.WriteLine(i);
            }

            sw1.Close();
            Arq1.Close();

        }

        public void Atualizar_Arquivo_Cliente(List<Cliente> car)
        {

            FileStream Arq1 = new FileStream("../../Cliente.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw1 = new StreamWriter(Arq1, Encoding.UTF8);

            foreach (Cliente lista in car)
            {
                sw1.WriteLine(lista);
            }

            sw1.Close();
            Arq1.Close();
        }

        public static void RelacaoCliente()
        {
            List<Cliente> TodosClientes = new List<Cliente>();

            Data t = new Data();
            string[] ListaP = File.ReadAllLines("../../Cliente.txt");
            for (int i = 0; i < ListaP.Length; i++)
            {
                Cliente P22 = new Cliente();
                string[] aux = ListaP[i].Split('|');
                P22.setNome(aux[0]);
                t.setData(aux[1]);
                P22.setDataDeNascimento(t);
                P22.setIdade(Convert.ToInt32(aux[2]));                
                P22.setAvaliacao(Convert.ToInt32(aux[3]));
                P22.setimovel(aux[4]);
                P22.login = aux[5];
                P22.senha = aux[6];
                TodosClientes.Add(P22);
            }
            
            Console.WriteLine("CLIENTES ATUAIS:");
            foreach (var lista in TodosClientes)
            {
                Console.WriteLine(lista.RelatorioCliente());
            }



        }
        public void RegistraDiarista()
        {
            FileStream Arq1 = new FileStream("../../Diarista.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw1 = new StreamWriter(Arq1, Encoding.UTF8);
            foreach (var i in diarista)
            {
                sw1.WriteLine(i);
            }

            sw1.Close();
            Arq1.Close();

        }
        public void Atualizar_Arquivo_Diarista(List<Cliente> car)
        {

            FileStream Arq1 = new FileStream("../../Diarista.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw1 = new StreamWriter(Arq1, Encoding.UTF8);

            foreach (Cliente lista in car)
            {
                sw1.WriteLine(lista);
            }

            sw1.Close();
            Arq1.Close();
        }

        public static void RelacaoDiarista()
        {
            List<Diarista> TodosDiarista = new List<Diarista>();

            Data t = new Data();
            string[] ListaP = File.ReadAllLines("../../Diarista.txt");
            for (int i = 0; i < ListaP.Length; i++)
            {
                Diarista P22 = new Diarista();
                string[] aux = ListaP[i].Split('|');
                P22.setNome(aux[0]);
                t.setData(aux[1]);
                P22.setDataDeNascimento(t);
                P22.setIdade(Convert.ToInt32(aux[2]));                
                P22.setAvaliacao(Convert.ToInt32(aux[3]));
                P22.setValorDiaria(Convert.ToInt32(aux[4]));
                P22.login = aux[5];
                P22.senha = aux[6];
                TodosDiarista.Add(P22);
            }
            Console.WriteLine("DIARISTA ATUAIS:");
            foreach (var lista in TodosDiarista)
            {
                Console.WriteLine(lista.Trasformar());
            }



        }

    }
}
