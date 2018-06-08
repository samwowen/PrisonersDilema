using System.Collections.Generic;
using System.Linq;

namespace PrisonersDilema.Tactics {
    /// <summary>
    /// Early betrayal will stay silent, unless betrayed in the first 10 moves.
    /// </summary>
    public class EarlyBetrayal : ITactic 
    {
        public string Name { get { return "Punish Early Betrayal"; } }

        public Move GetNextMove(int totalMoves, List<Move> ownLast, List<Move> opponentsMoves) {
            if (opponentsMoves.Take(10).Contains(Move.Betray)) {
                return Move.Betray;
            } else {
                return Move.Silent;
            }
        }
    }
}

