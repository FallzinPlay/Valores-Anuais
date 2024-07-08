using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ValoresAnuais
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            short year = 0;
            byte holidays = 0;
            bool isOk = false; // Para verificar se o usuário digitou a informação correta
            while (!isOk)
            {
                try
                {
                    while (year < 1970)
                    {
                        Console.Write("Digite o ano atual: ");
                        year = short.Parse(Console.ReadLine()); // Recebe o ano
                    }
                    Console.Write("Digite a quantidade de feriados do ano atual (fora dos finais de semana): ");
                    holidays = byte.Parse(Console.ReadLine());
                    isOk = true;
                }
                catch
                {
                    Console.WriteLine("Valor errado!");
                }
            }
               
                short totalWeekends = 52 * 2; // Total de semanas * 2 (sábado e domingo)
                short totalDays = 365;
                if (DateTime.IsLeapYear(year)) totalDays = 366;

                double[] values = new double[totalDays - totalWeekends - holidays]; // Valores armazenados
                #region Preenche a array para meios de teste
                for (short i = 0; i < values.Length; i++) values[i] = r.Next(10000, 30000) * r.NextDouble();
                #endregion

                Console.WriteLine($"Menor valor do ano de {year}: {GetSmallestValue(values).ToString("F2")}"); // Mostra o menor valor do ano
                Console.WriteLine($"Maior valor do ano de {year}: {GetBiggestValue(values).ToString("F2")}"); // Mostra o maior valor do ano
                Console.WriteLine($"Total de dias que superaram a média anual: {GetDayValuesBiggerMedia(values)}"); // Mostra os dias que superaram a média anual

        }

        public static double GetSmallestValue(double[] values)
        {
            double value = values[0];
            foreach (double v in values)
            {
                if (value > v) value = v;
            }
            return value;
        }
        
        public static double GetBiggestValue(double[] values)
        {
            double value = values[0];
            foreach (double v in values)
            {
                if (value < v) value = v;
            }
            return value;
        }

        public static short GetDayValuesBiggerMedia(double[] values)
        {
            short days = 0;
            double media = 0.0d;
            for (short i = 0; i < values.Length; i++) media += values[i];

            media /= values.Length;
            foreach (double v in values)
            {
                if (v > media) days++;
            }
            return days;
        }
    }
}
