using System;
using System.Collections.Generic;
using System.Linq;

namespace PrisonersDilema.Tactics
{
    /// <summary>
    /// Mikes betrayal. Betrays if the opponent has betrayed more that they've stayed silent.
    /// </summary>
    /// <remarks>
    /// Author: Mike Sarvo
    /// </remarks>
    public class MikesBetrayal : ITactic
    {
        public string Name { get { return "MikesBetrayal"; } }
        public Move GetNextMove(int totalMoves, List<Move> ownLast, List<Move> opponentsLast) {
            var b = opponentsLast.Where(m => m == Move.Betray).Count();
            var s = opponentsLast.Count - b;

            return s < b ? Move.Betray : Move.Silent;
        }
    }
}
