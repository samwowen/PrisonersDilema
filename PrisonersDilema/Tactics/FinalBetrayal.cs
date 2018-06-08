using System;
using System.Collections.Generic;
using System.Linq;

namespace PrisonersDilema.Tactics {
    /// <summary>
    /// Final betrayal will stay silent, but betray on the last turn.
    /// </summary>
    public class FinalBetrayal : ITactic
    {
        public string Name { get { return "Final Betrayal"; } }

        public Move GetNextMove(int times, List<Move> ownLast, List<Move> opponentsLast) {
            if (ownLast.Count() == times) {
                return Move.Betray;
            } else {
                return Move.Silent;
            }
        }
    }
}
