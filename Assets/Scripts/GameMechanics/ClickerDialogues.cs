using System.Net.Mime;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// class for scenes with ONLY dialogue
public class ClickerDialogues : MonoBehaviour, IClicker
{
    public Sprite[] backgrounds_array; // stores all possible bg images
    public GameObject backgroundImage;

    public GameObject textPanel;
    public TextMeshProUGUI textForPanel; // text in text panel
    public string dialogText; // text for text panel
    private string[] sentences;
    private string[] sentenceArray;

    private bool checkIfClicked;
    public int clickIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        textPanel.SetActive(false);
        checkIfClicked = false;
    }

    // Update is called once per frame
    public void Update()
    {
        CheckIfClicked();
        if (checkIfClicked == true)
        {
            ShowText();
            clickIndex++;
            AdvanceScene();
            //Debug.Log(clickIndex + " - " + textForPanel.text);
        }
        //else Debug.Log("Not clicked: UPDATE"); 
    }

    // FOREST MONOLOGUE - check if left clicked then pass the bool = true to proceed
    public void CheckIfClicked()
    {
        // left click 
        if(Input.GetMouseButtonDown(0)) { checkIfClicked = true; }
        else { checkIfClicked = false; }
    }

    // FOREST MONOLOGUE - check and read the correct txt file, split by sentences and create an array with parts ready to be show on text panel
    public void ShowText()
    {
        // Reading txt file into new string
        string filePath = Application.dataPath + "/Resources/Text scripts/Monologue.txt";
        StreamReader reader = new StreamReader(filePath);
        string content = reader.ReadToEnd();
        reader.Close();

        string[] sentences = content.Split(new string[] { ". " }, System.StringSplitOptions.RemoveEmptyEntries); // Separating sentences by "." + " "

        List<string> sentenceList = new List<string>(); // new List to store all sentences
        // Adding each sentence to the list
        foreach (string sentence in sentences)
        {
            sentenceList.Add(sentence);
        }

        // Converting the list to a string array
        string[] sentenceArray = sentenceList.ToArray();

        // Complete ShowText() - activate panel and show the necessary new text
        dialogText = sentenceArray[clickIndex];
        textPanel.SetActive(true);
        textForPanel.text = dialogText;
        //Debug.Log(sentenceArray.Length + " " + dialogText);
    }

    // advance further into the forest - change BG according to number of clicks
    private void AdvanceScene()
    {
        SpriteRenderer spriteRenderer = backgroundImage.GetComponent<SpriteRenderer>();
        if ((clickIndex >= 10) && (clickIndex < 19)) { spriteRenderer.sprite = backgrounds_array[1]; }
        else if ((clickIndex >= 19) && (clickIndex < 23)) { spriteRenderer.sprite = backgrounds_array[2]; }
        else if (clickIndex >= 23) { spriteRenderer.sprite = backgrounds_array[3]; }
        else { spriteRenderer.sprite = backgrounds_array[0]; }
    }
}
