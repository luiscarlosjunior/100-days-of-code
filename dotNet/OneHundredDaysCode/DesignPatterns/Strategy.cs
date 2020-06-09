using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

// Strategy é um padrão de projetos comportamental que transforma um conjunto de comportamento de objetos e os torna intercambiaveis dentro do objeto de contexto original;

namespace DesignPatterns
{
    class Context
    {
        private IStrategy strategy;

        public Context() { }

        // usualmente o context aceita uma estratégia através do construtor.
        public Context(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void DoSomeBusinessLogic()
        {
            Console.WriteLine("Context: Sorting data usgin the strategy");
            var result = this.strategy.DoAlgorithm(new List<string> { "a", "b", "c", "d", "e" });

            string resultStr = string.Empty;
            foreach (var item in result as List<string>)
            {
                resultStr += item + ", ";
            }

            Console.WriteLine(resultStr);
        }
    }

    public interface IStrategy
    {
        object DoAlgorithm(object data);
    }

    // Concrete Strategies
    class ConcreteStrategyA : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Sort();

            return list;
        }
    }

    class ConcreteStrategyB : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Sort();
            list.Reverse();

            return list;
        }
    }

    class Strategy
    {
    }
}
