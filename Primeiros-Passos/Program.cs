using System;

namespace Primeiros_Passos
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcoes();

            Aluno[] alunos = new Aluno[5];
            int indiceAlunos = 0; // Índice criado para controlar a entrada de obj no array.

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        Aluno aluno = new Aluno(); //Criando uma Instancia da struct aluno um obj do tipo aluno.
                        aluno.Nome = Console.ReadLine(); //aluno.Nome receberá uma entrada de dados do usuário.
                        Console.WriteLine();

                        Console.WriteLine("Informe a nota do aluno:");

                        //TryParse converterá os caracteres de um número no decimal,
                        //e retornará um valor avisando se foi bem sucedida ou não a conversão.
                        //Se ele conseguir fazer a conversão, ele preencherá a variável notaConvertida
                        //que será armazenada na struct aluno.Nota.
                        if(decimal.TryParse(Console.ReadLine(), out decimal notaConvertida))
                        {
                            aluno.Nota = notaConvertida;
                        }
                        //Se não consiguir fazer a conversão, cairá nessa Exception, que exibirá uma mensagem de erro.
                        else 
                        {
                            throw new ArgumentException("O valor da nota deve ser decimal!");
                        }

                        //Encaixando esse objeto aluno em alguma posição no array alunos.
                        alunos[indiceAlunos] = aluno; //Armazenando o objeto aluno no array alunos, na posição indiceAlunos que começa do 0.
                        indiceAlunos++; //Incrementando para que o próximo aluno que dor incluso, seja armazenado no próximo índice, e assim por diante.

                        break;   
                    case "2":
                    //Para cada aluno no meu array, imprimirá uma linha passando o nome do aluno e a nota.
                        foreach(Aluno aluno1 in alunos)
                        {
                            //Se o valor da string não for nulo e nem vazio, ele escreverá a linha normalamente.
                            if(!string.IsNullOrEmpty(aluno1.Nome))
                            {
                                Console.WriteLine($"NOME: {aluno1.Nome} | NOTA: {aluno1.Nota}");
                            }
                        }
                        break;   
                    case "3":
                        decimal notaTotal = 0;
                        var numeroDeAlunos = 0;

                        //foreach(Aluno aluno2 in alunos){}
                        for(int i = 0; i< alunos.Length; i++){
                            //Se o valor da string não for nulo e nem vazio, ele seguirá a linha de código normalamente.
                            if(!string.IsNullOrEmpty(alunos[i].Nome)){
                                //notaTotal armazenará a nota total de cada aluno, acessando os índices do array alunos para obter as notas.
                                notaTotal = notaTotal + alunos[i].Nota; 
                                numeroDeAlunos++;
                            }
                        }

                        var media = notaTotal / numeroDeAlunos;
                        Conceitos conceitos;
                        if(media < 3)
                        {
                            conceitos = Conceitos.D;
                        }
                        else if(media < 5)
                        {
                            conceitos = Conceitos.C;
                        }
                        else if(media < 7)
                        {
                            conceitos = Conceitos.B;
                        }
                        else
                        {
                            conceitos = Conceitos.A;
                        }

                        Console.WriteLine($"Média Geral: {media} | Conceito: {conceitos}");
                        break;   
                        default:
                        //Caso o usuário não digite as entradas correspondentes no case, cairá no default, que exibirá uma Exception.
                            throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcoes();
            }
        }

        private static string ObterOpcoes()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada!");
            Console.WriteLine("1- Inserir novo aluno.");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral.");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

           string opcaoUsuario = Console.ReadLine(); //receber uma entrada do usuário.
           Console.WriteLine();
           return opcaoUsuario;
        } 
    }
}
