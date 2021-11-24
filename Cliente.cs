using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Limpex
{
    class Cliente:Pessoa,IAutenticar
    {
        private string Login;
        public string login
        {
            get
            {
                return Login;
            }

            set
            {
                             
                Login = value;
            }
        }

        private string Senha;
        public string senha
        {
            get
            {
                return Senha;
            }

            set
            {
                if (value.Length < 3 && value.Length > 6)
                {
                    throw new SenhaInvalida();
                }               
                Senha = value;
            }
        }
        private double Avaliacao;
        private string Imovel;  
       
        public Cliente()
        {

        }
        public Cliente(double av, string imo, string nome, Data dn, int idade,
                        char sexo, string id) : base(nome, dn, idade, sexo, id)
        {
            Avaliacao = av;
            Imovel = imo;            
            
        }

        public double getAvaliacao()
        {
            return Avaliacao;
        }

        public void setAvaliacao(double av)
        {
            Avaliacao = av;
            
        }

        public string getImovel()
        {

            return Imovel;
        }

       public void setimovel( string imo)
        {
            Imovel = imo;
        }
        public bool setImovel(string imo)
        {
            if (imo == "Casa" || imo == "Apartamento" || imo == "casa" || imo == "apartamento" )
            {
                Imovel = imo;
                return true;
            }
            return false;

           
        }
        public void ValidarLogin(string log)
        {
            if (log.Length < 3 && log.Length > 6)
            {
                throw new LoginInvalido();
            }
            List<string> ID = new List<string>();

            string[] ListaID = File.ReadAllLines("../../ListaDeId.txt");

            for (int i = 0; i < ListaID.Length; i++)
            {
                Console.WriteLine(ListaID[i]);
                ID.Add(ListaID[i]);
            }
            
            if (!ID.Contains(log))
            {
                FileStream Arq1 = new FileStream("../../ListaDeId.txt", FileMode.Append,
                                                 FileAccess.Write);
                StreamWriter sw1 = new StreamWriter(Arq1, Encoding.UTF8);

                sw1.WriteLine(log);

                sw1.Close();
                Arq1.Close();

                Login = log;
                

            }
            else
            {
                
                throw new LoginInvalido();
            }

        }
        public void Atualizar(string senha, string login)
        {

        }

        public void Excluir(string senha, string login)
        {

        }

        public bool Autenticar(string login, string senha)
        {
           
                List<Cliente> Todos = CaregarDados();
                Cliente P1;
                P1 = Todos.Find(y => y.Login.Contains(login));
                Console.WriteLine(P1);

                if (P1.Senha == senha)
                {
                    return true;
                }               
            
                return false;

        }

        public List<Cliente> CaregarDados()
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
            return TodosClientes;
        }

        public string RelatorioCliente()
        {
            return " Nome: " + getNome() + "| Data de nascimento: " + getDataDeNascimento()
                   + "| Idade: " + getIdade() + "| Avaliação: "+ getAvaliacao() + "| Imovel: " + Imovel + 
                   "| Login:" + Login + "| Senha:" + Senha;
        }

        public override string ToString()
        {
            return getNome() + "|" + getDataDeNascimento() + "|" + getIdade() +
                   " | " + getAvaliacao() + " | " + getImovel() + "|" + login + "|" + senha;
        }



    }
}

