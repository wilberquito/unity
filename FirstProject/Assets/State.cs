using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(1,1)] [SerializeField] string nodeTitle;
    [TextArea(10,12)] [SerializeField] string nodeContent;

    [SerializeField] State[] nextStates;


    public string GetNodeContent()
    {
        return nodeContent;
    }

    public string GetNodeTitle()
    {
        return nodeTitle;
    }


    public State[] GetNextStates()
    {
        return this.nextStates;
    }

   
}
