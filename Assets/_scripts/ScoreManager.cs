using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    // Going to use static variables 
    // Can be accessed by anything
    public static int score;

    Text text;

    void Start()
    {
        text = GetComponent<Text>();
        score = 0;
    }

    void Update()
    {
        if (score < 0)
            score = 0;

        text.text = "" + score;
    }

    public static void AddPoints(int points)
    {
        score += points;
    }

    public static void Reset()
    {
        score = 0;
    }

}
