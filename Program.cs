using System.Security.Cryptography.X509Certificates;

namespace CheckPoint1;

internal static class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=== CHECKPOINT 1 - FUNDAMENTOS C# - Turma  3ESPY ===\n");

        Console.WriteLine("1. Testando DemonstrarTiposDados...");
        Console.WriteLine(DemonstrarTiposDados());

        Console.WriteLine("\n2. Testando CalculadoraBasica (SWITCH)...");
        Console.WriteLine(CalculadoraBasica(10, 5, '+'));
        Console.WriteLine(CalculadoraBasica(10, 5, '-'));
        Console.WriteLine(CalculadoraBasica(10, 5, '*'));
        Console.WriteLine(CalculadoraBasica(10, 5, '/'));
        Console.WriteLine(CalculadoraBasica(10, 5, '?'));

        Console.WriteLine("\n3. Testando ValidarIdade (IF/ELSE)...");
        Console.WriteLine(ValidarIdade(6));
        Console.WriteLine(ValidarIdade(17));
        Console.WriteLine(ValidarIdade(35));
        Console.WriteLine(ValidarIdade(86));

        Console.WriteLine("\n4. Testando ConverterString...");
        Console.WriteLine(ConverterString("123", "int"));
        Console.WriteLine(ConverterString("3.14", "double"));
        Console.WriteLine(ConverterString("true", "bool"));
        Console.WriteLine(ConverterString("abc", "int"));

        Console.WriteLine("\n5. Testando ClassificarNota (SWITCH)...");
        Console.WriteLine(ClassificarNota(9.1));
        Console.WriteLine(ClassificarNota(5.6));
        Console.WriteLine(ClassificarNota(3.0));
        Console.WriteLine(ClassificarNota(7.5));
        Console.WriteLine(ClassificarNota(14.7));

        Console.WriteLine("\n6. Testando GerarTabuada (FOR)...");
        Console.WriteLine(GerarTabuada(7));

        Console.WriteLine("\n7. Testando JogoAdivinhacao (WHILE)...");
        Console.WriteLine(JogoAdivinhacao(70, new int[]{50, 75, 70}));

        Console.WriteLine("\n8. Testando ValidarSenha (DO-WHILE)...");
        Console.WriteLine(ValidarSenha("SenhaManeira@12"));
        Console.WriteLine(ValidarSenha("teste"));

        Console.WriteLine("\n9. Testando AnalisarNotas (FOREACH)...");
        Console.WriteLine(AnalisarNotas(new double[]{3.4, 8.7, 9,8, 10.0, 5.5}));

        Console.WriteLine("\n10. Testando ProcessarVendas (FOREACH múltiplo)...");
        double[] vendas = { 700, 1000, 950, 320, 100 };
        string[] cats = { "A", "B", "C", "A", "B" };
        double[] percentuais = { 0.20, 0.05, 0.12 };
        string[] nomesCats = { "A", "B", "C" };
        Console.WriteLine(ProcessarVendas(vendas, cats, percentuais, nomesCats));

        Console.WriteLine("\n=== RESUMO: TODAS AS ESTRUTURAS FORAM TESTADAS ===");
        Console.WriteLine("✅ IF/ELSE: Testado na validação de idade");
        Console.WriteLine("✅ SWITCH: Testado na calculadora e classificação de notas");
        Console.WriteLine("✅ FOR: Testado na tabuada");
        Console.WriteLine("✅ WHILE: Testado no jogo de adivinhação");
        Console.WriteLine("✅ DO-WHILE: Testado na validação de senha");
        Console.WriteLine("✅ FOREACH: Testado na análise de notas e processamento de vendas");

        Console.WriteLine("\nPressione qualquer tecla para sair...");
        Console.ReadKey();
    }

    private static string DemonstrarTiposDados()
    {

        int inteiro = 42;
        double decimalnum = 3.14;
        bool booleano = true;
        char Caractere = 'A';
        var texto = "Olá";

        return $"Inteiro: {inteiro}, Decimal: {decimalnum}, Boolean: {booleano}, Caractere: {Caractere}, Texto: {texto}";

        //throw new NotImplementedException("Implementar DemonstrarTiposDados");
    }

    private static double CalculadoraBasica(double num1, double num2, char operador)
    {
        switch (operador)
        {
            case '+': return num1 + num2;
            case '-': return num1 - num2;
            case '*': return num1 * num2;
            case '/': return num1 / num2;

            default: return -1;
        }

        //throw new NotImplementedException("Implementar CalculadoraBasica com SWITCH");
    }

    private static string ValidarIdade(int idade)
    {
        if (idade < 0 || idade > 120) return "Idade inválida";
        else if (idade < 12) return "Criança";
        else if (idade < 18) return "Adolescente";
        else if (idade <= 65) return "Adulto";
        else return "Idoso";

        //throw new NotImplementedException("Implementar ValidarIdade com IF/ELSE");
    }

    private static string ConverterString(string valor, string tipoDesejado)
    {
        if (tipoDesejado == "int")
        {
            if (int.TryParse(valor, out int numero))
                return $"int: {numero}";
            else
                return "Conversão impossível para int";
        }
        else if (tipoDesejado == "double")
        {
            if (double.TryParse(valor, out double numeroDecimal))
                return $"double: {numeroDecimal}";
            else
                return "Conversão impossível para double";
        }
        else if (tipoDesejado == "bool")
        {
            if (bool.TryParse(valor, out bool booleano))
                return $"boolean: {booleano}";
            else
                return "Conversão impossível para boolean";
        }
        else
        {
            return "Tipo não suportado";
        }

        //throw new NotImplementedException("Implementar ConverterString");
    }

    private static string ClassificarNota(double nota)
    {
        return nota switch
        {
            >= 9.0 and <= 10.0 => "Excelente",
            >= 7.0 and < 9.0 => "Bom",
            >= 5.0 and < 7.0 => "Regular",
            >= 0.0 and < 4.9 => "Insuficiente",
            _ => "Nota Inválida"
        };

        //throw new NotImplementedException("Implementar ClassificarNota");
    }
    private static string GerarTabuada(int numero)
    {
        if (numero < -0) return "Numero Inválido";

        string resultado = "";

        for (int i = 1; i <= 10; i++)
        {
            resultado += $"{numero} x {i} = {numero * i}\n";
        }

        return resultado.TrimEnd();

        //throw new NotImplementedException("Implementar GerarTabuada com FOR");
    }

    private static string JogoAdivinhacao(int numeroSecreto, int[] tentativas)
    {
        if (tentativas == null || tentativas.Length == 0)
            return "Nenhuma tentativa fornecida";

        var sb = new System.Text.StringBuilder();
        int i = 0;
        bool acertou = false;

        while (i < tentativas.Length && !acertou)
        {
            int palpite = tentativas[i];
            int numTentativa = i + 1;

            if (palpite == numeroSecreto)
            {
                sb.AppendLine($"Tentativa {numTentativa}: {palpite} - correto!");
                acertou = true;
            }
            else if (palpite < numeroSecreto)
            {
                sb.AppendLine($"Tentativa {numTentativa}: {palpite} - muito baixo");
            }
            else
            {
                sb.AppendLine($"Tentativa {numTentativa}: {palpite} - muito alto");
            }

            i++;

        }

        return sb.ToString().TrimEnd();

        //throw new NotImplementedException("Implementar JogoAdivinhacao com WHILE");
    }

    private static string ValidarSenha(string senha)
    {
        if (senha == null) return "senha inválida";

        bool temNumero = false;
        bool temMaiscula = false;
        bool temEspecial = false;

        int idx = 0;
        if (senha.Length > 0)
        {
            do
            {
                char c = senha[idx];
                if (char.IsDigit(c)) temNumero = true;
                if (char.IsUpper(c)) temMaiscula = true;
                if ("!@#$%&*".IndexOf(c) >= 0) temEspecial = true;
                idx++;
            } while (idx < senha.Length);
        }

        var faltas = new System.Collections.Generic.List<string>();
        if (senha.Length < 8) faltas.Add("mínimo 8 caracteres");
        if (!temNumero) faltas.Add("ao menos 1 número");
        if (!temMaiscula) faltas.Add("ao menos 1 maiúscula");
        if (!temEspecial) faltas.Add("ao menos 1 caractere especial");

        return faltas.Count == 0 ? "Senha válida" : "Faltou: " + string.Join(",", faltas);

        //throw new NotImplementedException("Implementar ValidarSenha com DO-WHILE");
    }

    private static string AnalisarNotas(double[] notas)
    {
        if (notas == null || notas.Length == 0)
            return "Nenhuma nota para analisar";

        double soma = 0, maior = double.MinValue, menor = double.MaxValue;
        int aprovados = 0, faA = 0, faB = 0, faC = 0, faD = 0, faF = 0;

        foreach (var n in notas)
        {
            soma += n;
            if (n > maior) maior = n;
            if (n < menor) menor = n;
            if (n >= 7.0) aprovados++;

            if (n >= 9.0 && n <= 10.0) faA++;
            else if (n >= 8.0 && n < 9.0) faB++;
            else if (n >= 7.0 && n < 8.0) faC++;
            else if (n >= 5.0 && n < 7.0) faD++;
            else faF++;
        }

        double media = soma / notas.Length;

        return $"Média: {media:F2}\nAprovados: {aprovados}\nMaior: {maior:F1}\nMenor: {menor:F1}\nA: {faA}, B: {faB}, C: {faC}, D: {faD}, F: {faF}";
        
        //throw new NotImplementedException("Implementar AnalisarNotas com FOREACH");
    }


    private static string ProcessarVendas(double[] vendas, string[] categorias, double[] comissoes, string[] nomesCategorias)
    {
        if (vendas == null || categorias == null || comissoes == null || nomesCategorias == null)
            return "Dados insuficientes";
        if (vendas.Length != categorias.Length)
            return "Tamanho de vendas e categorias não coincide";

        var totalPorCategoria = new System.Collections.Generic.Dictionary<string, double>();
        var comissaoPorCategoria = new System.Collections.Generic.Dictionary<string, double>();

        int idxVenda = 0;
        foreach (var valor in vendas)
        {
            string cat = categorias[idxVenda];


            double perc = 0;
            int j = 0;
            foreach (var nomeCat in nomesCategorias)
            {
                if (string.Equals(nomeCat, cat, StringComparison.OrdinalIgnoreCase))
                {
                    perc = (j >= 0 && j < comissoes.Length) ? comissoes[j] : 0;
                    break;
                }
                j++;
            }

            if (!totalPorCategoria.ContainsKey(cat))
            {
                totalPorCategoria[cat] = 0;
                comissaoPorCategoria[cat] = 0;
            }

            totalPorCategoria[cat] += valor;
            comissaoPorCategoria[cat] += valor * perc;

            idxVenda++;
        }

        var sb = new System.Text.StringBuilder();
        foreach (var nome in nomesCategorias)
        {
            if (totalPorCategoria.TryGetValue(nome, out var tot))
            {
                sb.AppendLine($"Categoria {nome}: Vendas R$ {tot:0.00}, Comissão R$ {comissaoPorCategoria[nome]:0.00}");
            }
        }
        foreach (var kv in totalPorCategoria)
        {
            if (Array.IndexOf(nomesCategorias, kv.Key) < 0)
                sb.AppendLine($"Categoria {kv.Key}: Vendas R$ {kv.Value:0.00}, Comissão R$ {comissaoPorCategoria[kv.Key]:0.00}");
        }

        return sb.Length == 0 ? "Nenhuma venda processada" : sb.ToString().TrimEnd();
        
        //throw new NotImplementedException("Implementar ProcessarVendas com FOREACH");
    }


    // =====================================================================
    // MÉTODOS AUXILIARES (NÃO ALTERAR - APENAS PARA REFERÊNCIA)
    // =====================================================================

    /// <summary>
    /// Método de exemplo demonstrando diferença entre estático e de instância
    /// ESTÁTICO: Pertence à classe, não precisa criar objeto para usar
    /// </summary>
    private static void ExemploMetodoEstatico()
    {
        Console.WriteLine("Sou um método estático - chamado direto da classe");
    }

    /// <summary>
    /// Método de exemplo de instância (comentado pois não pode ser chamado do Main estático)
    /// DE INSTÂNCIA: Pertence ao objeto, precisa criar instância da classe
    /// </summary>
    /*
    void ExemploMetodoInstancia()
    {
        Console.WriteLine("Sou um método de instância - preciso de um objeto para ser chamado");
    }
    */
}