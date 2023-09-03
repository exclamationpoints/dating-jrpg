using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicesStorage : MonoBehaviour
{
    private List<string> ChosenActions;
    private List<string> Toggled;
    private bool userDecided, isRomantic, isFunny, isMean, isWeird, isSad, isFriendly;

    void Start()
    {
        ChosenActions = new List<string>();
        Toggled = new List<string>();
        userDecided = false;

        isRomantic = false;
        isFunny = false;
        isMean = false;
        isWeird = false;
        isSad = false;
        isFriendly = false;
    }

    void Update()
    {
        // if (userDecided){
        //     // insert code for dialogue, emote, etc.

        //     // user will choose again
        //     userDecided = false;
        // }
        
        // clear lists containing actions chosen, and the moods toggled
        //     ChosenActions.Clear();
        //     Toggled.Clear();
    }

    public void AddChoice(string choice)
    {
        if (!userDecided)
            ChosenActions.Add(choice);
            Debug.Log(string.Join( ", ", ChosenActions));
    }

    public void RemoveLastChoice()
    {
        if (!userDecided)
            ChosenActions.RemoveAt(ChosenActions.Count - 1);
    }

    public void CreateChoices(){
    }

    public void CheckToggle()
    {
        isRomantic = Toggled.Contains("Romantic");
        isFunny = Toggled.Contains("Funny");
        isMean = Toggled.Contains("Mean");
        isWeird = Toggled.Contains("Weird");
        isSad = Toggled.Contains("Sad");
        isFriendly = Toggled.Contains("Friendly");

        CreateChoices();
    }

    public void AddToggle(string toggle)
    {
        if (!userDecided)
            Toggled.Add(toggle);
            CheckToggle();
            Debug.Log(string.Join( ", ", Toggled));
    }

    public void RemoveToggle(string toggle)
    {
        if (!userDecided)
            Toggled.Remove(toggle);
            CheckToggle();
            Debug.Log(string.Join( ", ", Toggled));
    }

    public void UserAlreadyDecided()
    {
        userDecided = true;
    }
}
