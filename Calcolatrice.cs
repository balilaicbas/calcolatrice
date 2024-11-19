using System.Transactions;

namespace CalcolatriceDLL
{
    public class Calcolatrice
    {
        public List<double> numeri = new List<double>();
        public string operatore = "+";
        public const double PI = 3.14159;
        public const double E = 2.71828;
        public double esponente;
        public double numero;
        public double baseLog;
        public double indice;
        public string inputUtente;
        public string outputUtente;


        public Calcolatrice(List<double> numeri, string operatore)
        {
            this.numeri = numeri;
            this.operatore = operatore;
        }

        public double Somma(List<double> numeri)
        {
            double res = 0;
            for (int i = 0; i < numeri.Count; i++)
            {

                res += numeri[i];

            }
            Console.WriteLine(res);
            return res;

        }

        public double Sottrazione(List<double> numeri)
        {
            double res = numeri[0];
            for (int i = 1; i < numeri.Count; i++)
            {
                res = res - numeri[i];

            }
            Console.WriteLine(res);
            return res;

        }

        public double Moltiplicazione(List<double> numeri)
        {
            double res = 1;
            for (int i = 0; i < numeri.Count; i++)
            {
                res = res * numeri[i];
            }
            Console.WriteLine(res);
            return res;
        }

        public double Divisione(List<double> numeri)
        {
            double res = numeri[0];
            for (int i = 1; i < numeri.Count; i++)
            {
                res = res / numeri[i];
                Console.WriteLine(res);
            }
            return res;
        }
        public double Potenza(double numero, double esponente)
        {
            double res = Math.Pow(numero,esponente);
            return res;

        }

        public double Logaritmo(double numero, double baseLog)
        {
            double res = Math.Log(numero,baseLog); 
            return res;
        }

        public double Radice(double numero, double indice)
        {
            double res = Math.Pow(numero, 1/indice);
            return res;
        }

        public double ValoreAssoluto(double numero)
        {
            double res = Math.Abs(numero);
            return res;
        }
        public double Seno(double numero)
        {
            double res = Math.Sin(numero);
            return res;
        }
        public double Coseno(double numero)
        {
            double res = Math.Cos(numero);
            return res;
        }
        public double Tangente(double numero)
        {
            double res = Math.Tan(numero);
            return res;
        }

        public void ANS(string inputUtente, string outputUtente)
        {
            Console.WriteLine("ultimo calcolo: " + inputUtente + "\v risultato: " + outputUtente);
        }



    }
}
