using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mazes.Core;

namespace OurIncredibleMazeSolver
{
    public class OurIncredibleMazeSolver : IMazeSolver
    {
        /// <summary>
        /// la case initiale du solver est notre 0,0
        /// </summary>
        private MazeNode currentNode = new MazeNode(new Tuple<int, int>(0,0));
        
        /// <summary>
        /// La direction et le sens initiaux de la souris représente notre 'droite' de référence dans notre cadre droite - gauche - haut - bas
        /// </summary>
        private Directions mouseFacing = Directions.Right;
        
        /// <summary>
        /// une pile des mouvements effectués par la souris
        /// on dépile lorsque l'on revient en arrière
        /// </summary>
        private Stack<Directions> movesStack = new Stack<Directions>();

        private List<Tuple<int, int>> visitedCoordinates = new List<Tuple<int, int>>();

        private Dictionary<Tuple<int, int>, MazeNode> createdNodes = new Dictionary<Tuple<int, int>, MazeNode>();

        public IMaze Maze { get; private set; }

        public IMouse Mouse { get; private set; }

        public List<Tuple<int, int>> VisitedCoordinates
        {
            get
            {
                return new List<Tuple<int, int>>(visitedCoordinates);
            }
            private set
            {
                visitedCoordinates = value;
            }
        }

        public Dictionary<Tuple<int, int>, MazeNode> CreatedNodes
        {
            get
            {
                return new Dictionary<Tuple<int, int>, MazeNode>(createdNodes);
            }
            private set
            {
                createdNodes = value;
            }
        }

        void IMazeSolver.Init(IMaze maze, IMouse mouse)
        {
            this.Maze = maze;
            this.Mouse = mouse;
        }

        void IMazeSolver.YouLoose()
        {
        }

        void IMazeSolver.YouWin()
        {
        }

        void IMazeSolver.YourTurn()
        {

            var newlyDiscoveredNodes = this.currentNode.InitSiblings(this);
            if (newlyDiscoveredNodes.Count > 0)
            {
                foreach (var node in newlyDiscoveredNodes)
                {
                    createdNodes.Add(node.Key, node);
                }
            }

            if (!VisitedCoordinates.Contains(currentNode.Key))
            {
                visitedCoordinates.Add(currentNode.Key);
            }
            KeyValuePair<Directions, MazeNode>? availableSibling = null;
            if (movesStack.Count == 0)
            {
                availableSibling = currentNode.GetFirstAvailableLocation();
            }
            else
            {
                availableSibling = currentNode.GetFirstAvailableLocationExcludingOrigin(GetOppositeDirection(movesStack.Peek()), this);
            }
            if (availableSibling.HasValue)
            {
                currentNode = availableSibling.Value.Value;
                TurnMouseTowardDirection(availableSibling.Value.Key);
                movesStack.Push(availableSibling.Value.Key);
                Mouse.Move();
            }
            else if (movesStack.Count != 0)
            {
                var lastMove = movesStack.Pop();
                var moveBack = GetOppositeDirection(lastMove);
                var target = currentNode.GetSibling(moveBack);
                currentNode.RemoveSibling(moveBack);
                target.RemoveSibling(lastMove);
                currentNode = target;
                TurnMouseTowardDirection(moveBack);
                Mouse.Move();
            }

        }

        /// <summary>
        /// un helper, permettant de tourner la souris dans n'importe quelle direction
        /// la souris n'ayant que les méthodes TurnLeft et TurnRight, c'est ce helper qui permet de créer une référence spatiale
        /// </summary>
        /// <param name="direction"></param>
        public void TurnMouseTowardDirection(Directions direction) {
            switch (direction)
            {
                case Directions.Left:
                    this.TurnMouseTowardLeft();
                    break;
                case Directions.Right:
                    this.TurnMouseTowardRight();
                    break;
                case Directions.Up:
                    this.TurnMouseTowardUp();
                    break;
                case Directions.Down:
                    this.TurnMouseTowardDown();
                    break;
            }
        }

        public Directions GetOppositeDirection(Directions direction) {
            switch (direction)
            {
                case Directions.Left:
                    return Directions.Right;
                case Directions.Right:
                    return Directions.Left;
                case Directions.Up:
                    return Directions.Down;
                case Directions.Down:
                    return Directions.Up;
            }
            return direction;
        }

        private void TurnMouseTowardRight() { 
            switch (this.mouseFacing) {
                case Directions.Right:
                    break;
                case Directions.Left:
                    this.Mouse.TurnRight();
                    this.Mouse.TurnRight();
                    this.mouseFacing = Directions.Right;
                    break;
                case Directions.Up:
                    this.Mouse.TurnRight();
                    this.mouseFacing = Directions.Right;
                    break;
                case Directions.Down:
                    this.Mouse.TurnLeft();
                    this.mouseFacing = Directions.Right;
                    break;
            }
        }

        private void TurnMouseTowardLeft()
        {
            switch (this.mouseFacing)
            {
                case Directions.Right:
                    this.Mouse.TurnRight();
                    this.Mouse.TurnRight();
                    this.mouseFacing = Directions.Left;
                    break;
                case Directions.Left:                    
                    break;
                case Directions.Up:
                    this.Mouse.TurnLeft();
                    this.mouseFacing = Directions.Left;
                    break;
                case Directions.Down:
                    this.Mouse.TurnRight();
                    this.mouseFacing = Directions.Left;
                    break;
            }
        }
        private void TurnMouseTowardUp()
        {
            switch (this.mouseFacing)
            {
                case Directions.Right:
                    this.Mouse.TurnLeft();
                    this.mouseFacing = Directions.Up;
                    break;
                case Directions.Left:
                    this.Mouse.TurnRight();
                    this.mouseFacing = Directions.Up;
                    break;
                case Directions.Up:
                    break;
                case Directions.Down:
                    this.Mouse.TurnRight();
                    this.Mouse.TurnRight();
                    this.mouseFacing = Directions.Up;
                    break;
            }
        }
        private void TurnMouseTowardDown()
        {
            switch (this.mouseFacing)
            {
                case Directions.Right:
                    this.Mouse.TurnRight();
                    this.mouseFacing = Directions.Down;
                    break;
                case Directions.Left:
                    this.Mouse.TurnLeft();
                    this.mouseFacing = Directions.Down;
                    break;
                case Directions.Up:
                    this.Mouse.TurnRight();
                    this.Mouse.TurnRight();
                    this.mouseFacing = Directions.Down;
                    break;
                case Directions.Down:                    
                    break;
            }
        }
    }

    /// <summary>
    /// Les quatre directions dans lesquelles il est possible d'aller
    /// Puisqu'il faut un point de référence pour que tout fonctionne, la droite est définie comme la direction vers laquelle la souris est initialement tournée
    /// </summary>
    public enum Directions { 
        Left=0,
        Right=1,
        Up=2,
        Down=3
    }

    /// <summary>
    /// représente une case du labyrinthe
    /// une case référence les cases accessibles qui l'entourent
    /// l'initialisation d'une case consiste à créer les cases accessibles depuis cettte case, à les référencer sur cette case, et à référencer cette case dans les cases créées
    /// Une case comporte une clef correspondant à sa position dans le labyrinthe
    /// Cette clef est utilisée pour vérifier si l'on est déjà passé par une case en provenance d'un autre chemin
    /// </summary>
    public class MazeNode
    {
        /// <summary>
        /// les quatres cases adjacentes potentielles 
        /// </summary>
        private Dictionary<Directions, MazeNode> _siblings = new Dictionary<Directions,MazeNode>();

        /// <summary>
        /// La case a-t-elle déjà été initialisée
        /// </summary>
        public bool IsInit { get; private set; }

        /// <summary>
        /// La clef, qui représente la position de la case dans le labyrinthe
        /// le premier int est la position de la case sur l'axe gauche - droite, le second la position sur l'axe haut- bas
        /// </summary>
        public Tuple<int, int> Key {get; private set;}        

        public MazeNode(Tuple<int, int> key) {
            this.Key = key;
        }

        /// <summary>
        /// initialise les cases adjacentes accessibles
        /// l'initialisation d'une case consiste à créer les cases accessibles depuis cettte case, à les référencer sur cette case, et à référencer cette case dans les cases créées
        /// </summary>
        public List<MazeNode> InitSiblings(OurIncredibleMazeSolver solver)
        {

            List<MazeNode> createdSiblings = new List<MazeNode>();

            foreach (Directions direction in Enum.GetValues(typeof(Direction))) {
                var createdSibling = InitSibling(direction, solver);
                if (createdSibling != null) {
                    createdSiblings.Add(createdSibling);
                }
            }
            this.IsInit = true;
            return createdSiblings;
            
        }

        public void SetSibling(MazeNode sibling, Directions direction){
            this._siblings[direction] = sibling;
        }

        public void RemoveSibling(Directions direction)
        {
            this._siblings.Remove(direction);
        }

        public MazeNode GetSibling(Directions direction)
        {
            return this._siblings[direction];
        }

        public KeyValuePair<Directions, MazeNode>? GetFirstAvailableLocationExcludingOrigin(Directions origin, OurIncredibleMazeSolver solver)
        {
            KeyValuePair<Directions, MazeNode>? result = null;
            foreach (Directions direction in Enum.GetValues(typeof(Direction))) {
                if(direction != origin && this._siblings.ContainsKey(direction)){
                    var potentialSibling = this._siblings[direction];
                    if (!solver.VisitedCoordinates.Any(x => x.Item1 == potentialSibling.Key.Item1 && x.Item2 == potentialSibling.Key.Item2))
                    {
                        return new KeyValuePair<Directions, MazeNode>?(new KeyValuePair<Directions, MazeNode>(direction, this._siblings[direction]));
                    }
                    else {
                        RemoveSibling(direction);
                    }
                }
            }
            return result;
        }

        public KeyValuePair<Directions, MazeNode>? GetFirstAvailableLocation()
        {
            KeyValuePair<Directions, MazeNode>? result = null;
            foreach (Directions direction in Enum.GetValues(typeof(Direction)))
            {
                if (this._siblings.ContainsKey(direction))
                {
                    return new KeyValuePair<Directions, MazeNode>?(new KeyValuePair < Directions, MazeNode > (direction, this._siblings[direction]));
                }
            }
            return result;
        }

        private MazeNode InitSibling(Directions direction, OurIncredibleMazeSolver solver)
        {
            MazeNode createdSibling = null;
            if (!this.IsInit)
            {   
                //si le sibling existe déjà, on se trouve actuellement sur une case que l'on a généré sans y être passé et le lien a été créé entre le sibling et cette case
                //on ne l'écrase pas
                if (!this._siblings.ContainsKey(direction))
                {
                    //la clef qu'aura le sibling, calculée par rapport à cette case
                    var potentialKey = GetKeyForSibling(direction);
                    solver.TurnMouseTowardDirection(direction);
                    //bien sûr, pas de lien si on a un mur
                    if(solver.Maze.CanIMove()){
                        //si la clef se trouve dans la liste des cases visitées, on ne la génère pas comme case accessible
                        //en effet, cela signifie que le chemin emprunté tourne en rond.
                        //en ne la référençant pas ici, on simule la création d'un mur sur cette case depuis la case courante
                        //seul un retour arrière éventuel permettra de revenir dessus
                        if (!solver.VisitedCoordinates.Any(x => x.Item1 == potentialKey.Item1 && x.Item2 == potentialKey.Item2))
                        {
                        
                            //si la case a déjà été générée depuis une autre de ses cases adjacentes, on se contente de la récupérer et de faire le lien
                            if (solver.CreatedNodes.Keys.Any(x => x.Item1 == potentialKey.Item1 && x.Item2 == potentialKey.Item2))
                            {
                                var existingNode = solver.CreatedNodes[potentialKey];
                                this.SetSibling(existingNode, direction);
                                existingNode.SetSibling(this, solver.GetOppositeDirection(direction));
                            }
                            else {
                                var newNode = new MazeNode(potentialKey);
                                this.SetSibling(newNode, direction);
                                newNode.SetSibling(this, solver.GetOppositeDirection(direction));
                                createdSibling = newNode;
                            }
                        }
                    }
                }
            }
            return createdSibling;
        }

        //calcule la clef que devrait avoir le sibling positionné dans une direction donnée
        //cette clef est un tuple qui représente une position dans le labyrinthe
        //le premier int est la position sur l'axe gauche - droite, le second la position sur l'axe haut- bas
        private Tuple<int, int> GetKeyForSibling(Directions direction){
            Tuple<int, int> result = null;
            switch (direction)
            {
                case Directions.Left:
                    result = new Tuple<int, int>(this.Key.Item1 - 1, this.Key.Item2);
                    break;
                case Directions.Right:
                    result = new Tuple<int, int>(this.Key.Item1 + 1, this.Key.Item2);
                    break;
                case Directions.Up:
                    result = new Tuple<int, int>(this.Key.Item1, this.Key.Item2 + 1);
                    break;
                case Directions.Down:
                    result = new Tuple<int, int>(this.Key.Item1, this.Key.Item2 - 1);
                    break;
            }
            return result;
        }
    }
}
