using Moq;
using Moves.Game.ViewModels;
using NUnit.Framework;
using System;
using System.Linq;
using Moves.Engine;

namespace Moves.Game.Tests
{
    [TestFixture]
    public class NewGameViewModelTest
    {
        private IPlayerViewModelFactory _playerViewModelFactory;

        [SetUp]
        public void Setup()
        {
            var mockPlayerViewModelFactory = new Mock<IPlayerViewModelFactory>();
            mockPlayerViewModelFactory
                .Setup(x => x.CreatePlayer(It.IsAny<FigureColor>()))
                .Returns(() =>
                {
                    return new PlayerViewModel();
                });

            _playerViewModelFactory = mockPlayerViewModelFactory.Object;
        }

        /// <summary>
        /// Должен инициализировать список фигур
        /// </summary>
        [Test]
        public void ShouldInitializeWithAllFiguresSet()
        {
            // Given
            var expectedChessFigures = Enum.GetValues(typeof(FigureType)).Cast<FigureType>().ToArray();

            // When
            var newGameViewModel = new NewGameViewModel(_playerViewModelFactory);
            newGameViewModel.Initialize();

            // Then
            var actualChessFigures = newGameViewModel.Figures.ToArray();
            Assert.IsTrue(expectedChessFigures.SequenceEqual(actualChessFigures));
        }

        /// <summary>
        /// Должен дать фигуру 1 и 2 игроку
        /// </summary>
        [TestCase(FigureType.Pawn)]
        [TestCase(FigureType.Rook)]
        [TestCase(FigureType.Knight)]
        [TestCase(FigureType.Bishop)]
        [TestCase(FigureType.Queen)]
        [TestCase(FigureType.King)]
        public void ShouldGiveFigureTo1Player(FigureType expectedFigure)
        {
            // Given
            var newGameViewModel = new NewGameViewModel(_playerViewModelFactory);
            newGameViewModel.Initialize();
            newGameViewModel.SelectedFigure = expectedFigure;

            // When
            newGameViewModel.GiveFigureToPlayer1Command.Execute();
            newGameViewModel.GiveFigureToPlayer2Command.Execute();

            // Then
            Assert.IsTrue(newGameViewModel.Player1.Figures.Last() == expectedFigure);
            Assert.IsTrue(newGameViewModel.Player2.Figures.Last() == expectedFigure);
        }


        /// <summary>
        /// Должен дать набор фигур по умолчанию
        /// </summary>
        [Test]
        public void ShouldGiveDefaultSetOfFigures()
        {
            // Given
            var newGameViewModel = new NewGameViewModel(_playerViewModelFactory);
            newGameViewModel.Initialize();

            // When
            newGameViewModel.GiveDefaultFigureSetCommand.Execute();

            var expectedFigureSet = new[]
            {
                FigureType.Pawn,
                FigureType.Pawn,
                FigureType.Pawn,
                FigureType.Pawn,
                FigureType.Pawn,
                FigureType.Pawn,
                FigureType.Pawn,
                FigureType.Pawn,
                FigureType.Rook,
                FigureType.Rook,
                FigureType.Knight,
                FigureType.Knight,
                FigureType.Bishop,
                FigureType.Bishop,
                FigureType.King,
                FigureType.Queen
            };

            // Then
            var player1ActualFigures = newGameViewModel.Player1.Figures.OrderBy(x => x).ToArray();
            Assert.IsTrue(player1ActualFigures.SequenceEqual(expectedFigureSet));
            var player2ActualFigures = newGameViewModel.Player2.Figures.OrderBy(x => x);
            Assert.IsTrue(player2ActualFigures.SequenceEqual(expectedFigureSet));
        }
    }
}
