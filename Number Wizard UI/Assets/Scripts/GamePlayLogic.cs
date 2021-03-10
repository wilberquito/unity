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

        major += 1;

        nGuess = ComputeGuess(minor, major);

        PrintState();
    }


    // Update is called once per frame
    void Update()
    {

    }

    void PrintState()
    {
        Debug.Log($"{minor}");
        Debug.Log($"{major}");
        Debug.Log($"{nGuess}");

        guess.SetText(nGuess.ToString());
    }

    public void OnClickMajor()
    {
        minor = nGuess;
        nGuess = ComputeGuess(minor, major);

        PrintState();
    }

    public void OnClickMinor()
    {
        major = nGuess;
        nGuess = ComputeGuess(minor, major);

        PrintState();
    }


    int ComputeGuess(int minor, int major)
    {
        return (minor + major) / 2;
    }


}
