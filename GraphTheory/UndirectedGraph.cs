using MathsLib.LinearAlgebra;

namespace MathsLib.GraphTheory
{
    public class UndirectedGraph : Graph
    {
        #region  Public Fields and Properties
        public override int NumEdges
        {
            get
            {
                int sumDegree = 0;

                foreach (Node node in Nodes)
                {
                    sumDegree += GetDegree(node);
                }

                return sumDegree / 2;
            }
        }
        public override double MeanDegree
        {
            get
            {
                return 2 * NumEdges / NumNodes;
            }
        }
        public override Matrix DegreeMatrix
        {
            get
            {
                Matrix degree = CommonMatrices.Identity(NumNodes);
                for (int i = 0; i < NumNodes; i++)
                {
                    degree[i, i] = GetDegree(Nodes[i]);
                }
                return degree;
            }
        }
        #endregion
        public UndirectedGraph(int numNodes) : base(numNodes)
        {

        }

         #region Public Methods
        public void AddEdge(Node source, Node destination, int weight = 1)
        {
            AddNode(source);
            source.Label = Array.IndexOf(Nodes, source);
            AddNode(destination);
            destination.Label = Array.IndexOf(Nodes, destination);
            Adjacency[destination.Label, source.Label] = weight;
            Adjacency[source.Label, destination.Label] = weight;
        }

        public int GetDegree(Node node)
        {
            int degree = 0;
            for (int i = 0; i < NumNodes; i++)
            {
                degree += (int)Adjacency[node.Label, i];
            }
            return degree;
        }
        #endregion
    }
}