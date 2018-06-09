using System;
using System.Collections.Generic;
using System.Linq;

namespace PrisonersDilema.Tactics {
    /// <summary>
    /// Plays tit for tat, assuming generosity initially, however after 5 betrayals in a row will 'forgive' and be silent again.
    /// </summary>
    /// <remarks>
    /// Author: Simon Blackwell
    /// </remarks>
    public class OccasionalForgiveness : ITactic
    {
        public string Name { get { return "OccasionalForgiveness"; } }
        public Move GetNextMove(int totalMoves, List<Move> ownLast, List<Move> opponentsMoves) {
            if (ownLast.Count == 1 || (opponentsMoves as IEnumerable<Move>).Reverse().Take(5).All(m => m == Move.Betray)) {
                return Move.Silent;
            }

            return opponentsMoves.LastOrDefault();
        }
    }
}
