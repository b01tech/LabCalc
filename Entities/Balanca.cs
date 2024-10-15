namespace ValidateLabCalcs.Entities;

public class Balanca
{

    public float resolucao { get; set; }

    public void GetData()
    {
        float res = GetFloatFromUser("Qual a resolução da balança: ");
        resolucao = res;
    }
    private float GetFloatFromUser(string message)
    {
        float value;
        bool isValid;
        do
        {
            Console.Write(message);
            isValid = float.TryParse(Console.ReadLine(), out value);
            if (!isValid)
            {
                Console.WriteLine("Valor inválido. Por favor, insira um número válido.");
            }
        } while (!isValid);

        return value;
    }
}
