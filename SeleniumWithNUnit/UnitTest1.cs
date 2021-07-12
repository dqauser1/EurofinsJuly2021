using NUnit.Framework;
using System;

namespace SeleniumWithNUnit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Inside Setup Method");
        }

        [Test]
        public void Test1()
        {
            Console.WriteLine("Inside Test1");
            Assert.Pass();
        }

        [TearDown]
        public void Cleanup()
        {
            Console.WriteLine("Inside TearDown");
        }
    }
}