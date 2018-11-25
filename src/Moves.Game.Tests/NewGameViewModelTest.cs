using Moq;
using Moves.Engine.Figures;
using Moves.Game.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

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
                .Setup(x => x.CreatePlayer())
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
            var expectedChessFigures = Enum.GetValues(typeof(ChessFigureType)).Cast<ChessFigureType>().ToArray();

            // When
            var newGameViewModel = new NewGameViewModel(_playerViewModelFactory);

            // Then
            var actualChessFigures = newGameViewModel.Figures.ToArray();
            Assert.IsTrue(expectedChessFigures.SequenceEqual(actualChessFigures));
        }

        /// <summary>
        /// Должен дать фигуру 1 и 2 игроку
        /// </summary>
        [TestCase(ChessFigureType.Pawn)]
        [TestCase(ChessFigureType.Rook)]
        [TestCase(ChessFigureType.Knight)]
        [TestCase(ChessFigureType.Bishop)]
        [TestCase(ChessFigureType.Queen)]
        [TestCase(ChessFigureType.King)]
        public void ShouldGiveFigureTo1Player(ChessFigureType expectedChessFigure)
        {
            // Given
            var newGameViewModel = new NewGameViewModel(_playerViewModelFactory);
            newGameViewModel.SelectedFigure = expectedChessFigure;

            // When
            newGameViewModel.GiveFigureToPlayer1Command.Execute();
            newGameViewModel.GiveFigureToPlayer2Command.Execute();

            // Then
            Assert.IsTrue(newGameViewModel.Player1.Figures.Last() == expectedChessFigure);
            Assert.IsTrue(newGameViewModel.Player2.Figures.Last() == expectedChessFigure);
        }


        /// <summary>
        /// Должен дать набор фигур по умолчанию
        /// </summary>
        [Test]
        public void ShouldGiveDefaultSetOfFigures()
        {
            // Given
            var newGameViewModel = new NewGameViewModel(_playerViewModelFactory);

            // When
            newGameViewModel.GiveDefaultFigureSetCommand.Execute();

            var expectedFigureSet = new[]
            {
                ChessFigureType.Pawn,
                ChessFigureType.Pawn,
                ChessFigureType.Pawn,
                ChessFigureType.Pawn,
                ChessFigureType.Pawn,
                ChessFigureType.Pawn,
                ChessFigureType.Pawn,
                ChessFigureType.Pawn,
                ChessFigureType.Rook,
                ChessFigureType.Rook,
                ChessFigureType.Knight,
                ChessFigureType.Knight,
                ChessFigureType.Bishop,
                ChessFigureType.Bishop,
                ChessFigureType.King,
                ChessFigureType.Queen
            };

            // Then
            var player1ActualFigures = newGameViewModel.Player1.Figures.OrderBy(x => x).ToArray();
            Assert.IsTrue(player1ActualFigures.SequenceEqual(expectedFigureSet));
            var player2ActualFigures = newGameViewModel.Player2.Figures.OrderBy(x => x);
            Assert.IsTrue(player2ActualFigures.SequenceEqual(expectedFigureSet));
        }

        public void Check(ChessFigureType[] figures1, ChessFigureType[] figures2)
        {
            if (figures1.Length != figures2.Length)
                return ;

            for (int i = 0; i < figures1.Count(); i++)
            {
                Assert.IsTrue(figures1[i] == figures2[i]);
            }
        }

    }
}
