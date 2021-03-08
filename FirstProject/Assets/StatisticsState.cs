using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "StatisticsState")]
public class StatisticsState : State
{

    public string RunStatistics(List<Tuple<int, bool>> statistics)
    {
        int nQuestions = 0;
        int nCorrect = 0;

        string text = "";

        if (statistics != null)
        {
            statistics.ForEach(tupla =>
            {
                if (tupla.Item2)
                {
                    text += $"{tupla.Item1}. Yes!\n";
                    nCorrect += 1;
                }
                else
                {
                    text += $"{tupla.Item1}. No!\n";
                }
                nQuestions += 1;
            });

            text += "\n";

            if (nCorrect == 0 && nQuestions != 0)
            {
                text += "You fall everything, of course you are not a NeRd!\n\n";
            }
            else if (nQuestions > 0)
            {
                float rating = (float)nCorrect / (float)nQuestions * 100;
                text += $"You are { rating }% nerd\n\n";
            }

        }


        text += "Press (1) to restart game";

        return text;
    }

}
