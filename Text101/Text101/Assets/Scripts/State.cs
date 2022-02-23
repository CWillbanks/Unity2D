using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(10,15)] [SerializeField] string storyText;
    [SerializeField] State[] nextStates;
    [SerializeField] State hiddenState;
    [SerializeField] State death;
    [SerializeField] bool healthCheck;
    [SerializeField] bool dangerous;
    [SerializeField] bool powerUp;
    [SerializeField] bool flagpoleCheck;
    [SerializeField] bool firstState;

    public string GetStateStory()
    {
        return storyText;
    }

    public State[] GetNextStates()
    {
        return nextStates;
    }

    public bool GetHealthCheck()
    {
        return healthCheck;
    }

    public bool GetDangerous()
    {
        return dangerous;
    }

    public bool GetPowerUp()
    {
        return powerUp;
    }

    public State GetHiddenState()
    {
        return hiddenState;
    }

    public State GetDeath()
    {
        return death;
    }

    public bool GetFlagpoleCheck()
    {
        return flagpoleCheck;
    }

    public bool GetFirstState()
    {
        return firstState;
    }
}
