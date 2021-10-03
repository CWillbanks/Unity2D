using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] State startingState;

    State state;
    System.Random rd = new System.Random();
    int health = 1;

    // Start is called before the first frame update
    void Start()
    {
        state = startingState;
        textComponent.text = state.GetStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        if (state.GetFirstState()) // Reset health to 1 since it's a new game.
            health = 1;
        ManageState();
    }

    private void ManageState()
    {
        var nextStates = state.GetNextStates();

        for (int i = 0; i < nextStates.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                AdvanceState(nextStates, i);
            }
        }

        if (Input.GetKeyDown(KeyCode.F) && health >= 3)
            Fireball(nextStates);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }

        textComponent.text = state.GetStateStory();
    }

    private void AdvanceState(State[] nextStates, int i)
    {
        if (nextStates[i].GetPowerUp())
            health++;

        if (nextStates[i].GetFlagpoleCheck() && rd.Next(0, 2) == 1)
            state = nextStates[i].GetHiddenState();

        else if (nextStates[i].GetHealthCheck())
        {
            if (nextStates[i].GetDangerous()) // Hitting an enemy.
            {
                if (health == 1)
                    state = state.GetDeath();
                else
                {
                    health = 1;
                    state = nextStates[i];
                }
            }

            else // Discovering a power up.
            {
                if (health == 1)
                    state = nextStates[i];
                else
                    state = state.GetHiddenState();
            }
        }

        else
        {
            state = nextStates[i];
        }
    }

    private void Fireball(State[] nextStates)
    {
        for (int i = 0; i < nextStates.Length; i++)
            if (nextStates[i].GetDangerous())
            {
                state = state.GetHiddenState();
                break;
            }
    }
}
