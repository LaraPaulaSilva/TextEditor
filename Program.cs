using System;
using System.ComponentModel.Design;
using System.IO.Compression;
using System.IO;

namespace TestEditor
{
    class Program // classe principal 
    {
        static void Main(string[] args) //metodo do ponto de entraada do programa
        {
            Menu(); //assim que inicia chama o metodo menu
        }
        static void Menu() //metodo 
        {
            Console.Clear(); // limpa a tela 
            Console.WriteLine("O que você deseja fazer?"); // mostra as opções
            Console.WriteLine("1 - Abrir arquivo?");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");
            short option = short.Parse(Console.ReadLine()!); // Lê a opção digitada e converte o texto em short

            switch (option) //direciona para os metodos respectivos aos numeros das opções
            {
                case 0: System.Environment.Exit(0); break; //programa encerra imediatamente
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;
            }
        }

        static void Abrir() // metodo abrir
        {
            Console.Clear();

            //pede o caminho do arquivo
            Console.WriteLine("qual o caminho do arquivo?");
            string path = Console.ReadLine()!; // path é uma variavél que armazena o caminho e nao é uma palavra reservada 

            // leitura do arquivo:
            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd(); // lê todo o arquivo
                Console.WriteLine(text);
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();

        }
        static void Editar() // metodo editar 
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
            Console.WriteLine("-----------------");
            //armaxena tudo que é digitado 
            string text = "";

        //
            do
            {
                text += Console.ReadLine(); // o user digita em uma linha e fica salvo em text 
                text += Environment.NewLine; // adiciona uma quebra de linha correta
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape); // ate apertar esc o loop continua rodando

            Console.WriteLine(text); // mostra o texto digitado
            Salvar(text); // chama o metodo para salvar
        }

        static void Salvar(string text) // metodo salvar
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo");
           //Pede o caminho onde o arquivo será salvo
            var path = Console.ReadLine();

        //escreve no arquivo 
            using (var file = new StreamWriter(path)) //StreamWriter cria ou sobrescreve o arquivo
            {
                file.WriteLine(text); // grava o texto no arquivo 
            }

            Console.WriteLine($" Arquivo {path} Salvo com sucesso");
            Console.ReadLine();
            Menu();
        }
    }

}