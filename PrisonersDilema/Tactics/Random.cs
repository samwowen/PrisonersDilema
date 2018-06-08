using System;
using System.Collections.Generic;

namespace PrisonersDilema.Tactics {
    /// <summary>
    /// Random.
    /// </summary>
    public class Random : ITactic
    {
        public Random() {
            max = 2;
        }
        public Random(int maxValue) {
            max = maxValue;
        }
		public string Name { get { return "Random"; } }

        int max;
        System.Random r = new System.Random(DateTime.Now.Millisecond);

        public Move GetNextMove(int totalMoves, List<Move> ownLast, List<Move> opponentsLast) {
            return r.Next(0, max) == 0 ? Move.Silent : Move.Betray;
        }
    }
}
