namespace Algorithmic.Analysis
{
    public interface ITimeComplexity
    {
        public Complexity BestComplexity { get; }
        public Complexity AverageComplexity { get; }
        public Complexity WorstComplexity { get; }
    }
}
