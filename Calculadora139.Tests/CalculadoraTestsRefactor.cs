// 1 - bibliotecas
using NUnit.Framework;
using Calc; //namespace da Calculadora de desenvolvimento

// 2 - namespace
namespace Calculadora139s.Tests;


// 3 - classe
[TestFixture] //Marcação que a classe trabalha com testes parametrizados
public class Tests
{
    // 3.1 - Atributos


    // 3.2 - Funções e Métodos

    // Função de Leitura de Dados a partir de um arquivo CSV
    public static IEnumerable<TestCaseData> lerDadosDeTestes(String operacao)
    {

        String caminhoMassa = @"C:\Iterasys\ProjetoCalculadora\Calculadora139.Tests\fixtures\"; // caminho do arquivo csv

        switch (operacao)
        {
            case "+":
                caminhoMassa += @"massaSomar.csv";

                break;
            case "-":
                caminhoMassa += @"massaSubtrair.csv"; //apenas um exemplo

                break;
            case "*":
                caminhoMassa += @"massaMultiplicar.csv"; //apenas um exemplo

                break;
            case "/":
                caminhoMassa += @"massaDividir.csv"; //apenas um exemplo

                break;

        }
        using (var leitor = new StreamReader(caminhoMassa))
        {
            //pular a primeira linha - cabeçalho
            leitor.ReadLine();

            //repetir as ações até a condição se realizar
            //no caso seria até o csv terminar
            //repita
            //enquanto
            //     não    for o final
            while (!leitor.EndOfStream) //repita enquanto não for o final
            {

                var linha = leitor.ReadLine(); //lendo uma linha
                var valores = linha.Split(","); //dividir em campos

                yield return new TestCaseData(int.Parse(valores[0]),
                                            int.Parse(valores[1]),
                                            int.Parse(valores[2]));
            }
        }

    }
    //Teste Data Driven
    //Configura
    [Test, TestCaseSource("lerDadosDeTestes", new object[] { "+" })]
    public void testSomarDoisNumerosDDD(int num1, int num2, int resultadoEsperado)
    {

        //Executa
        int resultadoAtual = Calculadora.somarDoisNumeros(num1, num2);

        //Valida
        Assert.That(resultadoAtual, Is.EqualTo(resultadoEsperado));

    }

    //Teste Data Driven
    //Configura
    [Test, TestCaseSource("lerDadosDeTestes", new object[] { "-" })]
    public void testSubtrairDoisNumeross(int num1, int num2, int resultadoEsperado)
    {

        //Executa
        int resultadoAtual = Calculadora.subtrairDoisNumeros(num1, num2);

        //Valida
        Assert.That(resultadoAtual, Is.EqualTo(resultadoEsperado));

    }


    //Teste Data Driven
    //Configura
    [Test, TestCaseSource("lerDadosDeTestes", new object[] { "*" })]
    public void testMultiplicarDoisNumeross(int num1, int num2, int resultadoEsperado)
    {

        //Executa
        int resultadoAtual = Calculadora.multiplicarDoisNumeros(num1, num2);

        //Valida
        Assert.That(resultadoAtual, Is.EqualTo(resultadoEsperado));

    }

    //Teste Data Driven
    //Configura
    [Test, TestCaseSource("lerDadosDeTestes", new object[] { "/" })]
    public void testDividirDoisNumeross(int num1, int num2, int resultadoEsperado)
    {

        //Executa
        int resultadoAtual = Calculadora.dividirDoisNumeros(num1, num2);

        //Valida
        Assert.That(resultadoAtual, Is.EqualTo(resultadoEsperado));

    }

}