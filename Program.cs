using ValidateLabCalcs.Entities;

do
{
    Console.WriteLine("1 - Validar condições ambientais  2 - Validar cálculo de incerteza");
    var op = Console.ReadLine();

    if (op == "1")
    {
        CondicoesAmbientais ca = new();

        ca.GetData();
        ca.ValidateMassaEspecifica();
        Console.ReadKey();

        Console.Clear();

    }
    else if (op == "2")
    {
        Balanca bal = new Balanca();
        bal.GetData();

        Pesagem pesagem = new Pesagem();
        pesagem.GetData();

        Calculadora.Execute(bal, pesagem);

        Console.ReadKey();

        Console.Clear();

    }
    else
    {
        Console.WriteLine("Opção inválida.");

        Console.ReadKey();

        Console.Clear();
    }
}
while (true);


