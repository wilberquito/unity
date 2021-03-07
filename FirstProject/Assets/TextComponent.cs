using System;
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

    int nQuestions;

    List<Tuple<int, bool>> questions;



    // Start is called before the first frame update
    void Start()
    {
        OnStart();
    }

    void OnStart()
    {
        currentState = firstState;

        nodeTitle.text = currentState.GetNodeTitle();

        nodeContent.text = currentState.GetNodeContent();

        questions = new List<Tuple<int, bool>>();
        nQuestions = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // supongamos que es un juego que tiene siempre 4 preguntas
        // en caso de que estemos delante de un node de tipo pregunta

        // miro si el input es de tipo estado normal
        // o por el contrario si es un nodo de tipo pregunta

        if (currentState == firstState)
        {
            OnStart();
        }

        if (currentState.GetType() == typeof(QuestionState))
        {
            int answer = PickAnswer();

            if (answer != -1)
            {
                QuestionState question = Instantiate(currentState) as QuestionState;

                if (question.GetSolution() == answer)
                {
                    questions.Add(new Tuple<int, bool>(nQuestions + 1, true));
                }
                else
                {
                    questions.Add(new Tuple<int, bool>(nQuestions + 1, false));
                }

                nQuestions = questions.Count;

                // pasamos al siguiente nodo
                State[] branches = currentState.GetNextStates();
                currentState = branches[0];
            }

        }
        else
        {

            if (currentState.GetType() == typeof(StatisticsState))
            {
                StatisticsState stadistics = Instantiate(currentState) as StatisticsState;
                string content = stadistics.RunStatistics(questions);
                nodeContent.text = content;
            }

            PickBranch();
        }


        if (currentState.GetType() != typeof(StatisticsState))
        {
            nodeContent.text = currentState.GetNodeContent();
        }

        nodeTitle.text = currentState.GetNodeTitle();

    }

    // devuelve un valor entre (1-4)
    int PickAnswer()
    {
        int picks = 4;

        for (int i = 0; i < picks; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                Debug.Log($"Pick {i + 1} selected");

                return (i + 1);
            }
        }

        return -1;
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
