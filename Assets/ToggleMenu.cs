using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMenu : MonoBehaviour
{
    private List<Button> toggleGroup1;
    private List<Button> toggleGroup2;
    private List<Button> toggleGroup3;
    private List<Button> currentTG;
    private List<Button> toggledButtons;

    public ChoicesStorage Storage;

    void Start()
    {
        toggleGroup1 = new List<Button>();
        toggleGroup2 = new List<Button>();
        toggleGroup3 = new List<Button>();
        toggledButtons = new List<Button>();

        foreach (Transform child in transform){
            Button toggle = child.GetComponent<Button>();

            if (toggle.name.Equals("Romantic") || toggle.name.Equals("Funny") || toggle.name.Equals("Friendly")){
                toggleGroup1.Add(toggle);
            } else if (toggle.name.Equals("Weird") || toggle.name.Equals("Sad")){
                toggleGroup2.Add(toggle);
            } else if (toggle.name.Equals("Mean")){
                toggleGroup3.Add(toggle);
            }

            toggle.onClick.AddListener(delegate {ApplyChanges(toggle);});
        }
    }

    void ApplyChanges(Button toggle)
    {
        if(!toggledButtons.Contains(toggle)){
            toggle.GetComponent<Image>().color = Color.yellow;

            toggledButtons.Add(toggle);

            if (toggleGroup1.Contains(toggle)){
                currentTG = toggleGroup1;
            } else if (toggleGroup2.Contains(toggle)){
                currentTG = toggleGroup2;
            } else if (toggleGroup3.Contains(toggle)){
                currentTG = toggleGroup3;
            }

            foreach (Transform child in transform){
                Button t = child.GetComponent<Button>();

                if(!currentTG.Contains(t)){
                    t.interactable = false;
                }
            }

            Storage.AddToggle(toggle.name);

        } else {
            toggle.GetComponent<Image>().color = Color.white;

            toggledButtons.Remove(toggle);

            bool tgStillActive = false;

            foreach (Button t in currentTG){
                if (toggledButtons.Contains(t)){
                    tgStillActive = true;
                    break;
                }
            }

            if (!tgStillActive){
                currentTG = null;

                foreach (Transform child in transform){
                    Button t = child.GetComponent<Button>();

                    t.interactable = true;
                }
            }

            Storage.RemoveToggle(toggle.name);
        }
    }
}
