using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Mazes.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mazes.Runner.Tests
{
    [TestClass]
    public class LoaderTest
    {
        [TestMethod]
        public void LoadSolverReturnsStupidSolver()
        {
            var assemblyPath = Assembly.GetAssembly(typeof(SampleMazeSolver.StupidSolver)).Location;

            var solver = Loader.Load<IMazeSolver>(assemblyPath);

            Assert.IsNotNull(solver);
            Assert.IsInstanceOfType(solver, typeof(SampleMazeSolver.StupidSolver));
        }

        [TestMethod]
        public void LoadBuilderReturnsSimpleBuilder()
        {
            var assemblyPath = Assembly.GetAssembly(typeof(SampleMazeBuilder.SimpleMazeBuilder)).Location;

            var builder = Loader.Load<IMazeBuilder>(assemblyPath);

            Assert.IsNotNull(builder);
            Assert.IsInstanceOfType(builder, typeof(SampleMazeBuilder.SimpleMazeBuilder));
        }
    }
}
