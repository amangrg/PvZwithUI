using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserEvent : MonoBehaviour
{
    int plantid = -1;
    private int SunCost = 25;
    private bool seedClicked = false;
    public GameObject plantTemp;
    public GameObject gm;
    public GameObject[] Plants;
    public Button[] button;
    public Sprite[] plantSprites;
    public GameObject canvas;

    //set button interactable false initially and set button ids
    void Start()
    {
        for (int i = 0; i < button.Length; i++)
        {
            int index = i;
            button[index].GetComponent<Button>().onClick.AddListener(() => onButtonClick(index));
            button[index].interactable = false;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))             //Make a Event handler class for this function
        {
            mouseClicked();

        }
        if (seedClicked)
        {
            plantSpriteMng();
            drag();
        }
        if (seedClicked)
        {
            plantSpriteMng();
            drag();
        }
    }
    public void onButtonClick(int id)
    {
        plantid = id;
        seedClicked = true;
    }

    //Modularise this function

    /*
    update sunCost when a plant is placed accordingly and set button interactable to false
    When a plant is planted on tile then set that buttonCoolTime to true and 
    change the image on the panel to recharging image and set button interactable to false
    */
    private void mouseClicked()
    {
        Ray ray;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (plantid > -1 && hit.transform.gameObject.tag == "tile")
            {
                if (hit.transform.gameObject.GetComponent<Tile>().plant(Plants[plantid]))
                {
                    canvas.GetComponent<canvas>().checkButtonCoolTime[plantid] = true;
                    gm.GetComponent<GameManager>().updateSun(-canvas.GetComponent<canvas>().plantCosts[plantid]);
                    button[plantid].interactable = false;
                    Sprite img = canvas.GetComponent<canvas>().panelChargeButtonImage[plantid];
                    button[plantid].GetComponent<Image>().sprite = img;
                    plantid = -1;
                    seedClicked = false;
                    plantSpriteMng();
                }
            }
            if (hit.transform.gameObject.tag == "sun")
            {
               gm.GetComponent<GameManager>().updateSun(SunCost);
                Destroy(hit.transform.gameObject);
            }
          }
    }

    private void drag()
    {
        /*Ray ray;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "tile")
            {
                Debug.Log("Ray hit tile");
                plantTemp.transform.position = new Vector3(
                hit.transform.position.x,
                hit.transform.position.y + 0.2f,
                0
                );
            }
        }
        else */               //For Snapping on the tiles or to make it free
        {
            plantTemp.transform.position = new Vector3(
            Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y + 0.2f,
            0
            );
        }
    }

    private void plantSpriteMng()
    {
        if (plantid > -1)
        {
            plantTemp.GetComponent<SpriteRenderer>().enabled = true;
            plantTemp.GetComponent<SpriteRenderer>().sprite = plantSprites[plantid];
        }
        else
        {
            plantTemp.GetComponent<SpriteRenderer>().enabled = false;
        }

    }

}