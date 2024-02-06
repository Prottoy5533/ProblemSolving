using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice
{
    public class Graph
    {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        //public Dictionary<int, List<int>> BuildGraph(int[][] edges)
        //{
        //   var graph = new Dictionary<int, List<int>>();

        //    foreach (int[] edge in edges)
        //    {
        //        int x = edge[0];
        //        int y = edge[1];

        //        if (!graph.ContainsKey(x))
        //        {
        //            graph[x] = new List<int>();
        //        }
        //        graph[x].Add(y);

        //        // Uncomment the following lines if the graph is undirected
        //        // if (!graph.ContainsKey(y))
        //        // {
        //        //     graph[y] = new List<int>();
        //        // }
        //        // graph[y].Add(x);
        //    }

        //    return graph;
        //}

        public bool ValidPath(int n, int[][] edges, int source, int destination)
        {
            
            foreach (int[] edge in edges)
            {
                int x = edge[0];
                int y = edge[1];

                if (!graph.ContainsKey(x))
                {
                    graph[x] = new List<int>();
                }
                graph[x].Add(y);

                if (!graph.ContainsKey(y))
                {
                    graph[y] = new List<int>();
                }
                graph[y].Add(x);
            }

            return HasPath(source, destination);    
        }

        public bool HasPath(int s, int d)
        {
            var queue = new Queue<int>();  
            var visited = new HashSet<int>();

            queue.Enqueue(s);
            visited.Add(s);

            while(queue.Count > 0)
            {
                int currentNode = queue.Dequeue();
                if (currentNode == d)
                    return true;

                foreach (var neighbour in graph[currentNode])
                {
                    if(!visited.Contains(neighbour))
                    {
                        queue.Enqueue(neighbour);
                        visited.Add(neighbour);
                    }

                }
            }

            return false;
        }

        public static int BandMemberAtK(int totalMembers, int[,] swapMembers, int posMember)
    {
        List<int> bandMembers = new List<int>();

        for (int i = 0; i < totalMembers; i++)
        {
            bandMembers.Add(i + 1);
        }

        for (int i = 0; i < swapMembers.GetLength(0); i++)
        {
            int position1 = swapMembers[i, 0];
            int position2 = swapMembers[i, 1];
            SwapBandMembers(bandMembers, position1, position2);
        }

        int kthMemberID = GetKthMemberID(bandMembers, posMember);

        return kthMemberID;
    }

    private static void SwapBandMembers(List<int> bandMembers, int position1, int position2)
    {
        int tempPosition = bandMembers[position1 - 1];
        bandMembers[position1 - 1] = bandMembers[position2 - 1];
        bandMembers[position2 - 1] = tempPosition;
    }

    private static int GetKthMemberID(List<int> bandMembers, int kthPosition)
    {
        return bandMembers[kthPosition - 1];
    }
    }
}
