using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayLogic : MonoBehaviour
{

    [SerializeField] int minor;
    [SerializeField] int major;
    [SerializeField] TextMeshProUGUI guess;

    int nGuess;

    // Start is called before the first frame update
    void Start()
    {

        nGuess = ComputeGuess(minor, major);

        PrintState();
    }


    // Update is called once per frame
    void Update()
    {

    }

    void PrintState()
    {
        Debug.Log($"minor: {minor}");
        Debug.Log($"major: {major}");
        Debug.Log($"guess: {nGuess}");

        guess.SetText(nGuess.ToString());
    }

    public void OnClickMajor()
    {
        nGuess = ComputeGuess(nGuess, major);

        PrintState();
    }

    public void OnClickMinor()
    {
        nGuess = ComputeGuess(minor, nGuess);

        PrintState();
    }


    int ComputeGuess(int minor, int major)
    {
        return Random.Range(minor, major + 1);
    }


}
