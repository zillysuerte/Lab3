using System.Text.Json;
using System.Xml.Serialization;
using Lab4;


namespace Lab4
{
    class Program
    {
        static SolutionsData SolutionToData (Solution solutionToData, int id)
        {
            SolutionsData data = new SolutionsData();
            if (solutionToData.Equation.Members.Count() == 3)
            {
                data.A = solutionToData.Equation.Members.ElementAt(2).Factor;
            }
            else
            {
                data.A = 0;
            }
            data.B = solutionToData.Equation.Members.ElementAt(1).Factor;
            data.C = solutionToData.Equation.Members.ElementAt(0).Factor;
            data.NumberOfRoots = solutionToData.Roots.Count();
            if (data.NumberOfRoots == 1)
            {
                data.Root1 = solutionToData.Roots.First();
            }
            else if (data.NumberOfRoots == 2)
            {
                data.Root2 = solutionToData.Roots.Last();
            }
            data.Id = id;
            return data;
        }

        static void SaveJson(SolutionsData data, int id)
        {
            string jsonString = JsonSerializer.Serialize(data);
            File.AppendAllText("C:\\Users\\sanya\\Documents\\cSharp\\saving.json", jsonString);
        }

        static void SaveXML(SolutionsData data, int id)
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(SolutionsData));
            StreamWriter myWriter = new StreamWriter("C:\\Users\\sanya\\Documents\\cSharp\\saving.xml",true);
            mySerializer.Serialize(myWriter, data);
            myWriter.Close();
        }

        static void SaveSQLite(SolutionsData data, int id)
        {
            // Create
           // Console.WriteLine("Inserting a new equation");
            using var db = new EquationContext();

            db.Add(data);
            db.SaveChanges();
        }

        static void Save(Solution solutionToData, int method, int id)
        {
            SolutionsData data = SolutionToData(solutionToData,id);
            

            switch (method)
            {
                case 1:
                    SaveJson(data, id);
                    break;
                case 2:
                    SaveXML(data, id);
                    break;
                case 3:
                    SaveSQLite(data, id);
                    break;
                case 4:
                    break;
            }
        }
        static void Main(string[] args)
        {

            EquationSolver equationSolver = new EquationSolver();

            try
            {
                int command = 0;
                int method = 0;

                do
                {

                    Console.WriteLine("Use one of commands:");
                    Console.WriteLine(" 1 - to select type of an equation and solve it");
                    Console.WriteLine(" 2 - to get existing solution from memory");
                    Console.WriteLine(" 3 - to exit");
                    command = int.Parse(Console.ReadLine());
                    
                    if (command == 1)
                    {
                        Console.WriteLine("Choose the method of saving:");
                        Console.WriteLine(" 1 - JSON");
                        Console.WriteLine(" 2 - XML");
                        Console.WriteLine(" 3 - SQLite");
                        Console.WriteLine(" 4 - not save");
                        method = int.Parse(Console.ReadLine());
                        Console.WriteLine("Select the type of equation:");
                        Console.WriteLine("1 - k * x + b = 0");
                        Console.WriteLine("2 - a * x^2 + b * x + c = 0");
                        try
                        {
                            var degree = int.Parse(Console.ReadLine());
                            if (degree == 1)
                            {
                                Console.WriteLine("Input the factors:");

                                try
                                {
                                    Console.Write("Factor 'k':");
                                    var k = double.Parse(Console.ReadLine());
                                    Console.Write("Free member 'b':");
                                    var b = double.Parse(Console.ReadLine());


                                    EquationMember bx = new EquationMember(b, 0);
                                    EquationMember kx = new EquationMember(k, 1);

                                    var parts = new EquationMember[] { bx, kx };

                                    Equation equation = new Equation(parts);
                                    Solution solution = equation.Result;

                                    equationSolver.Add(solution);
                                    Console.WriteLine(solution.ToString());
                                    Save(solution, method, equationSolver.Size());
                                    ////////
                                }
                                catch (FormatException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else if (degree == 2)
                            {
                                Console.WriteLine("Input the factors:");

                                try
                                {
                                    Console.Write("Factor 'a':");
                                    var a = double.Parse(Console.ReadLine());
                                    Console.Write("Factor 'b':");
                                    var b = double.Parse(Console.ReadLine());
                                    Console.Write("Factor 'c':");
                                    var c = double.Parse(Console.ReadLine());



                                    EquationMember cx = new EquationMember(c, 0);
                                    EquationMember bx = new EquationMember(b, 1);
                                    EquationMember ax = new EquationMember(a, 2);

                                    var parts = new EquationMember[] { cx, bx, ax };

                                    Equation equation = new Equation(parts);
                                    Solution solution = equation.Result;
                                    equationSolver.Add(solution);
                                    Console.WriteLine(solution.ToString());
                                    Save(solution, method, equationSolver.Size());
                                    ////////
                                }
                                catch (FormatException ex)
                                {
                                    throw new Exception("factors need to be number");
                                }
                            }
                            else
                            {
                                throw new Exception("not expected variant of the equation (need 1 or 2)");
                            }
                        }
                        catch (FormatException ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                    else if (command == 2)
                    {
                        Console.WriteLine("Input the index:");
                        try
                        {
                            var index = int.Parse(Console.ReadLine()) - 1;
                            if (index < 0 || index >= equationSolver.Size())
                            {
                                Console.WriteLine("not existing index");
                                ////??
                            }
                            else
                            {
                                Solution solution = equationSolver.GetEquationAt(index);
                                Console.WriteLine("#" + (index + 1) + " " + solution.ToString());
                            }
                        }
                        catch (FormatException ex)
                        {
                            throw new Exception("index need to be int and > 0");
                        }
                    }
                    else if (command == 3)
                    {
                        break;
                    }
                    else
                    {
                        throw new Exception("not expected command (need 1,2 or 3)");
                    }
                } while ((command != 3));
            }
            catch (FormatException ex)
            {
                throw new Exception("not expected command (need 1,2 or 3)");
            }
        }
    }
}