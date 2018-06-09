using System;

namespace PrisonersDilema
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var tactics = new TacticRegistry();
            var noTactics = tactics.Tactics.Count;
            var scoreMatrix = new int[noTactics, noTactics];

            // Do battle
            for (int i = 0; i < noTactics; i++)
            {
                var t1 = tactics.Tactics[i];
                var p1 = (ITactic)Activator.CreateInstance(t1);
                var score = 0;
                var opp = new TacticRegistry();

                for (int j = 0; j < noTactics; j++)
                {
                    var t2 = tactics.Tactics[j];
                    var p2 = (ITactic)Activator.CreateInstance(t2);
                    var battle = new Battle(p1, p2);
                    //battle.debug = true;
                    var res = battle.Fight(1000); // Change this number to change how many times they fight each other
                    scoreMatrix[j, i] = res.P1Total;
                    score += res.P1Total;
                }

                printl(p1.Name + " scored: " + score);
            }

			printl("");

            // Print results
            for (int i = 0; i < noTactics; i++)
            {
                var spaces = "";
                var name = tactics.Tactics[i].Name;

                for (int s = 0; s < 20 - name.Length; s++)
                {
                    spaces = spaces + " ";
                }

                print(tactics.Tactics[i].Name + spaces);
                var score = 0;
                for (int j = 0; j < noTactics; j++)
                {
                    print(scoreMatrix[j, i].ToString("0000") + " ");
                    score = score + scoreMatrix[j, i];
                }

                printl("  Total: " + score);
            }

            Console.ReadKey();
        }

        #region Utilities
        public static void print(object s)
        {
            Console.Write(s.ToString());
        }

        public static void printl(object s)
        {
            Console.WriteLine(s.ToString());
        }
        #endregion
    }
}
