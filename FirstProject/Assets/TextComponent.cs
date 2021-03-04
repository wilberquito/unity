using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextComponent : MonoBehaviour
{

    [SerializeField] Text nodeTitle;
    [SerializeField] Text nodeContent;
    [SerializeField] State firstState;

    State currentState;


    // Start is called before the first frame update
    void Start()
    {

        currentState = firstState;

        nodeTitle.text = currentState.GetNodeTitle();

        nodeContent.text = currentState.GetNodeContent();

        Debug.Log("Running...");

    }

    // Update is called once per frame
    void Update()
    {
        // supongamos que es un juego que tiene siempre 4 preguntas
        // en caso de que estemos delante de un node de tipo pregunta

        // miro si el input es de tipo estado normal
        // o por el contrario si es un nodo de tipo pregunta

        if (currentState.GetType() == typeof(QuestionState))
        {
            PickAnswer();
        }
        else
        {
            PickBranch();
        }

        nodeTitle.text = currentState.GetNodeTitle();

        nodeContent.text = currentState.GetNodeContent();
    }

    void PickAnswer()
    {
        int picks = 4;

        for (int i = 0; i < picks; i++)
        {

            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                Debug.Log($"Pick {i + 1} selected");

                // paso directamente al proximo nodo
                State[] branches = currentState.GetNextStates();
                currentState = branches[0];
            }
        }
    }

    // esta función cogerá siempre la primera rama
    // ya que el juego es lineal
    void PickBranch()
    {
        State[] branches = currentState.GetNextStates();

        for (int i = 0; i < branches.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                currentState = branches[i];
            }
        }


    }
}
