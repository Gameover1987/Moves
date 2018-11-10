using Moves.Engine.Figures;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Moves.UI.Windows.Converters
{
    public class ChessFigureToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var chessFigure = (ChessFigureType)value;
            switch (chessFigure)
            {
                case ChessFigureType.Pawn:
                    return "Пешка";

                case ChessFigureType.Rook:
                    return "Ладья";

                case ChessFigureType.Knight:
                    return "Конь";

                case ChessFigureType.Bishop:
                    return "Слон";

                case ChessFigureType.Queen:
                    return "Ферзь";

                case ChessFigureType.King:
                    return "Король";

                default:
                    throw new NotSupportedException("Неизвестный тип фигурыы");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
