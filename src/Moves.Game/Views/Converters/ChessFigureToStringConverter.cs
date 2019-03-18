using System;
using System.Globalization;
using System.Windows.Data;
using Moves.Engine;

namespace Moves.Game.Views.Converters
{
    public class ChessFigureToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isChessFigure = value is FigureType;
            if (!isChessFigure)
                return Binding.DoNothing;

            var chessFigure = (FigureType)value;
            return chessFigure.Localize();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public static class ChessFigureTypeExtensions
    {
        public static string Localize(this FigureType figure)
        {
            switch (figure)
            {
                case FigureType.Pawn:
                    return "Пешка";

                case FigureType.Rook:
                    return "Ладья";

                case FigureType.Knight:
                    return "Конь";

                case FigureType.Bishop:
                    return "Слон";

                case FigureType.Queen:
                    return "Ферзь";

                case FigureType.King:
                    return "Король";

                default:
                    throw new NotSupportedException("Неизвестный тип фигурыы");
            }
        }
    }
}
