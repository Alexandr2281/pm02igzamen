
using System;

public class Graph
{
    public const int MAX_NODES = 100; 
    
    public static double[] Dijkstra(double[,] graphMatrix, int startNode)
    {
        int n = graphMatrix.GetLength(0); 

        double[] distances = new double[n]; 
        bool[] visited = new bool[n];      
        int remainingNodes = n;             

       
        for (int i = 0; i < n; i++)
        {
            distances[i] = double.MaxValue;
        }
        distances[startNode] = 0.0;

       
        while (remainingNodes > 0)
        {
            int currentVertex = -1;

           
            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    if (currentVertex == -1 || distances[currentVertex] > distances[i])
                    {
                        currentVertex = i;
                    }
                }
            }

           
            visited[currentVertex] = true;
            remainingNodes--;

            
            for (int j = 0; j < n; j++)
            {
                if (graphMatrix[currentVertex, j] != 0 && !visited[j])
                {
                    double possibleDistance = distances[currentVertex] + graphMatrix[currentVertex, j];

                    if (possibleDistance < distances[j])
                    {
                        distances[j] = possibleDistance;
                    }
                }
            }
        }
        return distances;
        // коментарий для ветки develop
    }
}