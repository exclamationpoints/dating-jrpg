using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public List<Button> Choices;
    public ChoicesStorage Storage;
    public List<GameObject> SubMenus;
    private GameObject subMenu;
    private bool resizing;
    private float time;

    void Start()
    {
        if (this.gameObject.name.Equals("Menu")){
            ConfigureMenu(this.gameObject);
        }

        if (SubMenus.Count > 0) {
            foreach (Button choice in Choices)
            {
                choice.onClick.AddListener(delegate {OpenSubMenu(Choices.IndexOf(choice));});
            }

            resizing = false;
            time = 0;
        } else {
            foreach (Button choice in Choices)
            {
                choice.onClick.AddListener(delegate {TriggerEvent(choice.name);});
            }
        }
    }

    void OpenSubMenu(int choiceIndex)
    {
        if (subMenu != null){
            subMenu.transform.Translate(-64, 50 * subMenu.transform.childCount / 4, 0.0f);
            subMenu.transform.localScale += -subMenu.transform.localScale;
            subMenu.transform.localScale += new Vector3(0.001f, 0.001f, 0.0f);

            ColorBlock prevCB = Choices[SubMenus.IndexOf(subMenu)].colors;
            prevCB.normalColor = Color.white;
            Choices[SubMenus.IndexOf(subMenu)].colors = prevCB;

            Storage.RemoveLastChoice();
        }

        ColorBlock newCB = Choices[choiceIndex].colors;
        newCB.normalColor = Color.red;
        Choices[choiceIndex].colors = newCB;

        Storage.AddChoice(Choices[choiceIndex].name);

        subMenu = SubMenus[choiceIndex];
        ConfigureMenu(subMenu);

        time = 0.25f;
        resizing = true;
    }

    void ConfigureMenu(GameObject Menu)
    {
        int spacePerButton = 25;

        RectTransform rt = Menu.GetComponent<RectTransform>();

        if(Menu.name.Equals("Menu")){
            rt.SetLocalPositionAndRotation(new Vector3(-350, 147f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        } else {
            rt.SetLocalPositionAndRotation(this.gameObject.transform.localPosition + new Vector3(128/2 + 10,
                                        ((1.5f - SubMenus.IndexOf(Menu)) * spacePerButton), 0.0f),
                                        new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        }

        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 128);
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, spacePerButton * Menu.transform.childCount + 10);

        int count = 0;

        foreach (Transform choice in Menu.transform){
            choice.SetLocalPositionAndRotation(new Vector3(0f,
                                                spacePerButton / 2 * (Menu.transform.childCount - 1) - count * spacePerButton, 0.0f),
                                                new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

            count += 1;
        }
    }

    void Update()
    {
        if(resizing){
            subMenu.transform.Translate(256 * Time.deltaTime, -100 * subMenu.transform.childCount/2 * Time.deltaTime, 0.0f);
            subMenu.transform.localScale += new Vector3(3.996f * Time.deltaTime, 3.996f * Time.deltaTime, 0.0f);

            time -= Time.deltaTime;

            if (time <= 0){
                resizing = false;
            }
        }
    }

    void TriggerEvent(string choiceName)
    {
        Storage.AddChoice(choiceName);
        Storage.UserAlreadyDecided();
    }
}