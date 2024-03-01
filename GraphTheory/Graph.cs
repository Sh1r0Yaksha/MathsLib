using MathsLib.LinearAlgebra;

namespace MathsLib.GraphTheory
{
    public abstract class Graph
    {
        #region Protected Variables
        protected int currentLabel;
        #endregion

        #region Public Variables and Properties
        public Matrix Adjacency { get; set; }
        public virtual Matrix DegreeMatrix { get; }
        public Matrix Laplacian
        {
            get
            {
                return DegreeMatrix - Adjacency;
            }
        }
        public Node[] Nodes { get; protected set; }
        public int NumNodes => Adjacency.Rows;
        public virtual int NumEdges { get; }
        public virtual double MeanDegree { get; }
        public double Density
        {
            get
            {
                return MeanDegree / (NumNodes - 1);
            }
        }
        #endregion

        #region Constructor
        public Graph(int numNodes)
        {
            Adjacency = new Matrix(numNodes, numNodes);
            DegreeMatrix = new Matrix(numNodes, numNodes);
            Nodes = new Node[numNodes];
            currentLabel = 0;
        }
        #endregion

        #region Protected Methods
        protected void AddNode(Node node)
        {
            if (!Nodes.Contains(node))
            {
                Nodes[currentLabel] = node;
                currentLabel++;
            }
        }
        #endregion

        #region Public Methods

        #endregion
    }
}