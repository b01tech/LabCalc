using System.Text;

namespace ValidateLabCalcs.Entities;

public class Calculadora
{
    public static double CalcMedia(double l1, double l2, double l3)
    {
        return (l1 + l2 + l3) / 3;
    }

    /*
    UA = s /RAIZ(n)
    s = ((MÉDIA - L1) + (MÉDIA - L2) + (MÉDIA - L3))² / (n-1)

    s = desvio padrão
    n = número de leituras
    */
    public static double CalcUa(double l1, double l2, double l3)
    {
        double media = CalcMedia(l1, l2, l3);
        double s = Math.Sqrt((Math.Pow(l1 - media, 2) + Math.Pow(l2 - media, 2) + Math.Pow(l3 - media, 2)) / 2);
        return s / Math.Sqrt(3);
    }

    //UP = SOMA(u)/k
    public static double CalcUp(double somaIncertezaPD, double k)
    {
        return somaIncertezaPD / k;
    }

    //UR = (RES * 0.5) / RAIZ(3)
    public static double CalcUr(float res)
    {
        return res * 0.5 / Math.Sqrt(3);
    }

    //UD = SOMA(u) / RAIZ(3)
    public static double CalcUd(double somaIncertezaPD)
    {
        return somaIncertezaPD / Math.Sqrt(3);
    }

    //UE = ((SOMA(vc)/1000000)* ppm)/RAIZ(3)
    public static double CalcUe(double vcPeso, int ppm)
    {
        return vcPeso / 1000000.0 * ppm / Math.Sqrt(3);
    }

    //UC = RAIZ(UA² + UP² + UR² + UD² + UE²)
    public static double CalcUc(double ua, double up, double ur, double ud, double ue)
    {
        double somaQuadrados = Math.Pow(ua, 2) + Math.Pow(up, 2) + Math.Pow(ur, 2) + Math.Pow(ud, 2) + Math.Pow(ue, 2);

        return Math.Sqrt(somaQuadrados);


    }

    public static double CalcUx(double _uc, double fatorK)
    {
        return _uc * fatorK;
    }

    public static double CalcFatorK(double uc, double ua)
    {
        int v = 2; // número de medições menos 1
        if (ua == 0.0d)
        {
            return 2.0d;
        }
        else
        {
            var Veff = Math.Pow(uc, 4) / (Math.Pow(ua, 4) / v);
            Veff = Math.Floor(Veff);

            if (Veff > 1000000)
                return 2.00d;
            if (Veff > 50)
                return 2.05d;
            if (Veff > 20)
                return 2.13d;
            if (Veff > 10)
                return 2.28d;
            if (Veff > 8)
                return 2.37d;
            if (Veff > 7)
                return 2.43d;
            if (Veff > 6)
                return 2.52d;
            if (Veff > 5)
                return 2.65d;
            if (Veff > 4)
                return 2.87d;
            if (Veff > 3)
                return 3.31d;
            if (Veff > 2)
                return 4.53d;
            if (Veff > 1)
                return 13.97d;
            else
                return 2.00d;
        }
    }

    public static void Execute(Balanca bal, Pesagem p)
    {
        var _k = 2.0d; // fator de abrangência da calibração do Peso
        var media = CalcMedia(p.Leitura1, p.Leitura2, p.Leitura3);
        var ua = CalcUa(p.Leitura1, p.Leitura2, p.Leitura3);
        var up = CalcUp(p.SomaIncertezas, _k);
        var ur = CalcUr(bal.resolucao);
        var ud = CalcUd(p.SomaIncertezas);
        var ue = CalcUe(p.SomaValorReal, p.Material);
        var uc = CalcUc(ua, up, ur, ud, ue);
        var fatorK = CalcFatorK(uc, ua);
        var ux = CalcUx(uc, fatorK);

        var sb = new StringBuilder();
        sb.AppendLine($"Media de leitura:{media}\n");
        sb.AppendLine($"Incerteza calculada por meios estatísticos UA:{ua}\n");
        sb.AppendLine($"Incerteza do peso padrão UP:{up}\n");
        sb.AppendLine($"Incerteza da resolução da balança UR:{ur}\n");
        sb.AppendLine($"Incerteza da deriva do padrão UD:{ud}\n");
        sb.AppendLine($"Incerteza do empuxo do ar UE:{ue}\n");
        sb.AppendLine($"Incerteza combinada UC:{uc}\n");
        sb.AppendLine($"Fator de abrangência K: {fatorK}");
        sb.AppendLine($"Incerteza expandida:{ux}\n");

        Console.WriteLine(sb.ToString());

    }
}
