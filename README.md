# Prisoners Dilema

This is a simple implementation of the prisoners dilemma. Tactics play against each other to decide a victor. In each 'battle' two tactics play the prisoners dilemma many times against each other. Both have a choice each round, they can stay silent or betray their opponent.
If tactic one betrays and tactic two stays silent, tactic one walks free and tactic two gets three years in prison, and visa versa.
If both tactics stay silent, they both only get one year.
If they both betray each other, they get 2 years each.
Obviously the goal for each tactic is to minimise the time spent in prison.
All tactics play each other, and the one with the lowest score (fewest years in prison) at the end wins.
To make it interesting, a tactic knows three things: The number of times they will 'battle' each other tactic, all of their own previous moves, and all of the opponents previous moves.

## Creating a new tactic

A new tactic can be created by creating a new class in the Tactics folder that implements ITactic, and then registering it in the TacticRegistry. See the Nice and Mean tactics for the simplest implementation.