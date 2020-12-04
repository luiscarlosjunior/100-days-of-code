
namespace Strategy
{
    // This interface declares operations common to all supported version
    // of some algorithm
    // The context uses this interface to call the algorithm defined by Concret
    // Strategy
    public interface IStrategy
    {
        object DoAlgorithm(object data);
    }

}
