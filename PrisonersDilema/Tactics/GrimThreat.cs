using System;
using System.Collections.Generic;

namespace PrisonersDilema.Tactics {
    /// <summary>
    /// Grim threat will stay silent until betrayed, and then will always betray.
    /// </summary>
    public class GrimThreat : ITactic
    {
        public string Name { get { return "Grim Threat"; } }
        public Move GetNextMove(int totalMoves, List<Move> ownLast, List<Move> opponentsLast) {
            if (opponentsLast.Contains(Move.Betray)) {
                return Move.Betray;
            } else {
                return Move.Silent;
            }
        }
    }
}
