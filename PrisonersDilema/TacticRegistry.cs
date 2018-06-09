using System;
using System.Collections.Generic;

namespace PrisonersDilema
{
    /// <summary>
    /// Tactic registry.
    /// </summary>
    public class TacticRegistry
    {
        public List<Type> Tactics;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PrisonersDilema.TacticRegistry"/> class.
        /// </summary>
        public TacticRegistry() {
            Tactics = new List<Type>();
            RegisterDefaults();
        }

        /// <summary>
        /// Registers a tactic.
        /// </summary>
        /// <param name="tactic">Tactic.</param>
		void RegisterTactic(Type tactic)
		{
			Tactics.Add(tactic);
		}

        /// <summary>
        /// Registers the default tactics.
        /// </summary>
        void RegisterDefaults() {
            RegisterTactic(typeof(Tactics.Nice));
            RegisterTactic(typeof(Tactics.Mean));
            RegisterTactic(typeof(Tactics.TitTat));
            RegisterTactic(typeof(Tactics.AggressiveTitTat));
            RegisterTactic(typeof(Tactics.Random));
            RegisterTactic(typeof(Tactics.FlipFlop));
            RegisterTactic(typeof(Tactics.GrimThreat));
            RegisterTactic(typeof(Tactics.EarlyBetrayal));
            RegisterTactic(typeof(Tactics.FinalBetrayal));
            RegisterTactic(typeof(Tactics.OccasionalForgiveness));
            RegisterTactic(typeof(Tactics.MikesBetrayal));
        }
    }
}
