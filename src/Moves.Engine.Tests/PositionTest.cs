using Moves.Engine.Figures;
using NUnit.Framework;

namespace Moves.Engine.Tests
{
    [TestFixture]
    public class PositionTest
    {
        [TestCase("a1", 1, 1)]
        [TestCase("b2", 2, 2)]
        [TestCase("h8", 8, 8)]
        public void ShouldCreatePositionFromString(string positionStr, int expectedColumn, int expectedRow)
        {
            // Given
            // When
            var position = new Position(positionStr);

            // Then
            Assert.AreEqual(position.Column, expectedColumn);
            Assert.AreEqual(position.Row, expectedRow);
        }


        [TestCase(1, 1, "a1")]
        [TestCase(5, 5, "e5")]
        [TestCase(8, 8, "h8")]
        public void ShouldCreatePositionFromInt(int column, int row, string expectedPositionStr)
        {
            // Given
            // When
            var position = new Position(column, row);

            // Then
            Assert.AreEqual(position.PositionStr, expectedPositionStr);
        }
    }
}
