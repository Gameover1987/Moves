using System;

namespace Moves.Engine.Figures
{
    public class Position
    {
        private readonly string _positionStr;
        private const int UtfBegin = 64;

        public Position(int column, int row)
        {
            var letter = Char.ConvertFromUtf32(column + UtfBegin);
            _positionStr = letter + row.ToString();
            FromString(_positionStr);
        }

        public Position(string positionStr)
        {
            _positionStr = positionStr;

            FromString(positionStr);
        }

        public int Column { get; set; }

        public int Row { get; set; }

        public string PositionStr => _positionStr;

        public override string ToString()
        {
            return _positionStr;
        }

        public override bool Equals(object obj)
        {
            var position = obj as Position;
            if (position == null)
                return false;

            return Column == position.Column &&
                   Row == position.Row;
        }

        public override int GetHashCode()
        {
            return PositionStr.GetHashCode();
        }

        private void FromString(string positionStr)
        {
            var letter = positionStr[0];
            var digits = positionStr.Substring(1);

            Column = Char.ConvertToUtf32(letter.ToString(), 0) - UtfBegin;
            Row = Int32.Parse(digits);
        }
    }
}