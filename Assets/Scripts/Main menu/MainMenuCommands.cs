using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuCommands : MonoBehaviour
{



    public GameObject[] menuPanels;
    


    void Start()
    {
        foreach(var menuPanel in menuPanels)
        {
            menuPanel.SetActive(false);
        }
    }


    public void panelOpenAndClose()
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.name;

        switch (buttonName)
        {
            case "Instruction":
                menuPanels[0].SetActive(!menuPanels[0].activeSelf);
                break;

            case "HOME":
                foreach(var manuPanel in menuPanels)
                {
                    manuPanel.SetActive(false);
                }
                break;

            case "Play":
                menuPanels[1].SetActive(!menuPanels[1].activeSelf);
                break;


            case "Upstairs":
                menuPanels[2].SetActive(!menuPanels[2].activeSelf);
                break;


            case "Downstairs":
                menuPanels[3].SetActive(!menuPanels[3].activeSelf);
                break;


            case "kitchen":
                menuPanels[4].SetActive(!menuPanels[4].activeSelf);
                break;


            case "Living Room":
                menuPanels[5].SetActive(!menuPanels[5].activeSelf);
                break;


            case "Basement":
                menuPanels[6].SetActive(!menuPanels[6].activeSelf);
                break;


            case "Coming Soon":
                menuPanels[7].SetActive(!menuPanels[7].activeSelf);
                break;


            case "Back":
                foreach (var manuPanel in menuPanels)
                {
                    manuPanel.SetActive(false);
                }
                menuPanels[1].SetActive(true);
                break;

            default:
                break;
        }
    }

    public void _play()
    {
        SceneManager.LoadScene("Kitchen");
    }
}
