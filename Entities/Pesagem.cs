namespace ValidateLabCalcs.Entities;

public class Pesagem
{
    public double SomaValorReal { get; set; }
    public double SomaIncertezas { get; set; }
    public int Material { get; set; }

    public double Leitura1 { get; set; }
    public double Leitura2 { get; set; }
    public double Leitura3 { get; set; }

    public void GetData()
    {
        double l1 = GetDoubleFromUser("Leitura 1: ");
        double l2 = GetDoubleFromUser("Leitura 2: ");
        double l3 = GetDoubleFromUser("Leitura 3: ");
        double valor = GetDoubleFromUser("Informe a soma do valor convencional dos pesos utilizados: ");
        double incerteza = GetDoubleFromUser("Informe a soma das incertezas dos pesos: ");
        int material = GetMaterial("Qual o material dos pesos?\r\n(1 - INOX  2 - FERRO   3 - LATÃO): ");
        SetData(l1, l2, l3, valor, incerteza, material);
    }
    public void SetData(double l1, double l2, double l3, double valor, double incerteza, int material)
    {
        Leitura1 = l1;
        Leitura2 = l2;
        Leitura3 = l3;
        SomaValorReal = valor;
        SomaIncertezas = incerteza;
        Material = material;
    }

    private double GetDoubleFromUser(string message)
    {
        double value;
        bool isValid;
        do
        {
            Console.Write(message);
            isValid = double.TryParse(Console.ReadLine(), out value);
            if (!isValid)
            {
                Console.WriteLine("Valor inválido. Por favor, insira um número válido.");
            }
        } while (!isValid);

        return value;

    }

    private int GetMaterial(string message)
    {
        int value;
        bool isValid;
        do
        {
            Console.Write(message);
            isValid = int.TryParse(Console.ReadLine(), out value);
            if (value > 3 || value < 1)
                isValid = false;
            if (!isValid)
            {
                Console.WriteLine("Valor inválido. Por favor, insira um número válido.");
            }
        } while (!isValid);

        return value;
    }


}
