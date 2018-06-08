using System;
using System.Collections.Generic;

namespace PrisonersDilema.Tactics {
    /// <summary>
    /// Nice always stays silent.
    /// </summary>
    public class Nice : ITactic
    {
        public string Name { get { return "Nice"; } } 
        public Move GetNextMove(int totalMoves, List<Move> ownLast, List<Move> opponentsLast) {
            return Move.Silent;
		}
    }
}
