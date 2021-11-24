using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Limpex
{
    class Diarista:Pessoa,IAutenticar
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
        private double ValorDiaria;
        private string TipoServico;

        public Diarista()
        {

        }

        public Diarista(double avali, double valor_di,string tipo_s, string nome, Data dn, int idade,
                         char sexo, string id) : base(nome, dn, idade, sexo, id)
        {
            Avaliacao = avali ;
            ValorDiaria = valor_di;
            TipoServico = tipo_s;
        }

        public double getAvaliacao()
        {
            return Avaliacao;
        }
        public void setAvaliacao(double av)
        {
            Avaliacao = av;
        }

        public double getValorDiaria()
        {
            return ValorDiaria;
        }

        public void setValorDiaria( double v)
        {
            ValorDiaria = v;
        }


        public string getTipoServico()
        {
            return TipoServico;
        }

        public void setTipoServico(string tipo)
        {
            TipoServico = tipo;
        }

        public bool VerificaServico(string nivel)
        {

            switch (nivel)
            {
                case "Faxina":
                case "Jardinagem":
                case "faxina":
                case "jardinagem":
                    setTipoServico(nivel);
                    return true;
                default:
                    break;
            }

            return false;
        }

        public bool Autenticar(string login, string senha)
        {
            List<Diarista> Todos = CaregarDados();
            Diarista P1;
            P1 = Todos.Find(y => y.Login.Contains(login));
            
            if (P1.Senha == senha)
            {
                return true;
            }

            return false;
        }
        public void AvaliarDiarista(string log, double not)
        {
            
            List<Diarista> Todos = CaregarDados();
            Diarista P1 = new Diarista();
            
            P1 = Todos.Find(y => y.Login.Contains(log));
            double aux = P1.Avaliacao + not;
            P1.setAvaliacao(aux) ;

            AtualizaDiarista(Todos);

        }
        public void AtualizaDiarista(List<Diarista> car)
        {

            FileStream Arq1 = new FileStream("../../Diarista.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw1 = new StreamWriter(Arq1, Encoding.UTF8);

            foreach (Diarista lista in car)
            {
                sw1.WriteLine(lista);
            }

            sw1.Close();
            Arq1.Close();
        }
        public List<Diarista> CaregarDados()
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
                P22.setTipoServico(aux[4]);
                P22.setValorDiaria(Convert.ToInt32(aux[5]));               
                P22.login = aux[6];
                P22.senha = aux[7];
                TodosDiarista.Add(P22);
            }
            return TodosDiarista;
        }
        public void ValidarLogin(string login)
        {
            if (login.Length < 3 && login.Length > 6)
            {
                throw new LoginInvalido();
            }
            List<string> ID = new List<string>();

            string[] ListaID = File.ReadAllLines("../../ListaDeId.txt");

            for (int i = 0; i < ListaID.Length; i++)
            {
                ID.Add(ListaID[i]);
            }

            if (!ID.Contains(login))
            {
                FileStream Arq1 = new FileStream("../../ListaDeId.txt", FileMode.Append,
                                                 FileAccess.Write);
                StreamWriter sw1 = new StreamWriter(Arq1, Encoding.UTF8);

                sw1.WriteLine(login);

                sw1.Close();
                Arq1.Close();

                Login = login;
               
            }
            else
            {
                
                throw new LoginInvalido();
            }
        }

        public void Excluir (string senha, string login)
        {

        }

        public List<Diarista> MelhoresDiarista()
        {
            List<Diarista> Todos = CaregarDados();

            List<Diarista> sorted = Todos.OrderByDescending(x => x.Avaliacao).ToList();
            
            return sorted;
        }
        public string ListaMelhores()
        {
            return "Nome: " +getNome()+ "|Idade: "+getIdade()+" Anos | Avaliação: "+ Avaliacao+" Estrela | Serviço Prestado: "+TipoServico+" | Valor Diaria R$ "+ ValorDiaria;
                  
        }
        public string Trasformar()
        {
            return " Nome: " + getNome() + " | Data de nascimento: " + getDataDeNascimento()
                 + "|Idade: " + getIdade() + " Anos |  " + " | Avaliação: "
                   + Avaliacao + " | Serviço Prestado " + TipoServico + "| Valor Diaria R$ " + ValorDiaria + 
                   "| Login " + Login + "| Senha " + Senha;
        }

        public override string ToString()
        {
            return getNome() + " | " + getDataDeNascimento() + " | " + getIdade() +
                    "|" + Avaliacao + "|" + TipoServico + "|" + ValorDiaria + "|" + Login + "|" + Senha;
        }

    }
}
