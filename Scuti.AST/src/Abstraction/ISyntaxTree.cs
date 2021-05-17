namespace Scuti.AST.Abstraction
{
    public interface ISyntaxTree
    {
        ISyntaxTree Next { get; }
        ContinuationStates Execute();
    }
    
    public enum ContinuationStates {
        CONTINUE,
        BREAK
    }
}