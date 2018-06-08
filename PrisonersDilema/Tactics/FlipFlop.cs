using System;
using System.Collections.Generic;
using System.Linq;

namespace PrisonersDilema.Tactics {
    /// <summary>
    /// Flip flop will alternate between silence and betrayal.
    /// </summary>
    public class FlipFlop : ITactic
    {
        public string Name { get { return "Flip Flop"; } }

        public Move GetNextMove(int totalMoves, List<Move> ownLast, List<Move> opponentsLast) {
            return opponentsLast.Count() % 2 == 0 ? Move.Silent : Move.Betray;
        }
    }
}
