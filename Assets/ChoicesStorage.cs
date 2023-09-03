using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicesStorage : MonoBehaviour
{
    private List<string> ChosenActions;
    private List<string> Toggled;
    private bool userDecided;

    void Start()
    {
        ChosenActions = new List<string>();
        Toggled = new List<string>();
        userDecided = false;
    }

    void Update()
    {
        // if (userDecided){
        //     // insert code for dialogue, emote, etc.

        //     // user will choose again
        //     userDecided = false;
        // }
    }

    public void AddChoice(string choice)
    {
        if (!userDecided)
            ChosenActions.Add(choice);
    }

    public void RemoveLastChoice()
    {
        if (!userDecided)
            ChosenActions.RemoveAt(ChosenActions.Count - 1);
    }

    public void AddToggle(string toggle)
    {
        if (!userDecided)
            Toggled.Add(toggle);
    }

    public void RemoveToggle(string toggle)
    {
        if (!userDecided)
            Toggled.Remove(toggle);
    }

    public void UserAlreadyDecided()
    {
        userDecided = true;
    }
}
