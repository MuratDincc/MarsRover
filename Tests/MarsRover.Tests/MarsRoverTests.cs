using MarsRover.Core;
using MarsRover.Core.Constants;
using MarsRover.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MarsRover.Tests
{
    [TestClass]
    public class MarsRoverTests
    {
        #region Fields

        IPlateau Plateau; 

        #endregion

        #region Ctor

        public MarsRoverTests()
        {
            this.Plateau = new Plateau(new Position(5, 5));
        }

        #endregion

        #region Methods

        [TestMethod]
        public void FirstRover()
        {
            Rover rover = new Rover(Plateau, new Position(1, 2), Direction.N);
            rover.Run("LMLMLMLMM");
            Assert.AreEqual(rover.Current(), "1 3 N");
        }

        [TestMethod]
        public void SecondRover()
        {
            Rover rover = new Rover(Plateau, new Position(3, 3), Direction.E);
            rover.Run("MMRMMRMRRM");
            Assert.AreEqual(rover.Current(), "5 1 E");
        } 

        #endregion
    }
}