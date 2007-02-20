using System;
using System.Reflection;
using NUnit.Framework;
using Rhino.Mocks;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using StructureMap.Testing.Widget3;

namespace StructureMap.Testing.Configuration.DSL
{
    [TestFixture]
    public class RegistryTester
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void CallAllExpressionsOnConfigure()
        {
            MockRepository mocks = new MockRepository();
            IExpression expression1 = mocks.CreateMock<IExpression>();
            IExpression expression2 = mocks.CreateMock<IExpression>();
            IExpression expression3 = mocks.CreateMock<IExpression>();
        
            PluginGraph graph = new PluginGraph();
            expression1.Configure(graph);
            expression2.Configure(graph);
            expression3.Configure(graph);
        
            mocks.ReplayAll();

            TestRegistry registry = new TestRegistry();
            registry.AddExpression(expression1);
            registry.AddExpression(expression2);
            registry.AddExpression(expression3);

            registry.Configure(graph);

            mocks.VerifyAll();
        }

        [Test]
        public void DisposeCallsConfigure()
        {
            MockRepository mocks = new MockRepository();
            IExpression expression1 = mocks.CreateMock<IExpression>();
            IExpression expression2 = mocks.CreateMock<IExpression>();
            IExpression expression3 = mocks.CreateMock<IExpression>();

            PluginGraph graph = new PluginGraph();
            expression1.Configure(graph);
            expression2.Configure(graph);
            expression3.Configure(graph);

            mocks.ReplayAll();

            using (TestRegistry registry = new TestRegistry(graph))
            {
                registry.AddExpression(expression1);
                registry.AddExpression(expression2);
                registry.AddExpression(expression3);                
            }

            mocks.VerifyAll();
        }



    
    }

    public class TestRegistry : Registry
    {
        public TestRegistry(PluginGraph graph) : base(graph)
        {
        }


        public TestRegistry()
        {
        }

        public void AddExpression(IExpression expression)
        {
            addExpression(expression);
        }
    }

    public class FakeGateway : IGateway
    {
        public void DoSomething()
        {
            throw new NotImplementedException();
        }

        public string WhoAmI
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class Fake2Gateway : IGateway
    {
        public void DoSomething()
        {
            throw new NotImplementedException();
        }

        public string WhoAmI
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class Fake3Gateway : IGateway
    {
        public void DoSomething()
        {
            throw new NotImplementedException();
        }

        public string WhoAmI
        {
            get { throw new NotImplementedException(); }
        }
    }
}