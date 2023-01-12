using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace My_sharp
{
    internal class Program
    {
        private static string input2;
        private static bool runWithArgs;
        private static string fileName = "";
        private static string fileName2;
        

        static void Main(string[] args)
        {
            Console.Title = "My# Console";
            Console.Clear();
            Console.WriteLine("Vítej v My#");
            for(int i = 0; i < 20; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(100);
            }
            Console.Clear();
            
            

            //Defiování vstupu
            string input;
            
            runWithArgs = false;
            if (args.Length > 0)
            {
                string firstArgument = args[0];

                runWithArgs = true;
                input2 = firstArgument;
            }
            else
            {

            }

            //definováí Dictionary pro proměnné
            Dictionary<string, string> variables = new Dictionary<string, string>();
            while (true)
            {

                //vypsání uživatel@počítač>
                string userName = Environment.UserName;
                string pcName = Environment.MachineName;

                //definuji input
                if (runWithArgs == false)
                {
                    Console.Write(userName + "@" + pcName + "> ");
                    input = Console.ReadLine();
                }
                else
                {
                    input = "open " + '"' + input2 + '"';
                    runWithArgs = false;

                }
                //začíná smička psaní příkazů do konzole
                RunCode(input, variables, false);
            }

        }

        public static void RunCode(string getinput, Dictionary<string, string> variables, bool moreCmds)
        {
            
            string[] inputs = getinput.Split(',');
            string input = getinput;
            for (int i = 0; i < inputs.Length; i++)
            {
                if (moreCmds)
                {
                    input = inputs[i];
                }
                else
                {
                    input = getinput;
                }

                switch (input)
                {
                    //příkaz var - stejné jako v konzoli, jen jsou proměnné předělané do tvaru proměnná
                    case string s2 when s2.StartsWith("var "):
                        string variableName = GetStringBetweenCharacters(input, ' ', '=');
                        string variableValue = GetStringBetweenCharacters(input, '=', ';');
                        //pokud se sčíta v proměnné
                        if (variableValue.Contains('+'))
                        {
                            //a+1
                            if (variables.ContainsKey(GetStringBetweenCharacters(input, '=', '+')) && !variables.ContainsKey(GetStringBetweenCharacters(input, '+', ';')))
                            {
                                Regex re = new Regex(@"\d+");
                                Match m = re.Match(GetStringBetweenCharacters(input, '+', ';'));

                                if (m.Success)
                                {
                                    string VarValue = GetStringBetweenCharacters(input, '=', '+');
                                    string varA = variables[VarValue];

                                    VarValue = GetStringBetweenCharacters(input, '+', ';');
                                    string varB = VarValue;

                                    double varC = float.Parse(varA) + float.Parse(varB);
                                    string varC2 = varC.ToString();
                                    variableValue = varC2;

                                }
                            }
                            //1+a
                            else if (!variables.ContainsKey(GetStringBetweenCharacters(input, '=', '+')) && variables.ContainsKey(GetStringBetweenCharacters(input, '+', ';')))
                            {
                                Regex re = new Regex(@"\d+");
                                Match m = re.Match(GetStringBetweenCharacters(input, '=', '+'));

                                if (m.Success)
                                {
                                    string VarValue = GetStringBetweenCharacters(input, '=', '+');
                                    string varA = VarValue;

                                    VarValue = GetStringBetweenCharacters(input, '+', ';');
                                    string varB = variables[VarValue];

                                    double varC = float.Parse(varA) + float.Parse(varB);
                                    string varC2 = varC.ToString();
                                    variableValue = varC2;

                                }

                            }
                            //a+a

                            else if (variables.ContainsKey(GetStringBetweenCharacters(input, '=', '+')) && variables.ContainsKey(GetStringBetweenCharacters(input, '+', ';')))
                            {
                                
                                string VarValue = GetStringBetweenCharacters(input, '=', '+');
                                string varA = variables[VarValue];

                                VarValue = GetStringBetweenCharacters(input, '+', ';');
                                string varB = variables[VarValue];

                                double varC = float.Parse(varA) + float.Parse(varB);
                                string varC2 = varC.ToString();
                                variableValue = varC2;

                            }
                            //1+1
                            else if (!variables.ContainsKey(GetStringBetweenCharacters(input, '=', '+')) && !variables.ContainsKey(GetStringBetweenCharacters(input, '+', ';')))
                            {
                                Regex re2 = new Regex(@"\d+");
                                Match m2 = re2.Match(GetStringBetweenCharacters(input, '+', ';'));

                                Regex re = new Regex(@"\d+");
                                Match m = re.Match(GetStringBetweenCharacters(input, '=', '+'));
                                if (m.Success && m2.Success)
                                {
                                    string VarValue = GetStringBetweenCharacters(input, '=', '+');
                                    string varA = VarValue;

                                    VarValue = GetStringBetweenCharacters(input, '+', ';');
                                    string varB = VarValue;

                                    double varC = float.Parse(varA) + float.Parse(varB);
                                    string varC2 = varC.ToString();
                                    variableValue = varC2;

                                }


                            }
                            else
                            {
                                Console.WriteLine("Neplatná proměnná");
                            }

                        }
                        else if (variableValue.Contains('-'))
                        {
                            //a+1
                            if (variables.ContainsKey(GetStringBetweenCharacters(input, '=', '-')) && !variables.ContainsKey(GetStringBetweenCharacters(input, '-', ';')))
                            {
                                Regex re = new Regex(@"\d+");
                                Match m = re.Match(GetStringBetweenCharacters(input, '-', ';'));

                                if (m.Success)
                                {
                                    string VarValue = GetStringBetweenCharacters(input, '=', '-');
                                    string varA = variables[VarValue];

                                    VarValue = GetStringBetweenCharacters(input, '-', ';');
                                    string varB = VarValue;

                                    double varC = float.Parse(varA) - float.Parse(varB);
                                    string varC2 = varC.ToString();
                                    variableValue = varC2;

                                }
                            }
                            //1+a
                            else if (!variables.ContainsKey(GetStringBetweenCharacters(input, '=', '-')) && variables.ContainsKey(GetStringBetweenCharacters(input, '-', ';')))
                            {
                                Regex re = new Regex(@"\d+");
                                Match m = re.Match(GetStringBetweenCharacters(input, '=', '-'));

                                if (m.Success)
                                {
                                    string VarValue = GetStringBetweenCharacters(input, '=', '-');
                                    string varA = VarValue;

                                    VarValue = GetStringBetweenCharacters(input, '-', ';');
                                    string varB = variables[VarValue];

                                    double varC = float.Parse(varA) - float.Parse(varB);
                                    string varC2 = varC.ToString();
                                    variableValue = varC2;

                                }

                            }
                            //a+a

                            else if (variables.ContainsKey(GetStringBetweenCharacters(input, '=', '-')) && variables.ContainsKey(GetStringBetweenCharacters(input, '-', ';')))
                            {

                                string VarValue = GetStringBetweenCharacters(input, '=', '-');
                                string varA = variables[VarValue];

                                VarValue = GetStringBetweenCharacters(input, '-', ';');
                                string varB = variables[VarValue];

                                double varC = float.Parse(varA) - float.Parse(varB);
                                string varC2 = varC.ToString();
                                variableValue = varC2;

                            }
                            //1+1
                            else if (!variables.ContainsKey(GetStringBetweenCharacters(input, '=', '-')) && !variables.ContainsKey(GetStringBetweenCharacters(input, '-', ';')))
                            {
                                Regex re2 = new Regex(@"\d+");
                                Match m2 = re2.Match(GetStringBetweenCharacters(input, '-', ';'));

                                Regex re = new Regex(@"\d+");
                                Match m = re.Match(GetStringBetweenCharacters(input, '=', '-'));
                                if (m.Success && m2.Success)
                                {
                                    string VarValue = GetStringBetweenCharacters(input, '=', '-');
                                    string varA = VarValue;

                                    VarValue = GetStringBetweenCharacters(input, '-', ';');
                                    string varB = VarValue;

                                    double varC = float.Parse(varA) - float.Parse(varB);
                                    string varC2 = varC.ToString();
                                    variableValue = varC2;

                                }


                            }
                            else
                            {
                                Console.WriteLine("Neplatná proměnná");
                            }

                        }
                        else if (variableValue.Contains('*'))
                        {
                            //a*1
                            if (variables.ContainsKey(GetStringBetweenCharacters(input, '=', '*')) && !variables.ContainsKey(GetStringBetweenCharacters(input, '*', ';')))
                            {
                                Regex re = new Regex(@"\d+");
                                Match m = re.Match(GetStringBetweenCharacters(input, '*', ';'));

                                if (m.Success)
                                {
                                    string VarValue = GetStringBetweenCharacters(input, '=', '*');
                                    string varA = variables[VarValue];

                                    VarValue = GetStringBetweenCharacters(input, '*', ';');
                                    string varB = VarValue;

                                    double varC = float.Parse(varA) * float.Parse(varB);
                                    string varC2 = varC.ToString();
                                    variableValue = varC2;

                                }
                            }
                            //1*a
                            else if (!variables.ContainsKey(GetStringBetweenCharacters(input, '=', '*')) && variables.ContainsKey(GetStringBetweenCharacters(input, '*', ';')))
                            {
                                Regex re = new Regex(@"\d+");
                                Match m = re.Match(GetStringBetweenCharacters(input, '=', '*'));

                                if (m.Success)
                                {
                                    string VarValue = GetStringBetweenCharacters(input, '=', '*');
                                    string varA = VarValue;

                                    VarValue = GetStringBetweenCharacters(input, '*', ';');
                                    string varB = variables[VarValue];

                                    double varC = float.Parse(varA) * float.Parse(varB);
                                    string varC2 = varC.ToString();
                                    variableValue = varC2;

                                }

                            }
                            //a*a

                            else if (variables.ContainsKey(GetStringBetweenCharacters(input, '=', '*')) && variables.ContainsKey(GetStringBetweenCharacters(input, '*', ';')))
                            {

                                string VarValue = GetStringBetweenCharacters(input, '=', '*');
                                string varA = variables[VarValue];

                                VarValue = GetStringBetweenCharacters(input, '*', ';');
                                string varB = variables[VarValue];

                                double varC = float.Parse(varA) * float.Parse(varB);
                                string varC2 = varC.ToString();
                                variableValue = varC2;

                            }
                            //1*1
                            else if (!variables.ContainsKey(GetStringBetweenCharacters(input, '=', '*')) && !variables.ContainsKey(GetStringBetweenCharacters(input, '*', ';')))
                            {
                                Regex re2 = new Regex(@"\d+");
                                Match m2 = re2.Match(GetStringBetweenCharacters(input, '*', ';'));

                                Regex re = new Regex(@"\d+");
                                Match m = re.Match(GetStringBetweenCharacters(input, '=', '*'));
                                if (m.Success && m2.Success)
                                {
                                    string VarValue = GetStringBetweenCharacters(input, '=', '*');
                                    string varA = VarValue;

                                    VarValue = GetStringBetweenCharacters(input, '*', ';');
                                    string varB = VarValue;

                                    double varC = float.Parse(varA) * float.Parse(varB);
                                    string varC2 = varC.ToString();
                                    variableValue = varC2;

                                }


                            }
                            else
                            {
                                Console.WriteLine("Neplatná proměnná");
                            }

                        }
                        else if (variableValue.Contains('/'))
                        {
                            //a/1
                            if (variables.ContainsKey(GetStringBetweenCharacters(input, '=', '/')) && !variables.ContainsKey(GetStringBetweenCharacters(input, '/', ';')))
                            {
                                Regex re = new Regex(@"\d+");
                                Match m = re.Match(GetStringBetweenCharacters(input, '/', ';'));

                                if (m.Success)
                                {
                                    string VarValue = GetStringBetweenCharacters(input, '=', '/');
                                    string varA = variables[VarValue];

                                    VarValue = GetStringBetweenCharacters(input, '/', ';');
                                    string varB = VarValue;

                                    double varC = float.Parse(varA) / float.Parse(varB);
                                    string varC2 = varC.ToString();
                                    variableValue = varC2;

                                }
                            }
                            //1/a
                            else if (!variables.ContainsKey(GetStringBetweenCharacters(input, '=', '/')) && variables.ContainsKey(GetStringBetweenCharacters(input, '/', ';')))
                            {
                                Regex re = new Regex(@"\d+");
                                Match m = re.Match(GetStringBetweenCharacters(input, '=', '/'));

                                if (m.Success)
                                {
                                    string VarValue = GetStringBetweenCharacters(input, '=', '/');
                                    string varA = VarValue;

                                    VarValue = GetStringBetweenCharacters(input, '/', ';');
                                    string varB = variables[VarValue];

                                    double varC = float.Parse(varA) / float.Parse(varB);
                                    string varC2 = varC.ToString();
                                    variableValue = varC2;

                                }

                            }
                            //a/a

                            else if (variables.ContainsKey(GetStringBetweenCharacters(input, '=', '/')) && variables.ContainsKey(GetStringBetweenCharacters(input, '/', ';')))
                            {

                                string VarValue = GetStringBetweenCharacters(input, '=', '/');
                                string varA = variables[VarValue];

                                VarValue = GetStringBetweenCharacters(input, '/', ';');
                                string varB = variables[VarValue];

                                double varC = float.Parse(varA) / float.Parse(varB);
                                string varC2 = varC.ToString();
                                variableValue = varC2;

                            }
                            //1/1
                            else if (!variables.ContainsKey(GetStringBetweenCharacters(input, '=', '/')) && !variables.ContainsKey(GetStringBetweenCharacters(input, '/', ';')))
                            {
                                Regex re2 = new Regex(@"\d+");
                                Match m2 = re2.Match(GetStringBetweenCharacters(input, '/', ';'));

                                Regex re = new Regex(@"\d+");
                                Match m = re.Match(GetStringBetweenCharacters(input, '=', '/'));
                                if (m.Success && m2.Success)
                                {
                                    string VarValue = GetStringBetweenCharacters(input, '=', '/');
                                    string varA = VarValue;

                                    VarValue = GetStringBetweenCharacters(input, '/', ';');
                                    string varB = VarValue;

                                    double varC = float.Parse(varA) / float.Parse(varB);
                                    string varC2 = varC.ToString();
                                    variableValue = varC2;

                                }


                            }
                            else
                            {
                                Console.WriteLine("Neplatná proměnná");
                            }

                        }
                        //strig
                        else if (variableValue.Contains('"'))
                        {
                            variableValue = GetStringBetweenCharacters(variableValue, '"', '"');
                        }
                        //a=b
                        else if (variables.ContainsKey(GetStringBetweenCharacters(input, '=', ';')))
                        {
                            variableValue = variables[GetStringBetweenCharacters(input, '=', ';')];

                        }
                        //Read() - jako Console.ReadeLine()
                        else if (variableValue == "Read()")
                        {
                            variableValue = Console.ReadLine();
                        }
                        if (!variables.ContainsKey(variableName))
                        {
                            variables.Add(variableName, variableValue);
                        }
                        else
                        {
                            variables[variableName] = variableValue;
                        }
                        break;
                    //příkaz print() - stejné jako v konzoli, jen jsou proměnné předělané do tvaru proměnná
                    case string s when s.StartsWith("print("):


                        string text;
                        text = GetStringBetweenCharacters(input, '(', ')');
                        if (text.Contains('"'))
                        {
                            if (text.Contains('+'))
                            {
                                if (GetStringBetweenCharacters(input, '+', ')') != "")
                                {
                                    string var2Name = GetStringBetweenCharacters(input, '+', ')');

                                    string var2 = variables[var2Name];
                                    text = GetStringBetweenCharacters(input, '"', '"');
                                    Console.Write(text + var2);
                                }
                                else
                                {
                                    text = GetStringBetweenCharacters(input, '"', '"');
                                    Console.Write(text);
                                }
                            }
                            else
                            {
                                text = GetStringBetweenCharacters(input, '"', '"');
                                Console.Write(text);
                            }

                        }
                        else
                        {
                            string VariableName = text;
                            if (variables.ContainsKey(VariableName))
                            {

                                //najdu proměnou shodující se se zadaným názvem
                                if (variables.ContainsKey(VariableName))
                                {

                                    Console.Write(variables[VariableName]);

                                }
                                else
                                {
                                    Console.WriteLine("Proměnná nebyla nalezena.");
                                }
                            }
                        }

                        break;
                    case string s when s.StartsWith("printL"):


                        
                        text = GetStringBetweenCharacters(input, '(', ')');
                        if (text.Contains('"'))
                        {
                            if (text.Contains('+'))
                            {
                                if (GetStringBetweenCharacters(input, '+', ')') != "")
                                {
                                    string var2Name = GetStringBetweenCharacters(input, '+', ')');

                                    string var2 = variables[var2Name];
                                    text = GetStringBetweenCharacters(input, '"', '"');
                                    Console.WriteLine(text + var2);
                                }
                                else
                                {
                                    text = GetStringBetweenCharacters(input, '"', '"');
                                    Console.WriteLine(text);
                                }
                            }
                            else
                            {
                                text = GetStringBetweenCharacters(input, '"', '"');
                                Console.WriteLine(text);
                            }

                        }
                        else
                        {
                            string VariableName = text;
                            if (variables.ContainsKey(VariableName))
                            {

                                //najdu proměnou shodující se se zadaným názvem
                                if (variables.ContainsKey(VariableName))
                                {

                                    Console.WriteLine(variables[VariableName]);

                                }
                                else
                                {
                                    Console.WriteLine("Proměnná nebyla nalezena.");
                                }
                            }
                        }

                        break;
                    case string s when s.StartsWith("if"):
                        //>
                        if (GetStringBetweenCharacters(input, '(', ')').Contains('>'))
                        {
                            string A = GetStringBetweenCharacters(input, '(', '>');
                            string B = GetStringBetweenCharacters(input, '>', ')');
                            float Aval;
                            float Bval;
                            if (variables.ContainsKey(A) && !variables.ContainsKey(B))
                            {
                                Aval = float.Parse((variables[A]));
                                Bval = float.Parse(B);
                            }
                            else if (!variables.ContainsKey(A) && variables.ContainsKey(B))
                            {
                                Aval = float.Parse(A);
                                Bval = float.Parse((variables[B]));
                            }
                            else if (variables.ContainsKey(A) && variables.ContainsKey(B))
                            {
                                Aval = float.Parse((variables[A]));
                                Bval = float.Parse((variables[B]));
                            }
                            else if (!variables.ContainsKey(A) && !variables.ContainsKey(B))
                            {
                                Aval = float.Parse(A);
                                Bval = float.Parse(B);
                            }
                            else
                            {
                                Aval = float.Parse(A);
                                Bval = float.Parse(B);
                            }

                            if (Aval > Bval)
                            {
                                RunCode(GetStringBetweenCharacters(input, '{', '}'), variables, true);
                            }

                        }
                        //<
                        if (GetStringBetweenCharacters(input, '(', ')').Contains('<'))
                        {
                            string A = GetStringBetweenCharacters(input, '(', '<');
                            string B = GetStringBetweenCharacters(input, '<', ')');
                            float Aval;
                            float Bval;
                            if (variables.ContainsKey(A) && !variables.ContainsKey(B))
                            {
                                Aval = float.Parse((variables[A]));
                                Bval = float.Parse(B);
                            }
                            else if (!variables.ContainsKey(A) && variables.ContainsKey(B))
                            {
                                Aval = float.Parse(A);
                                Bval = float.Parse((variables[B]));
                            }
                            else if (variables.ContainsKey(A) && variables.ContainsKey(B))
                            {
                                Aval = float.Parse((variables[A]));
                                Bval = float.Parse((variables[B]));
                            }
                            else if (!variables.ContainsKey(A) && !variables.ContainsKey(B))
                            {
                                Aval = float.Parse(A);
                                Bval = float.Parse(B);
                            }
                            else
                            {
                                Aval = 0;
                                Bval = 0;
                            }
                            if (Aval < Bval)
                            {
                                RunCode(GetStringBetweenCharacters(input, '{', '}'), variables, true);
                            }

                        }
                        //=
                        if (GetStringBetweenCharacters(input, '(', ')').Contains('='))
                        {
                            string A = GetStringBetweenCharacters(input, '(', '=');
                            string B = GetStringBetweenCharacters(input, '=', ')');
                            Regex re = new Regex(@"\d+");
                            Match m = re.Match(A);
                            Match m2 = re.Match(B);

                            if (m.Success || m2.Success)
                            {
                                float Aval;
                                float Bval;

                                if (variables.ContainsKey(A) && !variables.ContainsKey(B))
                                {
                                    Aval = float.Parse((variables[A]));
                                    Bval = float.Parse(B);
                                }
                                else if (!variables.ContainsKey(A) && variables.ContainsKey(B))
                                {
                                    Aval = float.Parse(A);
                                    Bval = float.Parse((variables[B]));
                                }
                                else if (variables.ContainsKey(A) && variables.ContainsKey(B))
                                {
                                    Aval = float.Parse((variables[A]));
                                    Bval = float.Parse((variables[B]));
                                }
                                else if (!variables.ContainsKey(A) && !variables.ContainsKey(B))
                                {
                                    Aval = float.Parse(A);
                                    Bval = float.Parse(B);
                                }
                                else
                                {
                                    Aval = float.Parse(A);
                                    Bval = float.Parse(B);
                                }
                                if (Aval == Bval)
                                {
                                    RunCode(GetStringBetweenCharacters(input, '{', '}'), variables, true);
                                }

                            }
                            else
                            {
                                if (B.Contains('"'))
                                {
                                    Console.WriteLine(GetStringBetweenCharacters(variables[A], '"', '"'));
                                    Console.WriteLine(GetStringBetweenCharacters(GetStringBetweenCharacters(input, '(', ')'), '"', '"'));
                                    if (GetStringBetweenCharacters(variables[A], '"', '"') == GetStringBetweenCharacters(GetStringBetweenCharacters(input, '(', ')'), '"', '"'))
                                    {
                                        RunCode(GetStringBetweenCharacters(input, '{', '}'), variables, true);
                                    }
                                }
                                else
                                {
                                    if (variables[A] == variables[B])
                                    {
                                        RunCode(GetStringBetweenCharacters(input, '{', '}'), variables, true);
                                    }
                                }


                            }



                        }
                        break;

                    //pokud je to komentář, nic nedělat
                    case string s2 when s2.StartsWith("//"):
                        break;
                    case string s when s.StartsWith("open"):
                        //jméo souboru je mezi "" a pokud existuje, načte se
                        if (fileName == "")
                        {
                            fileName = GetStringBetweenCharacters(input, '"', '"');
                        }
                        
                        if (File.Exists(fileName))
                        {
                            using (StreamReader reader = new StreamReader(fileName))
                            {
                                //dokud je další řádek plný, opakuje cyklus
                                while ((input = reader.ReadLine()) != null)
                                {
                                    RunCode(input, variables, false);
                                    Console.Title = fileName;
                                }
                            }
                        }
                        //pokud soubor neexistuje, vypíše to chybu
                        else
                        {
                            Console.WriteLine($"Soubor {fileName} neexistuje");
                        }
                        break;
                    case string s when s.StartsWith("for"):

                        int i2;
                        int x; ;
                        string forinput = GetStringBetweenCharacters(input, '{', '}');
                        if (GetStringBetweenCharacters(input, '(', ')').Contains('>')){
                            i2 = int.Parse(variables[GetStringBetweenCharacters(input, '(', '>')]);
                            x = int.Parse(GetStringBetweenCharacters(input, '>', ')'));
                            for (i2 = i2; i2 > x; i2++)
                            {
                                variables[GetStringBetweenCharacters(input, '(', '>')] = i2.ToString();
                                RunCode(forinput, variables, true);
                                
                                
                            }
                        }
                        if (GetStringBetweenCharacters(input, '(', ')').Contains('<'))
                        {
                            i2 = int.Parse(variables[GetStringBetweenCharacters(input, '(', '<')]);
                            x = int.Parse(GetStringBetweenCharacters(input, '<', ')'));
                            for (i2 = i2; i2 < x; i2++)
                            {
                                variables[GetStringBetweenCharacters(input, '(', '<')] = i2.ToString();
                                RunCode(forinput, variables, true);
                                
                            }
                        }

                        break;
                    case string s when s.StartsWith("Clear()"):
                        Console.Clear();
                        break;
                    case string s when s.StartsWith("ReadKey()"):
                        Console.ReadKey();
                        break;
                    case string s when s.StartsWith("Loop()"):
                        runWithArgs = true;
                        
                       
                        input2 = fileName;
                        break;
                    //pokud příkaz neexistuje, vypíše to chybu
                    default:
                        Console.WriteLine("Neznámý příkaz");
                        break;
                }
            }

        }

        /*public static void loop(Dictionary<string, string> variables, string fileName)
        {
            string l_input;
            using (StreamReader reader = new StreamReader(fileName))
            {
                //dokud je další řádek plný, opakuje cyklus
                while ((l_input = reader.ReadLine()) != "loop()")
                {
                    RunCode(l_input, variables, false);
                }
                if (!((l_input = reader.ReadLine()) != "loop()"))
                {
                    loop(variables, fileName);
                }
                //loop(input, variables);
            }
        }*/
        //deklarace kódu pro získání kódu mezi znaky
        public static string GetStringBetweenCharacters(string input, char charFrom, char charTo)
        {
            int posFrom = input.IndexOf(charFrom);
            if (posFrom != -1) //pokud najde zadaný znak
            {
                int posTo = input.IndexOf(charTo, posFrom + 1);
                if (posTo != -1) //pokud najde zadaný znak
                {
                    return input.Substring(posFrom + 1, posTo - posFrom - 1);
                }
            }

            return string.Empty;
        }
    }
}

