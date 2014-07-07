namespace EtudiantSolver
{
    public class RelativePosition
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="T:System.Object" />.
        /// </summary>
        public RelativePosition(Position position, bool isWall = false)
        {
            Position = position;
            IsWall = isWall;
        }

        public Position Position { get; private set; }
        public bool IsWall { get; set; }
    }
}