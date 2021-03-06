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

        if (nCorrect == 0 && nQuestions != 0)
        {
            text += "You are not a nerd!\n\n";
        }
        else
        {
            text += $"You are {nQuestions * 100 / nCorrect}% nerd\n\n";
        }

        text += "Press (1) to restart game";

        return text;
        //SetNodeContent(text);
    }

}
