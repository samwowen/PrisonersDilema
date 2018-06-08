using System;
using System.Collections.Generic;

namespace PrisonersDilema.Tactics {
    /// <summary>
    /// Mean always betrays.
    /// </summary>
    public class Mean : ITactic
    {
        public string Name { get { return "Mean"; } }
        public Move GetNextMove(int totalMoves, List<Move> ownLast, List<Move> opponentsLast) {
            return Move.Betray;
        }
    }
}
