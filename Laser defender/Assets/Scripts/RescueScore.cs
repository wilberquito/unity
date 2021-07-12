using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RescueScore : MonoBehaviour
{

    [SerializeField] string textUiName = "Text Score";
    Text textRef;
    void Start()
    {
        var gameScore = FindObjectOfType<GameScore>();

        if (gameScore)
        {
            var score = gameScore.ScoreUntilNow();

            var texts = FindObjectsOfType<Text>();

            var lst = new List<Text>(texts);

            foreach (var text in lst)
            {
                if (text.name == textUiName)
                {
                    textRef = text;
                    break;
                }
            }

            if (textRef)
            {
                var text = ParseToShow(score, 6, '0');
                textRef.text = text;
            }

        }
    }


    private string ParseToShow(int n, int m, char c)
    {
        var padleft = (n.ToString()).PadLeft(10, c);
        var start = padleft.Length - m;
        var ret = padleft.Substring(start, m);

        return ret;
    }

}
