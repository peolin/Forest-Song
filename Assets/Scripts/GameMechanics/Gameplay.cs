using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Gameplay : MonoBehaviour
{
    // DRAWINGS
    public Sprite[] drawings_array;
    public Sprite test;
    //public bool playerClicked; // check if clicked
    public GameObject drawingsPanel;
    public Image img; // to show normal drawings
    public GameObject textPanel;
    public TextMeshProUGUI textDesc; // text in text panel
    public string description; // get drawings description

    // Start is called before the first frame update
    void Start()
    {
        drawingsPanel.SetActive(false);
        textPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (drawingsPanel.activeInHierarchy == false)
        {
            if(Input.GetMouseButtonDown(0)) // left click
            {
                //Debug.Log("Pressed left button");
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); // check hit

                if (hit)
                {
                    if ((hit.collider != null) && (hit.collider.gameObject.CompareTag("Drawing"))) // check if hit collider of "Drawing" gameObj
                    {
                        Activate_drawings_panel(hit.collider.gameObject);
                    }
                    else if ((hit.collider != null) && (hit.collider.gameObject.CompareTag("Scene Objects")))
                    {
                        Check_scene_object(hit.collider.gameObject);
                    }
                    else if ((hit.collider != null) && (hit.collider.gameObject.CompareTag("Move scenes")))
                    {
                        Move_to_next_scene();
                    }
                    else if ((hit.collider != null) && (hit.collider.gameObject.CompareTag("Characters")))
                    {
                        Characters_dialogue(hit.collider.gameObject);
                    }
                    else Debug.Log("No hit");
                }
                else Debug.Log("Player did not click on anything.");
            }
        }
    }

    void Activate_drawings_panel(GameObject drawing)
    {
        if (drawingsPanel.activeInHierarchy == false)
        {
            drawingsPanel.SetActive(true);
            if (drawing.name == "Lotus") { img.sprite = drawings_array[0]; description = "M. Danylovich 'Lotus'." + '\n'+ "A lotus flower was always thought to be a symbol of the Sun, cosmic powers and purity.";}
            else if (drawing.name == "Clouds") { img.sprite = drawings_array[1]; description = "Ya. Leonets 'Clouds'." + '\n'+ "A masterpiece of an artist from a younger league of Спілки художників України. It's actually quite nice to be able to come and look at the warm summer sky even on a cold winter day.";}
            else if(drawing.name == "Sunflower") { img.sprite = drawings_array[2]; description = "M. Danylovich 'Sunflower'." + '\n'+ "Another work from solar themed collection of the author. Be careful to apply some sunscreen if you want to look at it a bit longer.";}
            else if (drawing.name == "Mavka") { img.sprite = drawings_array[3]; description = "One of the recent interpretations of the very few last minutes of life of Lesya Ukrainka's mavka. Director of the gallery was lucky enough to find a piece with a massive ornamented frame. It's quite a mystery that only the frame and not the drawing itself was the one to disappear.";}
            else if (drawing.name == "Apples") { img.sprite = drawings_array[4]; description = "T. Yablonska 'Autumn apples'." + '\n'+ "You can almost smell the damp autumn air and hear the rustling leaves in the garden. Too bad that the drawing didn't fit in the frame.";};

            textPanel.SetActive(true);
            textDesc.text = description;
            Debug.Log("Show drawing");
        }
    }

    void Check_scene_object(GameObject scene_object)
    {
        if (scene_object.name == "Rock") {description = "A stone that was possibly used to break the mirror. Our culprit left it at the fireplace, but why?";}
        else if (scene_object.name == "Mirror_cracks") {description = "A broken mirror." ;}

        textPanel.SetActive(true);
        textDesc.text = description;
        Debug.Log("Check object");
    }

    void Move_to_next_scene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Characters_dialogue(GameObject character)
    {
        if (character.name == "Magdalena") 
        {
            int i = UnityEngine.Random.Range(0, 5);
            if (i == 0) { description = "Hi. Want something?";}
            else if (i == 1) { description = "If you wanted to shake my hand you could just ask me.";}
            else if (i == 2) { description = "Please don't poke me.";}
            else if (i == 3) {description = "I'm like Sherlock Holmes, but with a better wardrobe and a more charming personality.";}
            else if (i == 4) { description = "If you need a case cracked, just give me a call. I'll have the culprit behind bars faster than you can say 'whodunit'.";}
        }

        textPanel.SetActive(true);
        textDesc.text = description;
    }
}
