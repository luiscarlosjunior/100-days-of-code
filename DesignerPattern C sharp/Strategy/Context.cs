using System;
using System.Collections.Generic;

namespace Strategy
{
    /// <summary>
    /// The context creates a specific strategy object and passes it
    /// to context. The context exposes a setter which lets clients replace the strategy associated with the context at runtime
    /// </summary>
    class Context
    {
        /// <summary>
        /// The context maintains a reference to one of the Strategy object.
        /// Context does not know the concrete class of a strategy. It should work
        /// with all strategies via the Strategy interface.
        /// </summary>
        private IStrategy _strategy;

        public Context()
        {

        }

        // Usually, the context accepts a strategy through the contructor, b also
        // provides a setter to change it at runtime.
        public Context(IStrategy strategy)
        {
            _strategy = strategy;
        }

        // Usually, the Context allows replacing a Strategy object at runtime
        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        // the context delegates some work to the Strategy object instead of 
        // implementing multiple versions of the algorithm on its own.
        public void DoSomeBusinessLogic()
        {
            Console.WriteLine("Context: Sorting data using the strategy (not sure how it'll do it");
            var result = this._strategy.DoAlgorithm(new List<string> { "a", "c", "g", "b" });

            string resultStr = string.Empty;

            foreach (var element in result as List<string>)
            {
                resultStr += element + ", ";
            }

            Console.WriteLine(resultStr);
        }
    }
}
