using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_panels : MonoBehaviour
{
    public GameObject drawingsPanel;
    public GameObject textPanel;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Close_drawings_panel()
    {
        drawingsPanel.SetActive(false);
        textPanel.SetActive(false);
    }

    public void Go_to_menu()
    {
        SceneManager.LoadScene("0");
    }
}
