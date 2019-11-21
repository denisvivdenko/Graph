﻿using System;
using System.Collections.Generic;
using System.Text;
using Graph.GraphInterface;

namespace Graph.Graphs
{
    class DirectedUnweightedGraph<TNodeType> : IGraph<TNodeType>
    {
        private List<TNodeType> nodes;
        private readonly int len;
        private Dictionary<TNodeType, List<TNodeType>> adjacencyList;

        public DirectedUnweightedGraph(int len)
        {
            this.len = len;
            adjacencyList = new Dictionary<TNodeType, List<TNodeType>>();
            
        }
        
        public void AddEdge(TNodeType from, TNodeType to, int weight = 0)
        {
            if ( !(adjacencyList.ContainsKey(from) && adjacencyList.ContainsKey(to)) )
            {
                throw new Exception("There is no such node");
            }
            else
            {
                adjacencyList[from].Add(to);
            }
        }

        public void AddNode(TNodeType node)
        {
            if (!adjacencyList.ContainsKey(node))
            {
                adjacencyList.Add(node, new List<TNodeType>());
            }
        }

        public void RemoveEdge(TNodeType from, TNodeType to)
        {
            if (adjacencyList.ContainsKey(from) && adjacencyList[from].Contains(to))
            {
                adjacencyList[from].Remove(to);
            } 
            else
            {
                throw new Exception("There is not such edge");
            }
        }

        public void RemoveNode(TNodeType node)
        {
            if (adjacencyList.ContainsKey(node))
            {
                adjacencyList.Remove(node);
            }
            else
            {
                throw new Exception("There is not such node");
            }
        }

        public void DFS(TNodeType sPoint)
        {
            Dictionary<TNodeType, bool> visited = new Dictionary<TNodeType, bool>() ;
            foreach (TNodeType item in adjacencyList.Keys)
            {
                visited.Add(item, false);
            }

            DFSUtil(sPoint, visited);
        }

        private void DFSUtil(TNodeType currentPoint ,Dictionary<TNodeType, bool> visited)
        {
            visited[currentPoint] = true;

            foreach (TNodeType nextPoint in adjacencyList[currentPoint])
            {
                if (visited[nextPoint] == false)
                {
                    Console.WriteLine("{0} -> {1}", currentPoint, nextPoint);
                    DFSUtil(nextPoint, visited);
                }
            }
        }
    }
}
