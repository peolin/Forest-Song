using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayContext : MonoBehaviour
{
    // CONTEXT CLASS
    private IClicker _clicker; // reference to IClicker

    public GameplayContext(){}

    public GameplayContext(IClicker clicker)
    {
        this._clicker = clicker; 
    } 

    // allows dynamic change of concrete strategies at runtime
    public void SetClickerStrategy(IClicker clicker)
    {
        this._clicker = clicker;
    }

    // calls the clicker method through delegating the call to _clicker object
    public void ExecuteClicker()
    {
        _clicker.CheckIfClicked(); 
    }

    public void ExecuteShowText()
    {
        _clicker.ShowText();
    }

    // Update is called once per frame and is overriding the Update method in any -Clicker class
    public void Update()
    {
        _clicker.Update();
    }
}
