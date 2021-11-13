using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GraphicsProgrammingAssignmentTest
{
    [TestClass]
    public class GraphicsProgrammingAssignment
    {
        [TestMethod]
        public void ValidCoordinatesToDrawCircle()
        {
             //Arrange

            //Acts

           //Assert
        }
        public void DrawYellowCircle()
        {
            DrawingTest(Color.Yellow, Shape.Circle);
        }
    }
}