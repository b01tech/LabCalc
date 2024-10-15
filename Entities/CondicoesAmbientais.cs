namespace ValidateLabCalcs.Entities
{
    public class CondicoesAmbientais
    {
        private float Temperatura { get; set; }
        private float Umidade { get; set; }
        private float Pressao { get; set; }
        private float MassaEspecifica { get; set; }


        public void GetData()
        {
            float tempInicial = GetFloatFromUser("Informe a temperatura inicial(ºC): ");
            float tempFinal = GetFloatFromUser("Informe a temperatura final(ºC): ");
            float rhInicial = GetFloatFromUser("Informe a umidade inicial(RH %): ");
            float rhFinal = GetFloatFromUser("Informe a umidade final(RH %): ");
            float pressaoInicial = GetFloatFromUser("Informe a pressão inicial(hPa): ");
            float pressaoFinal = GetFloatFromUser("Informe a pressão final(hPa): ");

            SetData(tempInicial, tempFinal, rhInicial, rhFinal, pressaoInicial, pressaoFinal);
        }

        private void SetData(float tempInicial, float tempFinal,
            float umidadeInicial, float umidadeFinal,
            float pressaoInicial, float pressaoFinal)
        {
            Temperatura = Math.Abs(tempInicial + tempFinal) / 2;
            Umidade = Math.Abs(umidadeInicial + umidadeFinal) / 2;
            Pressao = Math.Abs(pressaoInicial + pressaoFinal) / 2;
            CalcMassaEspecifica(Temperatura, Umidade, Pressao);
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
        public void CalcMassaEspecifica(float temp, float umidade, float pressao)
        {
            
            MassaEspecifica = ((0.348444f * pressao) - (umidade * ((0.00252f * temp) - 0.020582f))) / (273.15f + temp);

        }

        public void ValidateMassaEspecifica()
        {
            Console.WriteLine($"A massa específica é de: {MassaEspecifica}kg/m³");
            Console.WriteLine("A massa deve ficar entre 1,08 e 1,32kg/m³");

        }
    }

}
