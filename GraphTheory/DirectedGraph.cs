using MathsLib.LinearAlgebra;

namespace MathsLib.GraphTheory
{
    public class DirectedGraph : Graph
    {
        public override int NumEdges
        {
            get
            {
                int sumDegree = 0;
                foreach (Node node in Nodes)
                {
                    sumDegree += GetInDegree(node);
                }
                return sumDegree;
            }
        }
        public override double MeanDegree
        {
            get
            {
                return NumEdges / NumNodes;
            }
        }
        public override Matrix DegreeMatrix
        {
            get
            {
                Matrix degree = CommonMatrices.Identity(NumNodes);
                for (int i = 0; i < NumNodes; i++)
                {
                    degree[i, i] = GetInDegree(Nodes[i]);
                }
                return degree;
            }
        }
        public DirectedGraph(int numNodes) : base(numNodes){}

        #region Public Methods
        public void AddEdge(Node source, Node destination, int weight = 1)
        {
            AddNode(source);
            source.Label = Array.IndexOf(Nodes, source);
            AddNode(destination);
            destination.Label = Array.IndexOf(Nodes, destination);
            Adjacency[destination.Label, source.Label] = weight;
        }

        public int GetInDegree(Node node)
        {
            int inDegree = 0;
            for (int i = 0; i < NumNodes; i++)
            {
                inDegree += (int)Adjacency[node.Label, i];
            }
            return inDegree;
        }

        public int GetOutDegree(Node node)
        {
            int outDegree = 0;
            for (int i = 0; i < NumNodes; i++)
            {
                outDegree += (int)Adjacency[i, node.Label];
            }
            return outDegree;
        }
        #endregion
    }
}