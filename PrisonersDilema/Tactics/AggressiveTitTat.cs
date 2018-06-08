using System;
using System.Collections.Generic;
using System.Linq;

namespace PrisonersDilema.Tactics {
    /// <summary>
    /// Aggressive tit for tat will start off with a betrayal, and will then copy the opponents previous move.
    /// </summary>
    public class AggressiveTitTat : ITactic
    {
        public string Name { get { return "Aggressive Tit for Tat"; } }

        public Move GetNextMove(int totalMoves, List<Move> ownLast, List<Move> opponentsMoves) {
            if (opponentsMoves.Last() == Move.Betray) {
                return Move.Betray;
            } else if (opponentsMoves.Last() == Move.Silent) {
                return Move.Silent;
            } else {
                return Move.Betray;
            }
        }
    }
}