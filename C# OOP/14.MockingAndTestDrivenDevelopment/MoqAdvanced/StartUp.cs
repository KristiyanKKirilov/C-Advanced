using Moq;
using MoqAdvanced.Contracts;
using System;

namespace MoqAdvanced
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Mock<ICalculator> calculatorMock = new();
            calculatorMock.Setup(c => c.Add(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(111)
                .Callback<int, int>((a, b) =>
                {
                    Console.WriteLine(a + b);
                });

            calculatorMock.Setup(c => c.Add(It.IsInRange<int>(1, 10, Moq.Range.Inclusive), It.IsAny<int>()))
                .Returns(-1);

            calculatorMock.Setup(c => c.Add(5, 6))
                .Returns(11);

            Console.WriteLine(calculatorMock.Object.Add(5, 6));
            Console.WriteLine(calculatorMock.Object.Add(1, 6));
            Console.WriteLine(calculatorMock.Object.Add(11, 6));
        }
    }
}