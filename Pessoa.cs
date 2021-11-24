using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Limpex
{
    class Pessoa
    {
        private string Nome;    
        private static Data Data_nascimento;
        private int Idade;
        private char Sexo;
        private string ID;
        public Pessoa()
        {

        }

        public Pessoa(string nome, Data dn, int idade, char sexo, string id)
        {
            Nome = nome;
            Data_nascimento = dn;
            Idade = idade;
            Sexo = sexo;
           
        }

        public string getNome()
        {
            return Nome;
        }

        public void setNome(string nome)
        {

            if (nome.Length < 3)
            {
                throw new Nomeinvalido();
            }

            for (int i = 0; i < nome.Length; i++)
            {
                if (char.IsNumber(nome, i))
                {
                    throw new Nomeinvalido();
                }
            }
            Nome = nome;


        }

        public Data getDataDeNascimento()
        {
            return Data_nascimento;
        }

        public bool setDataDeNascimento(Data nascimento)
        {
            Idade = DateTime.Today.Year - nascimento.getAno();
            if (DateTime.Today.Month < nascimento.getMes() ||
               (DateTime.Today.Month == nascimento.getMes() &&
                DateTime.Today.Day < nascimento.getDia()))
            {
                Idade--;
            }

            if (Idade < 18)
            {
                return false;
            }
            else
            {
                Data_nascimento = nascimento;
                return true;
            }
        }

        public char getsexo()
        {

            return Sexo;
        }

        public bool setSexo(char s)
        {

            if (s == 'M' || s == 'F' || s == 'f' || s == 'm')
            {
                Sexo = s;
                return true;
            }
            return false;
        }

        public int getIdade()
        {
            return Idade;
        }
        public void setIdade(int num)
        {
            Idade = num;
        }
             
    }
}

