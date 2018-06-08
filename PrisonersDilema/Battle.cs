using System;
using System.Collections.Generic;

namespace PrisonersDilema
{
    /// <summary>
    /// Battle.
    /// </summary>
    public class Battle
    {
        public Battle(ITactic a, ITactic b)
        {
            p1 = a;
            p2 = b;
        }
        ITactic p1;
        ITactic p2;
        public bool debug = false;

        /// <summary>
        /// Fight the specified times.
        /// </summary>
        /// <returns>The fight.</returns>
        /// <param name="times">Times.</param>
        public FightResult Fight(int times) {
            var p1last = new List<Move>() { Move.None };
            var p2last = new List<Move>() { Move.None };
            var p1years = 0;
            var p2years = 0;

            for (int i = 0; i < times; i++) {
                var p1move = p1.GetNextMove(times, p1last, p2last);
                var p2move = p2.GetNextMove(times, p2last, p1last);

                if (p1move == Move.Silent && p2move == Move.Silent) {
                    p1years += 1;
                    p2years += 1;
                    if (debug) Console.WriteLine(p1.Name + " was silent, " + p2.Name + " was silent. Result = Good Draw");
                } else if (p1move == Move.Betray && p2move == Move.Betray) {
                    p1years += 2;
                    p2years += 2;
                    if (debug) Console.WriteLine(p1.Name + " betrayed, " + p2.Name + " betrayed. Result = Bad Draw");
                } else if (p1move == Move.Betray) {
                    p2years += 3;
                    if (debug) Console.WriteLine(p1.Name + " betrayed, " + p2.Name + " was silent. Result = P1 Win");
                } else if (p2move == Move.Betray) {
                    p1years += 3;
                    if (debug) Console.WriteLine(p1.Name + " was silent, " + p2.Name + " betrayed. Result = P2 Win");
                } else {
                    throw new Exception("Shouldn't be  here");
                }

                p1last.Add(p1move);
                p2last.Add(p2move);
            }
            var total = p1years + p2years;

            if (p1years == p2years) return new FightResult(Result.Draw, total, p1years, p2years);

            return p1years < p2years ? new FightResult(Result.P1Win, total, p1years, p2years) : new FightResult(Result.P2Win, total, p1years, p2years);
        }

        /// <summary>
        /// Result.
        /// </summary>
        public enum Result {
            P1Win,
            P2Win,
            Draw
        }

        /// <summary>
        /// Fight result.
        /// </summary>
        public struct FightResult {
            public FightResult(Result r, int i, int p1, int p2) {
                Result = r;
                Total = i;
                P1Total = p1;
                P2Total = p2;
            }
            public Result Result;
            public int Total;
            public int P1Total;
            public int P2Total;
        }
    }
}
