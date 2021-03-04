using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QuestionState")]
public class QuestionState : State
{

    [TextArea(1, 1)] [SerializeField] string solution;


    public int GetSolution()
    {
        return int.Parse(solution);
    }
}
