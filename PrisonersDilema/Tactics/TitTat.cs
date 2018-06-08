using System;
using System.Collections.Generic;
using System.Linq;

namespace PrisonersDilema.Tactics {
    /// <summary>
    /// Tit for tat will start off silent and then will copy the opponents previous move.
    /// </summary>
    public class TitTat : ITactic
    {
        public string Name { get { return "Tit for Tat"; } }
        public Move GetNextMove(int totalMoves, List<Move> ownLast, List<Move> opponentsMoves) {
            if (opponentsMoves.Last() == Move.Betray) {
                return Move.Betray;
            } else if (opponentsMoves.Last() == Move.Silent) {
                return Move.Silent;
            } else {
                return Move.Silent;
            }
        }
    }
}
