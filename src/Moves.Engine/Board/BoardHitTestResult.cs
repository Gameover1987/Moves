using Moves.Engine.Figures;

namespace Moves.Engine.Board
{
    public class BoardHitTestResult
    {
        /// <summary>
        /// Фигура для которой производилась проверка
        /// </summary>
        public IFigure ResultFor { get; set; }

        /// <summary>
        /// Атакующие фигуры
        /// </summary>
        public IFigure[] AttackingFigures { get; set; }

        /// <summary>
        /// Атакованные фигруы
        /// </summary>
        public IFigure[] AttackedFigures { get; set; }

        public bool IsFree
        {
            get { return AttackingFigures.Length == 0 && AttackedFigures.Length == 0; }
        }
    }
}