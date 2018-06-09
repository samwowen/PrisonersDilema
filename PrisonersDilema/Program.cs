using System;
using System.Collections.Generic;
using System.Linq;

namespace PrisonersDilema {
    class MainClass
    {
        public static void Main(string[] args) {
            var tactics = new TacticRegistry();
            var noTactics = tactics.Tactics.Count;
            var scoreMatrix = new int[noTactics, noTactics];
            int fights = 1000; // Change this number to change how many times they fight each other

            // Do battle
            for (int i = 0; i < noTactics; i++) {
                var t1 = tactics.Tactics[i];
                var p1 = (ITactic)Activator.CreateInstance(t1);
                var score = 0;
                var opp = new TacticRegistry();

                for (int j = 0; j < noTactics; j++) {
                    var t2 = tactics.Tactics[j];
                    var p2 = (ITactic)Activator.CreateInstance(t2);
                    var battle = new Battle(p1, p2);
                    //battle.debug = true;
                    var res = battle.Fight(fights); 
                    scoreMatrix[j, i] = res.P1Total;
                    score += res.P1Total;
                }
            }

			printl("");

            // Print score matrix
            var results = new Dictionary<string, int>();
            for (int i = 0; i < noTactics; i++) {
                var spaces = "";
                var name = tactics.Tactics[i].Name;

                for (int s = 0; s < 22 - name.Length; s++) {
                    spaces = spaces + " ";
                }

                print(tactics.Tactics[i].Name + spaces);
                var score = 0;
                for (int j = 0; j < noTactics; j++) {
                    print(scoreMatrix[j, i].ToString("0000") + " ");
                    score = score + scoreMatrix[j, i];
                }

                printl("  Total: " + score);

                results.Add(name, score);
            }

            printl("");

            // Print results
            List<KeyValuePair<string, int>> orderedResults = results.ToList();
            orderedResults.Sort((a, b) => a.Value.CompareTo(b.Value));

            for (int i = 1; i < noTactics + 1; i++) {
                if (i == 1) {
                    printl(AddOrdinal(i) + ", with an average of " + orderedResults[i - 1].Value / (noTactics) + " years: " + orderedResults[i - 1].Key + "!");
                } else {
                    printl(AddOrdinal(i) + ", with an average of " + orderedResults[i - 1].Value / (noTactics) + " years: " + orderedResults[i - 1].Key);

                }
            }

            Console.ReadKey();
        }

        #region Utilities
        public static void print(object s) {
            Console.Write(s.ToString());
        }

        public static void printl(object s) {
            Console.WriteLine(s.ToString());
        }

        // https://stackoverflow.com/questions/20156/is-there-an-easy-way-to-create-ordinals-in-c
        public static string AddOrdinal(int num) {
            if (num <= 0) return num.ToString();

            switch (num % 100) {
                case 11:
                case 12:
                case 13:
                    return num + "th";
            }

            switch (num % 10) {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }

        }
        #endregion
    }
}
