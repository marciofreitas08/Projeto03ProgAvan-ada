using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Limpex
{
    class Program
    {
        static void Main(string[] args)
        {
            
            while (true)
            {
                try
                {
                    
                    MenuInicial();
                    break;
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("Erro no Login! Você retornou ao menu principal!");
                }
            }

        }

        public static void MenuInicial()
        {
            Console.WriteLine("                                      "
                              + "    _________________________________");
            Console.WriteLine();
            Console.WriteLine("                                      "
                              + "                Limpex               ");
            Console.WriteLine("                                      "
                              + "    _________________________________");
            Console.WriteLine();
            Console.WriteLine("                                      "
                              + "              MENU INICIAL           ");
            Console.WriteLine();
            Console.WriteLine("                                " +
                              "           1 -      Fazer Login        ");
            Console.WriteLine("                                " +
                              "           2 -  Cadastrar como Cliente ");
            Console.WriteLine("                                " +
                              "           3 -  Cadastrar como Diarista ");
            Console.WriteLine("                                " +
                              "           4 -          Sair           ");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("> Digite a opção desejada: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if (num == 1)
            {
                FazerLogin();
            }
            else if (num == 2)
            {
                CadastrarCliente();
            }
            else if (num == 3)
            {
                CadastrarDiarista();
            }
            else 
            {
                Console.WriteLine(" Sistema Finalizado");
            }

        }
        public static void MenuCliente()
        {
            Console.WriteLine("                                      "
                              + "    _________________________________");
            Console.WriteLine();
            Console.WriteLine("                                      "
                              + "                Limpex               ");
            Console.WriteLine("                                      "
                              + "    _________________________________");
            Console.WriteLine();
            Console.WriteLine("                                      "
                              + "              MENU CLIENTE           ");
            Console.WriteLine();
            Console.WriteLine("                                " +
                              "       1 -      Avaliar Diarista       ");            
            Console.WriteLine("                                " +
                              "       2 -    Ver Melhores Diaristas   ");
            Console.WriteLine("                                " +
                              "       3 -           Sair              ");
            Console.WriteLine();
            Console.Write("> Digite a opção desejada: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if (num == 1)
            {
                AvaliarDiarista();
            }           
            else if (num == 2)
            {
                VerMelhores();
            }          
                        
            else 
            {
                Console.WriteLine(" Sistema Finalizado");
            }
        }

        public static void VerMelhores()
        {
            Diarista P1 = new Diarista();
            foreach (Diarista produto in P1.MelhoresDiarista())
            {
                Console.WriteLine(produto.ListaMelhores());
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
            }
            
        }
        public static void AvaliarDiarista()
        {
            Diarista P1 = new Diarista();       
            Console.WriteLine("AVALIAR DIARISTA");
            Console.WriteLine();
            Console.Write(" Digite o Login da Diarista:");
            Console.Write("> Login: ");
            string log = Console.ReadLine();
            Console.Write(" Digite a nota pelo serviço: EX: 0 - Menor e 10 - Maior");
            Console.Write("> Nota: ");
            double nota = double.Parse(Console.ReadLine());
            P1.AvaliarDiarista(log, nota);
            MenuCliente();
        }

        public static void FazerLogin()
        {
            Console.WriteLine("FAZER LOGIN");
            Console.WriteLine();
            Console.Write(" Digite se Login contendo 4 caracter:");
            Console.Write("> Login: ");
            string log = Console.ReadLine();
            Console.Write(" Digite sua senha contendo 4 caracter:");
            Console.Write("> Senha: ");
            string sen = Console.ReadLine();
            Console.WriteLine(" 1 - Diarista : 2 - Cliente ");
            Console.WriteLine();
            string res = Console.ReadLine();
            if(res == "2")
            {
                Cliente novo = new Cliente();
                while (!novo.Autenticar(log, sen))
                {
                    Console.WriteLine("Login ou senha  inválido!");
                    Console.Write(" Digite se Login contendo 4 caracter:");
                    Console.Write("> Login: ");
                    log = Console.ReadLine();
                    Console.Write(" Digite sua senha contendo 4 caracter:");
                    Console.Write("> Senha: ");
                    sen = Console.ReadLine();

                }
            }
            else if (res == "1"){
                Diarista novo = new Diarista();
                while (!novo.Autenticar(log, sen))
                {
                    Console.WriteLine("Login ou senha  inválido!");
                    Console.Write(" Digite se Login contendo 4 caracter:");
                    Console.Write("> Login: ");
                    log = Console.ReadLine();
                    Console.Write(" Digite sua senha contendo 4 caracter:");
                    Console.Write("> Senha: ");
                    sen = Console.ReadLine();

                }
            }
         
            Console.WriteLine(" Autenticação feita com Sucesso:");
            MenuCliente();
           
        }
        public static void CadastrarCliente()
        {
            Console.WriteLine("CADASTRAR CLIENTE");
            Console.WriteLine();

            Cliente P2 = new Cliente();
            Cadastrar cadastro = new Cadastrar();
            Login(P2);
            Senha(P2);
            Sexo(P2);           
            Nome(P2);           
            Dat(P2);         

            Console.WriteLine(" Registre seu imovel. EX: Casa, Apartamento:");
            string imo = Console.ReadLine();

            while (!P2.setImovel(imo))
            {
                Console.WriteLine("Imovel inválido!");
                Console.WriteLine(" Registre seu imovel. EX: Casa, Apartamento:");
                Console.Write("> Por favor, tente novamente: ");
                imo = Console.ReadLine();
            }

            cadastro.setCliente(P2);
            cadastro.RegistrarCliente();

            Console.WriteLine(" Cadastro feito com sucesso:");
           
        }
        static void CadastrarDiarista()
        {
            Console.WriteLine("CADASTRAR DIARISTA");
            Console.WriteLine();

            Diarista P2 = new Diarista();
            Cadastrar cadastro = new Cadastrar();
            Login(P2);
            Senha(P2);
            Sexo(P2);
            Nome(P2);           
            Dat(P2);

            Console.WriteLine("Qual o tipo de serviço oferecido ? Faxina / Jardinagem : ");
            string Car = Console.ReadLine();
            while (!P2.VerificaServico(Car))
            {
                Console.Write("ERRO! Serviço não existe.");
                Console.WriteLine("Por favor, tente novamente: ");
                Car = Console.ReadLine();
            }

            if (P2.getTipoServico() == "Faxina" || P2.getTipoServico() == "faxina")
            {
                P2.setValorDiaria(200);
            }
            else if (P2.getTipoServico() == "Jardinagem" || P2.getTipoServico() == "jardinagem")
            {
                P2.setValorDiaria(300);
            }

            Console.WriteLine(P2);
            cadastro.setDiarista(P2);
            cadastro.RegistraDiarista();

            Console.WriteLine(" Cadastro feito com sucesso:");                     
           
        }  
        
        static void Login(IAutenticar P2)
        {
            Console.Write(" Digite se Login contendo 5 caracter:");
            Console.Write("> Login: ");
            string log = Console.ReadLine();

            while (true)
            {
                try
                {
                    P2.ValidarLogin(log);
                    break;

                }
                catch (LoginInvalido)
                {
                    Console.WriteLine(" > Login invalido");
                    Console.WriteLine("> Por favor, tente novamente: ");
                    log = Console.ReadLine();
                }
            }
        }

        static void Senha(IAutenticar P2)
        {
            Console.Write(" Digite sua senha contendo 4 caracter:");
            Console.Write("> Senha: ");
            string sen = Console.ReadLine();

            while (true)
            {
                try
                {
                    P2.senha = sen ;
                    break;

                }
                catch (SenhaInvalida)
                {
                    Console.WriteLine("Senha invalido");
                    Console.WriteLine("> Por favor, tente novamente: ");
                    Console.WriteLine("Digite sua senha com 4 caracter:");
                    sen = Console.ReadLine();
                }
            }


        }
        static void Nome(Pessoa P2)
        {
            Console.Write("> Nome: ");
            string nome = Console.ReadLine();

            while (true)
            {
                try
                {
                    P2.setNome(nome);
                    break;

                }
                catch (Nomeinvalido)
                {
                    Console.WriteLine("Nome invalido");
                    Console.WriteLine("> Por favor, tente novamente: ");
                    nome = Console.ReadLine();
                }
            }
        }
       
        static void Sexo(Pessoa P2)
        {
            Console.WriteLine("Sexo: M - Masculino | F - Feminino");
            Console.WriteLine();
            Console.Write("> Digite o sexo: ");
            char S = char.Parse(Console.ReadLine());
            while (!P2.setSexo(S))
            {
                Console.WriteLine("Caracter inválido!");
                Console.Write("> Por favor, tente novamente: ");
                S = char.Parse(Console.ReadLine());
            }
        }

        static void Dat(Pessoa P2)
        {
            Data dat = new Data();
            Console.Write("> Data de nascimento (DD/MM/AAAA): ");
            string datanascimento = Console.ReadLine();

            while (!dat.setData(datanascimento))
            {
                Console.WriteLine("Data de nascimento inválida!");
                Console.Write("> Por favor, tente novamente: ");
                datanascimento = Console.ReadLine();
            }

            Data nascimento = new Data(datanascimento);
            while (!P2.setDataDeNascimento(nascimento))
            {
                Console.WriteLine("Data de nascimento inválida!");
                Console.Write("> Por favor, tente novamente: ");
                datanascimento = Console.ReadLine();
                nascimento = new Data(datanascimento);
            }
            P2.setDataDeNascimento(nascimento);            
                      

        }
    }
}
