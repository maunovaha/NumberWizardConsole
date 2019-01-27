using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    private const int defaultMin = 1;
    private const int defaultMax = 1000;

    private int round = 1;
    private int min;
    private int max;
    private int guess;
    
    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        ReadInput();
    }

    private void StartGame()
    {
        min = defaultMin;
        max = defaultMax;
        guess = (max + min) / 2;

        Debug.Log($"Round: {round} - Welcome to NumberWizard!");
        Debug.Log($"Round: {round} - Pick a number between {min} - {max}");
        Debug.Log($"Round: {round} - Tell me if your number is higher or lower than {guess}");
        Debug.Log($"Round: {round} - Push Up = Higher, Push Down = Lower, Push Enter = Correct");

        max++;
    }

    private void ReadInput()
    {
        bool up = Input.GetKeyDown(KeyCode.UpArrow);
        bool down = Input.GetKeyDown(KeyCode.DownArrow);
        bool wrongGuess = up || down;

        if (up)
            min = guess;
        else if (down)
            max = guess;
        else if (Input.GetKeyDown(KeyCode.Return))
            GameOver();

        if (wrongGuess)
            NextGuess();
    }

    private void NextGuess()
    {
        guess = (max + min) / 2;
        Debug.Log($"Round: {round} - Is it higher or lower than {guess}?");
    }

    private void GameOver()
    {
        Debug.Log($"Round: {round} - Game over! The number was {guess}");
        round++;
        StartGame();
    }
}
