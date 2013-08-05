using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Skyline
{
    #region CUT

    public class Skyliner
    {
        public IEnumerable<Vector> GetSkyline(ICollection<Triplet> triplets)
        {
            if (triplets == null || triplets.Count == 0)
            {
                yield break;
            }

            var begin = triplets.Select(s => s.BeginX).Min(); //On récupère le X le plus petit
            var count = triplets.Select(s => s.EndX).Max(); //On récupère le X le plus grand

            var currentHeight = 0; //On crée une variable permettant de garder en mémoire la hauteur actuelle.

            foreach (var index in Enumerable.Range(begin, count)) //On parcour tous les X
            {
                var highestTriplet = GetHighestTripletAtThisPosition(index, triplets); //Pour chaque X on récupère le plus haut triplet

                if (highestTriplet == null) //S'il n'y a pas de triplet c'est que nous touchons le sol
                {
                    if (currentHeight != 0) //Toujours verifier que la valeur actuelle est différente de celle enregistrer pour ne pas envoyer de doublons
                    {
                        currentHeight = 0;

                        yield return new Vector { Type = VectorType.Horizontal, Value = index }; //On retourne X
                        yield return new Vector { Type = VectorType.Vertical, Value = currentHeight }; //On retourne Y
                    }

                    continue;
                }
                else if (highestTriplet.Height != currentHeight)//Toujours verifier que la valeur actuelle est différente de celle enregistrer pour ne pas envoyer de doublons
                {
                    currentHeight = highestTriplet.Height;

                    yield return new Vector { Type = VectorType.Horizontal, Value = index }; //On retourne X
                    yield return new Vector { Type = VectorType.Vertical, Value = currentHeight }; //On retourne Y
                }
            }
        }

        internal Triplet GetHighestTripletAtThisPosition(int position, ICollection<Triplet> triplets)
        {
            var tripletsInRange = triplets.Where(s => s.BeginX <= position && s.EndX > position) //On récupère les différents triplets à la position fournie
                                          .ToArray();

            if (tripletsInRange.Length == 0) //On teste si il éxiste des resultats
            {
                return null;
            }

            var maxHeight = tripletsInRange.Select(s => s.Height).Max(); //On determine la hauteur maximum

            return tripletsInRange.Where(s => s.Height == maxHeight).First(); // On retourne le triplet le plus haut
        }
    }

    #endregion CUT

    #region Tests

    public class SkylinerTests
    {
        [Fact]
        public void GetSkylineTest()
        {
            var skyliner = new Skyliner();
            var triplets = new List<Triplet>
            {
                new Triplet{BeginX = 1, Height = 11, EndX=5},
                new Triplet{BeginX = 2, Height = 6, EndX=7},
                new Triplet{BeginX = 3, Height = 13, EndX=9},
                new Triplet{BeginX = 12, Height = 7, EndX=16},
                new Triplet{BeginX = 14, Height = 3, EndX=25},
                new Triplet{BeginX = 19, Height = 18, EndX=22},
                new Triplet{BeginX = 23, Height = 13, EndX=29},
                new Triplet{BeginX = 24, Height = 4, EndX=28},
            };

            var skylineSt = skyliner.GetSkyline(triplets).Select(s => s.Value.ToString()).Aggregate((s, p) => s + " " + p);

            Assert.Equal("1 11 3 13 9 0 12 7 16 3 19 18 22 3 23 13 29 0", skylineSt);
        }
    }

    #endregion Tests

    #region Model

    public class Triplet
    {
        public int BeginX { get; set; }

        public int Height { get; set; }

        public int EndX { get; set; }
    }

    public enum VectorType
    {
        Horizontal,
        Vertical
    }

    public class Vector
    {
        public int Value { get; set; }

        public VectorType Type { get; set; }
    }

    #endregion Model
}