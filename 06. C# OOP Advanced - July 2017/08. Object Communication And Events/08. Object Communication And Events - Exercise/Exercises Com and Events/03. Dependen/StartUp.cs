namespace _03.Dependen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class StartUp
    {
        public static void Main()
        {
            PrimitiveCalculator calc = new PrimitiveCalculator();

            string commandArgs = string.Empty;

            while ((commandArgs = Console.ReadLine()) != "End")
            {
                if (commandArgs.StartsWith("mode"))
                {
                    char @operator = commandArgs.TrimEnd().ToCharArray().Last();
                    calc.ChangeStrategy(@operator);
                }
                else
                {
                    int[] numbers = commandArgs.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                    Console.WriteLine(calc.PerformCalculation(numbers[0], numbers[1]));
                }
            }
        }
        class PrimitiveCalculator
        {
            private bool isAddition;
            private ICalculationStrategy currentStrategy;
            private IList<ICalculationStrategy> calculatorStrategies;

            public PrimitiveCalculator()
            {
                ICalculationStrategy addition = new AdditionStrategy();

                this.calculatorStrategies = new List<ICalculationStrategy>
                {
                    addition,
                    new SubtractionStrategy(),
                    new MultiplicationStrategy(),
                    new DivisionStrategy()
                };
                this.currentStrategy = addition;
            }

            public void ChangeStrategy(char @operator)
            {
                ICalculationStrategy strategy = this.calculatorStrategies.FirstOrDefault(s => s.Operator == @operator);
                if (strategy != null)
                {
                    this.currentStrategy = strategy;
                }
            }

            public int PerformCalculation(int firstOperand, int secondOperand)
            {
                return this.currentStrategy.Calculate(firstOperand, secondOperand);
            }
        }

        class AdditionStrategy : ICalculationStrategy
        {
            public AdditionStrategy()
            {
                this.Operator = '+';
            }

            public char Operator { get; private set; }

            public int Calculate(int firstOperand, int secondOperand)
            {
                return firstOperand + secondOperand;
            }
        }

        public class DivisionStrategy : ICalculationStrategy
        {
            public DivisionStrategy()
            {
                this.Operator = '/';
            }

            public char Operator { get; private set; }

            public int Calculate(int firstOperand, int secondOperand)
            {
                return firstOperand / secondOperand;
            }
        }

        public class MultiplicationStrategy : ICalculationStrategy
        {
            public MultiplicationStrategy()
            {
                this.Operator = '*';
            }

            public char Operator { get; private set; }

            public int Calculate(int firstOperand, int secondOperand)
            {
                return firstOperand * secondOperand;
            }
        }

        class SubtractionStrategy : ICalculationStrategy
        {
            public SubtractionStrategy()
            {
                this.Operator = '-';
            }

            public char Operator { get; private set; }

            public int Calculate(int firstOperand, int secondOperand)
            {
                return firstOperand - secondOperand;
            }
        }

        internal interface ICalculationStrategy
        {
            char Operator { get; }

            int Calculate(int firstOperand, int secondOperand);
        }
    }
}
