// 1 - bibliotecas
using NUnit.Framework;
using Calc; //namespace da Calculadora de desenvolvimento

// 2 - namespace
namespace Calculadora139.Tests;


// 3 - classe
[TestFixture] //Marcação que a classe trabalha com testes parametrizados
public class Tests
{
    // 3.1 - Atributos


    // 3.2 - Funções e Métodos

    // Função de Leitura de Dados a partir de um arquivo CSV
    public static IEnumerable<TestCaseData> lerDadosDeTeste(String operacao)
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


    [Test] //Método de Teste
    public void testSomarDoisNumeros()
    {
        // Triple A = AAA

        //Configura
        // Dados de entrada
        int num1 = 15;
        int num2 = 35;

        // Resultado esperado / saida
        int resultadoEsperado = 50;

        //Executa

        int resultadoAtual = Calculadora.somarDoisNumeros(num1, num2);

        // Valida
        Assert.That(resultadoEsperado, Is.EqualTo(resultadoAtual));


    } //fecha o teste da soma

    [Test]
    public void testSubtrairDoisNumeros()
    {
        //Configura

        int num1 = 20;
        int num2 = 8;
        int resultadoEsperado = 12;

        //Executa

        int resultadoAtual = Calculadora.subtrairDoisNumeros(num1, num2);

        //Valida

        Assert.That(resultadoEsperado, Is.EqualTo(resultadoAtual));
    }//fecha o teste subtrair

    [Test]
    public void testDividirDoisNumeros()
    {
        //Configura

        int num1 = 20;
        int num2 = 5;
        int resultadoEsperado = 4;

        //Executa

        int resultadoAtual = Calculadora.dividirDoisNumeros(num1, num2);

        //Valida

        Assert.That(resultadoEsperado, Is.EqualTo(resultadoAtual));
    }

    [Test]
    public void testMultiplicarDoisNumeros()
    {
        //Configura

        int num1 = 20;
        int num2 = 5;
        int resultadoEsperado = 100;

        //Executa

        int resultadoAtual = Calculadora.multiplicarDoisNumeros(num1, num2);

        //Valida

        Assert.That(resultadoEsperado, Is.EqualTo(resultadoAtual));
    }

    [Test]
    public void testDividirPorZero()
    {
        //Configura

        int num1 = 7;
        int num2 = 0;
        int resultadoEsperado = 0;  //o tratamento de erro retornará 0

        //Executa

        int resultadoAtual = Calculadora.dividirDoisNumeros(num1, num2);

        //Valida

        Assert.That(resultadoEsperado, Is.EqualTo(resultadoAtual));
    }



    //Configura
    [TestCase(1, 10, 11)]
    [TestCase(0, 8, 8)]
    [TestCase(3, 3, 6)]
    public void testSomarDoisNumerosTC(int num1, int num2, int resultadoEsperado)
    {

        //Executa
        int resultadoAtual = Calculadora.somarDoisNumeros(num1, num2);

        //Valida
        Assert.That(resultadoAtual, Is.EqualTo(resultadoEsperado));

    }

    //Configura
    [TestCase(-2, -5, -7)]
    [TestCase(7, 8, 15)]
    [TestCase(3, 3, 6)]
    public void testSomarDoisNumerosTC2(int num1, int num2, int resultadoEsperado)
    {

        //Executa
        Assert.That(Calculadora.somarDoisNumeros(num1, num2), Is.EqualTo(resultadoEsperado));

    }
    //Teste Data Driven
    //Configura
    [Test, TestCaseSource("lerDadosDeTeste", new object[] { "+" })]
    public void testSomarDoisNumerosDD(int num1, int num2, int resultadoEsperado)
    {

        //Executa
        int resultadoAtual = Calculadora.somarDoisNumeros(num1, num2);

        //Valida
        Assert.That(resultadoAtual, Is.EqualTo(resultadoEsperado));

    }

    //Teste Data Driven
    //Configura
    [Test, TestCaseSource("lerDadosDeTeste", new object[] { "-" })]
    public void testSubtrairDoisNumeros(int num1, int num2, int resultadoEsperado)
    {

        //Executa
        int resultadoAtual = Calculadora.subtrairDoisNumeros(num1, num2);

        //Valida
        Assert.That(resultadoAtual, Is.EqualTo(resultadoEsperado));

    }


    //Teste Data Driven
    //Configura
    [Test, TestCaseSource("lerDadosDeTeste", new object[] { "*" })]
    public void testMultiplicarDoisNumeros(int num1, int num2, int resultadoEsperado)
    {

        //Executa
        int resultadoAtual = Calculadora.multiplicarDoisNumeros(num1, num2);

        //Valida
        Assert.That(resultadoAtual, Is.EqualTo(resultadoEsperado));

    }

    //Teste Data Driven
    //Configura
    [Test, TestCaseSource("lerDadosDeTeste", new object[] { "/" })]
    public void testDividirDoisNumeros(int num1, int num2, int resultadoEsperado)
    {

        //Executa
        int resultadoAtual = Calculadora.dividirDoisNumeros(num1, num2);

        //Valida
        Assert.That(resultadoAtual, Is.EqualTo(resultadoEsperado));

    }

}