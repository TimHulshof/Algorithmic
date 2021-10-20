namespace Algorithmic
{
    public interface IAlgorithm
    {
        public AlgorithmType AlgorithmType { get; }
        public string Name { get; }
        public string Description { get; }
    }
}
