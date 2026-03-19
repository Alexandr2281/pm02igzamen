using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Приложение для поиска кратчайшего пути между двумя точками на карте города Кольчугино.");

        
        Console.Write("Введите количество точек на карте: ");
        int numNodes;
        do
        {
            string imput = Console.ReadLine();
            
            if (int.TryParse(imput, out numNodes))
            {
                if(numNodes > 0)
                {
                    break;
                }
                Console.WriteLine("число должно быть положительным.");
            }
            else { Console.WriteLine("ошибка валидации."); }

            
        } while (true);
        

        double[,] adjacencyMatrix = new double[numNodes, numNodes];

        
        FillAdjacencyMatrix(adjacencyMatrix);

        
        DialogMode(numNodes, adjacencyMatrix);
    }

    
    static void FillAdjacencyMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (i == j)
                {
                    matrix[i, j] = 0; 
                }
                else
                {
                    do
                    {
                        Console.Write($"Расстояние между точкой {i + 1} и точкой {j + 1}: ");
                    string input = Console.ReadLine();

                    if (input == "")
                    {
                        matrix[i, j] = matrix[j, i] = double.PositiveInfinity; 
                    }
                    else
                    {
                            double outPut;
                            if (double.TryParse(input, out outPut))
                        {
                            if (outPut > 0)
                            {
                                break;
                            }
                            Console.WriteLine("число должно быть положительным.");
                        }
                        else { Console.WriteLine("ошибка валидации."); }

                        matrix[i, j] = matrix[j, i] = outPut; 
                    }

                    } while (true);

                }
            }
        }
    }

    
    static void DialogMode(int nodesCount, double[,] adjMatrix)
    {
        while (true)
        {
            Console.Write("Введите начальную точку маршрута (или 0 для выхода): ");
            int startPoint = Convert.ToInt32(Console.ReadLine()) - 1;

            if (startPoint == -1) break;

            Console.Write("Введите конечную точку маршрута (или 0 для выхода): ");
            int endPoint = Convert.ToInt32(Console.ReadLine()) - 1;

            if (endPoint == -1) break;

           
            var shortestDistances = Graph.Dijkstra(adjMatrix, startPoint);

           
            Console.WriteLine($"Кратчайший путь между точкой {startPoint + 1} и точкой {endPoint + 1}: {shortestDistances[endPoint]}");
        }
    }
}