using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    // Manager chooses necessary strategy
    void Start()
    {
        GameplayContext game_context = GetComponent<GameplayContext>();
        IClicker concreteStrategy = GetComponent<ClickerDialogues>();
        // checking what is the number of current scene
        /*  0 - main menu
            1 - forest opening
            2 - forest monologue
            3 - museum gallery
            4 - museum corridor
         */
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            concreteStrategy = GetComponent<ClickerDialogues>();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            concreteStrategy = GetComponent<ClickerMuseum>();
        }
        //IClicker clicker = new ClickerDialogues();
        //IClicker concreteStrategy = GetComponent<ClickerMuseum>();
        game_context.SetClickerStrategy(concreteStrategy);
        game_context.Update();
        //game_context.ExecuteClicker();
        //game_context.ExecuteShowText();
    }
}