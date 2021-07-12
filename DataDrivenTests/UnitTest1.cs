using NUnit.Framework;
using System;

namespace DataDrivenTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Category("DataDriven")]
        [TestCase("Ameya")]
        [TestCase("Nithin")]
        [TestCase("Soumya")]
        [TestCase("Nesar")]
        public void Test1(string name)
        {
            Console.WriteLine(name);
        }
    }
}