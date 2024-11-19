// See https://aka.ms/new-console-template for more information

// See https://aka.ms/new-console-template for more information
using CalcolatriceDLL;
using Microsoft.VisualBasic;
using System.ComponentModel.Design;



namespace calcolatriceGUI
{
    class Program
    {


        static void Main(string[] args)
        {
            List<string> caratteri= new List<string>();
            List<double> numeri = new List<double>();
            List<int> parentesi = new List<int>();
            List<int> SinCosTanSqrtgenPotenza = new List<int>();
            List<int> valoreAssoluto = new List<int>();
            List<int> moltiplicazioniDivivioni = new List<int>();
            List<int> addizioniSottrazioni = new List<int>();
            string inputUtente = "";
            string operatore = "";
            bool inserimentoCorretto = true;
            int numeroParentesiAperte = 0;
            int numeroParentesiChiuse = 0;
            bool again = true;
           
            char carattere = '1';






            while (again)
            {
                Console.WriteLine("inserisci l'espressione che vuoi risolvere\vnb: pi greco si scrive PI, il numero di Nepero si scrive E");
                inputUtente = Console.ReadLine();
                inputUtente.ToLower().Trim();
               



                for (int i = 0; i < inputUtente.Length; i++)
                {



                    carattere = inputUtente[i];

                    switch (carattere)
                    {
                        // esponenziale
                        case '^':
                            if (i + 1 >= inputUtente.Length || Convert.ToChar(inputUtente[i+1]) != '(')
                            {
                                inserimentoCorretto = false;
                                Console.WriteLine("Errore: '^' deve essere seguito da '('");
                            }
                            break;
                        // log--> nb: o faccio un controllo che abbia 2 cifre all'interno o serve un'overloading del metodo
                        case 'l':
                            if (i + 1 >= inputUtente.Length || i + 2 >= inputUtente.Length || i + 3 >= inputUtente.Length || Convert.ToChar(inputUtente[i + 1]) != 'o' || Convert.ToChar(inputUtente[i + 2]) != 'g' || Convert.ToChar(inputUtente[i + 3]) != '(')
                            {
                                inserimentoCorretto = false;
                                Console.WriteLine("Errore: manca 'log(' dopo 'l'");
                            }
                            else
                            {
                                i = i + 2;
                            }
                            break;
                        //sqrt--> nb: idem come log
                        case 's':
                            if (i + 1 < inputUtente.Length && i + 2 < inputUtente.Length && i + 3 < inputUtente.Length && i + 4 < inputUtente.Length && Convert.ToChar(inputUtente[i + 1]) == 'q' && Convert.ToChar(inputUtente[i + 2]) == 'r' && Convert.ToChar(inputUtente[i + 3]) == 't' && Convert.ToChar(inputUtente[i + 4]) == '(')

                            {
                                i = i + 3;
                            }
                        //sin
                            else if (i + 1 < inputUtente.Length && i + 2 < inputUtente.Length && i + 3 < inputUtente.Length && Convert.ToChar(inputUtente[i + 1]) == 'i' && Convert.ToChar(inputUtente[i + 2]) == 'n' && Convert.ToChar(inputUtente[i + 3]) == '(')

                            {
                                i = i + 2;   
                            }
                            else
                            {
                                inserimentoCorretto = false;
                                Console.WriteLine("Errore: manca 'sqrt(' o 'sin(' dopo 's'");
                            }
                            break;
                        //cos
                        case 'c':
                            if (i + 1 >= inputUtente.Length || i + 2 >= inputUtente.Length || i + 3 >= inputUtente.Length || Convert.ToChar(inputUtente[i + 1]) != 'o' || Convert.ToChar(inputUtente[i + 2]) != 's' || Convert.ToChar(inputUtente[i + 3]) != '(')

                            {
                                inserimentoCorretto = false;
                                Console.WriteLine("Errore: manca 'cos(' dopo 'c'");
                            }
                            else
                            {
                                i = i + 2;
                            }


                            break;
                        //tan
                        case 't':
                            if (i + 1 >= inputUtente.Length || i + 2 >= inputUtente.Length || i + 3 >= inputUtente.Length || Convert.ToChar(inputUtente[i + 1]) != 'a' || Convert.ToChar(inputUtente[i + 2]) != 'n' || Convert.ToChar(inputUtente[i + 3]) != '(')

                            {
                                inserimentoCorretto = false;
                                Console.WriteLine("Errore: manca 'tan(' dopo 't'");
                            }
                            else
                            {
                                i = i + 2;
                            }
                            break;
                        //parentesi aperte
                        case '(':
                            numeroParentesiAperte++;
                            break;
                        //parentesi chiuse
                        case ')':
                            numeroParentesiChiuse++;
                            break;
                        // conto parentesi
                        case '=':
                            if (numeroParentesiAperte != numeroParentesiChiuse || i != inputUtente.Length - 1)
                            {
                                inserimentoCorretto = false;

                            }
                            break;
                        case '+':
                            if (i + 1 >= inputUtente.Length || Convert.ToChar(inputUtente[i + 1]) == '+' || Convert.ToChar(inputUtente[i + 1]) == '-' || Convert.ToChar(inputUtente[i + 1]) == '*' || Convert.ToChar(inputUtente[i + 1]) == '/' || Convert.ToChar(inputUtente[i + 1]) == '=')
                            {
                                inserimentoCorretto = false;
                            }
                            break;
                        case '-':
                            if (i + 1 >= inputUtente.Length || Convert.ToChar(inputUtente[i + 1]) == '+' || Convert.ToChar(inputUtente[i + 1]) == '-' || Convert.ToChar(inputUtente[i + 1]) == '*' || Convert.ToChar(inputUtente[i + 1]) == '/' || Convert.ToChar(inputUtente[i + 1]) == '=')
                            {
                                inserimentoCorretto = false;
                            }
                            break;
                        case '*':
                            if (i + 1 >= inputUtente.Length || Convert.ToChar(inputUtente[i + 1]) == '+' || Convert.ToChar(inputUtente[i + 1]) == '-' || Convert.ToChar(inputUtente[i + 1]) == '*' || Convert.ToChar(inputUtente[i + 1]) == '/' || Convert.ToChar(inputUtente[i + 1]) == '=')
                            {
                                inserimentoCorretto = false;
                            }
                            break;
                        case '/':
                            if (i + 1 >= inputUtente.Length || Convert.ToChar(inputUtente[i + 1]) == '+' || Convert.ToChar(inputUtente[i + 1]) == '-' || Convert.ToChar(inputUtente[i + 1]) == '*' || Convert.ToChar(inputUtente[i + 1]) == '/' || Convert.ToChar(inputUtente[i + 1]) == '=')
                            {
                                inserimentoCorretto = false;
                            }
                            break;
                        case 'p':
                            if (i + 1 >= inputUtente.Length || Convert.ToChar(inputUtente[i + 1]) != 'i')
                            {
                                inserimentoCorretto = false;
                                Console.WriteLine("errore: manca pi dopo p");
                            }
                            else
                            {
                                i = i + 1;
                            }
                            break;
                    }

                }

                if (inserimentoCorretto == false)
                {
                    Console.WriteLine("riguarda bene perché la formattazione che hai usato non è corretta ");
                    inserimentoCorretto=true;
                }
                else
                {
                    Console.WriteLine("sto processando il risultato");
                    again = false;
                }
            }
            int inizioNumero = 0;
            int fineNumero = 0;

            for (int i = 0; i < inputUtente.Length; i++)
            {
                if ((inputUtente[i] == '1' || inputUtente[i] == '2' || inputUtente[i] == '3' || inputUtente[i] == '4' || inputUtente[i] == '5' || inputUtente[i] == '6' || inputUtente[i] == '7' || inputUtente[i] == '8' || inputUtente[i] == '9' || inputUtente[i] == '0')&& inizioNumero == 0)
                {
                    inizioNumero = i;
                    if (inputUtente[i + 1] == 's' || inputUtente[i + 1] == 'l' || inputUtente[i + 1] == 'e' || inputUtente[i + 1] == 'c' || inputUtente[i + 1] == 't' || inputUtente[i + 1] == 'p' || inputUtente[i + 1] == '(')
                    {
                        caratteri.Add("*");
                    }
                }
                else if (inputUtente[i] == '+' || inputUtente[i] == '-' || inputUtente[i] == '*' || inputUtente[i] == '/')
                {
                    if (inizioNumero != 0)
                    {
                        fineNumero = i;
                        caratteri.Add(inputUtente.Substring(inizioNumero, (fineNumero - inizioNumero)));
                        fineNumero = 0;
                        inizioNumero = 0;
                    }
                    caratteri.Add(Convert.ToString(inputUtente[i]));
                }
                else if (inputUtente[i] == 'p')
                {
                    if (inizioNumero != 0)
                    {
                        fineNumero = i;
                        caratteri.Add(inputUtente.Substring(inizioNumero, (fineNumero - inizioNumero)));
                        fineNumero = 0;
                        inizioNumero = 0;
                        caratteri.Add("*");

                    }
                    caratteri.Add("3.14");
                    i = i + 1;
                    if (inputUtente[i + 1] == '1' || inputUtente[i + 1] == '(' || inputUtente[i + 1] == '2' || inputUtente[i + 1] == '3' || inputUtente[i + 1] == '4' || inputUtente[i + 1] == '5' || inputUtente[i + 1] == '6' || inputUtente[i + 1] == '7' || inputUtente[i + 1] == '8' || inputUtente[i + 1] == '9' || inputUtente[i + 1] == 's' || inputUtente[i + 1] == 'l' || inputUtente[i + 1] == 'e' || inputUtente[i + 1] == 'c' || inputUtente[i + 1] == 't')
                    {
                        caratteri.Add("*");
                    }
                }
                else if (inputUtente[i] == 'e')
                {
                    if (inizioNumero != 0)
                    {
                        fineNumero = i;
                        caratteri.Add(inputUtente.Substring(inizioNumero, (fineNumero - inizioNumero)));
                        fineNumero = 0;
                        inizioNumero = 0;
                        caratteri.Add("*");

                    }
                    caratteri.Add("2,71");
                    if (inputUtente[i + 1] == '(' || inputUtente[i + 1] == '1' || inputUtente[i + 1] == '2' || inputUtente[i + 1] == '3' || inputUtente[i + 1] == '4' || inputUtente[i + 1] == '5' || inputUtente[i + 1] == '6' || inputUtente[i + 1] == '7' || inputUtente[i + 1] == '8' || inputUtente[i + 1] == '9' || inputUtente[i + 1] == 's' || inputUtente[i + 1] == 'l' || inputUtente[i + 1] == 'p' || inputUtente[i + 1] == 'c' || inputUtente[i + 1] == 't')
                    {
                        caratteri.Add("*");
                    }

                }
                else if (inputUtente[i] == '^')
                {
                    if (inizioNumero != 0)
                    {
                        fineNumero = i;
                        caratteri.Add(inputUtente.Substring(inizioNumero, (fineNumero - inizioNumero)));
                        fineNumero = 0;
                        inizioNumero = 0;

                    }
                    caratteri.Add("^");
                    caratteri.Add("(");
                    i = i + 1;

                }
                else if (inputUtente[i] == '(')
                {
                    if (inizioNumero != 0)
                    {
                        fineNumero = i;
                        caratteri.Add(inputUtente.Substring(inizioNumero, (fineNumero - inizioNumero)));
                        fineNumero = 0;
                        inizioNumero = 0;

                    }
                    caratteri.Add("(");


                }
                else if (inputUtente[i] == ')')
                {
                    if (inizioNumero != 0)
                    {
                        fineNumero = i;
                        caratteri.Add(inputUtente.Substring(inizioNumero, (fineNumero - inizioNumero)));
                        fineNumero = 0;
                        inizioNumero = 0;

                    }
                    caratteri.Add(")");
                    if (inputUtente[i + 1] == '1' || inputUtente[i + 1] == '(' || inputUtente[i + 1] == '2' || inputUtente[i + 1] == '3' || inputUtente[i + 1] == '4' || inputUtente[i + 1] == '5' || inputUtente[i + 1] == '6' || inputUtente[i + 1] == '7' || inputUtente[i + 1] == '8' || inputUtente[i + 1] == '9' || inputUtente[i + 1] == 's' || inputUtente[i + 1] == 'l' || inputUtente[i + 1] == 'e' || inputUtente[i + 1] == 'c' || inputUtente[i + 1] == 't' || inputUtente[i + 1] == 'p')
                    {
                        caratteri.Add("*");
                    }


                }
                else if (inputUtente[i] == 'c')
                {
                    if (inizioNumero != 0)
                    {
                        fineNumero = i;
                        caratteri.Add(inputUtente.Substring(inizioNumero, (fineNumero - inizioNumero)));
                        fineNumero = 0;
                        inizioNumero = 0;

                    }
                    caratteri.Add("cos");
                    i = i + 2;
                    caratteri.Add("(");
                    i = i + 1;
                }
                else if (inputUtente[i] == 't')
                {
                    if (inizioNumero != 0)
                    {
                        fineNumero = i;
                        caratteri.Add(inputUtente.Substring(inizioNumero, (fineNumero - inizioNumero)));
                        fineNumero = 0;
                        inizioNumero = 0;

                    }
                    caratteri.Add("tan");
                    i = i + 2;
                    caratteri.Add("(");
                    i = i + 1;
                }
                else if (inputUtente[i] == 's')

                {
                    if (inizioNumero != 0)
                    {
                        fineNumero = i;
                        caratteri.Add(inputUtente.Substring(inizioNumero, (fineNumero - inizioNumero)));
                        fineNumero = 0;
                        inizioNumero = 0;

                    }
                    if (Convert.ToChar(inputUtente[i + 1]) == 'i')
                    {
                        caratteri.Add("sin");
                        i = i + 2;
                        caratteri.Add("(");
                        i = i + 1;
                    }
                    else if (Convert.ToChar(inputUtente[i + 1]) == 'q')
                    {
                        caratteri.Add("sqrt");
                        i = i + 3;
                        caratteri.Add("(");
                        i = i + 1;
                    }
                }

                else if (inputUtente[i] == 'l')
                {
                    if (inizioNumero != 0)
                    {
                        fineNumero = i;
                        caratteri.Add(inputUtente.Substring(inizioNumero, (fineNumero - inizioNumero)));
                        fineNumero = 0;
                        inizioNumero = 0;

                    }

                    caratteri.Add("log");
                    i = i + 2;
                    caratteri.Add("(");
                    i = i + 1;
                }
                else if (inputUtente[i] == '=')
                {
                    if (inizioNumero != 0)
                    {
                        fineNumero = i;
                        caratteri.Add(inputUtente.Substring(inizioNumero, (fineNumero - inizioNumero)));
                        fineNumero = 0;
                        inizioNumero = 0;

                    }

                    
                }


            }
            foreach (string valore in caratteri)
            {
                Console.WriteLine(valore);
            }
            

            /*        Calcolatrice calcolatrice = new Calcolatrice(numeri, operatore);

            if (calcolatrice.operatore == "+")
            {
                calcolatrice.Somma(numeri);
            }
            else if (calcolatrice.operatore == "-")
            {
                calcolatrice.Sottrazione(numeri);
            }
            if (calcolatrice.operatore == "/")
            {
                calcolatrice.Divisione(numeri);
            }
            if (calcolatrice.operatore == "*")
            {
                calcolatrice.Moltiplicazione(numeri);
            }
            */

        }
    }
}
