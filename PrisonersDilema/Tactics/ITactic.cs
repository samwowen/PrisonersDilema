using System;
using System.Collections.Generic;

namespace PrisonersDilema {
    /// <summary>
    /// New tactics must implement ITactic.
    /// </summary>
    public interface ITactic
    {
        string Name { get; }
        Move GetNextMove(int totalMoves, List<Move> ownLast, List<Move> opponentsLast);
    }
}
