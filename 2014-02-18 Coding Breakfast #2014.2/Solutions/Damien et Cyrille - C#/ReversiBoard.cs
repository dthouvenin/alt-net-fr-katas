using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Reversi
{
    public enum Box { Empty, White, Black }
    public struct Position
    {
        public Position(int col, int row)
        {
            Col = col;
            Row = row;
        }
        public int Col;
        public int Row;
    }

    public class ReversiBoard
    {
        private readonly Box[,] _positions = new Box[8, 8];

        public ReversiBoard()
        {
            this[3, 3] = Box.Black;
            this[4, 4] = Box.Black;
            this[3, 4] = Box.White;
            this[4, 3] = Box.White;
        }
        public Box this[int col, int row]
        {
            get { return _positions[col, row]; }
            set { _positions[col, row] = value; }
        }

        public Box this[Position pos]
        {
            get { return _positions[pos.Col, pos.Row]; }
            set { _positions[pos.Col, pos.Row] = value; }
        }

        /// <summary>
        /// Retourne les positions libres autour du point considéré, triées dans l'ordre des aiguille d'une montre, en partant du coin en haut à gauche
        /// </summary>
        /// <param name="col">Colonne</param>
        /// <param name="row">Ligne</param>
        /// <returns></returns>
        public IEnumerable<Position> PotentialPositionsFor(int col, int row)
        {
            return from pos in Neighbours(col, row) where this[pos] == Box.Empty select pos;
        }

        public IEnumerable<Position> ValidPositionsFor(int col, int row)
        {
            var color = this[col, row];
            var results = new List<Position>();
            foreach (var pos in PotentialPositionsFor(col, row).ToList())
            {
                var colOffset = col - pos.Col;
                var rowOffset = row - pos.Row;
                var candidate = new Position(col + colOffset, row + rowOffset);
                while (candidate.Col >= 0 && candidate.Col < 8 && candidate.Row >= 0 && candidate.Row < 8)
                {
                    if (this[candidate] == Box.Empty)
                        break;
                    if (this[candidate] == color)
                        candidate = new Position(candidate.Col + colOffset, candidate.Row + rowOffset);
                    else
                    {
                        results.Add(pos);
                        break;
                    }
                }
            }
            return results;
        }


        public IEnumerable<Position> Neighbours(int col, int row)
        {
            yield return new Position { Col = col - 1, Row = row - 1 };
            yield return new Position { Col = col, Row = row - 1 };
            yield return new Position { Col = col + 1, Row = row - 1 };
            yield return new Position { Col = col + 1, Row = row };
            yield return new Position { Col = col + 1, Row = row + 1 };
            yield return new Position { Col = col, Row = row + 1 };
            yield return new Position { Col = col - 1, Row = row + 1 };
            yield return new Position { Col = col - 1, Row = row };
        }
    }
}
