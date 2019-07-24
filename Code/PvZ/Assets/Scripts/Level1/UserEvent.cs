using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserEvent : MonoBehaviour
{
    int plantid = -1;
    private int SunCost = 25;
    private bool seedClicked = false;

    [SerializeField]
    private GameObject plantTemp = null;
    [SerializeField]
    private GameObject gm = null;
    [SerializeField]
    private GameObject[] Plants = null;
    [SerializeField]
    private Button[] button;
    [SerializeField]
    private Sprite[] plantSprites = null;
    [SerializeField]
    private GameObject canvas = null;

    [SerializeField]
    private Button trash = null;

    //set button interactable false initially and set button ids
    void Start()
    {
        for (int i = 0; i < button.Length; i++)
        {
            int index = i;
            button[index].GetComponent<Button>().onClick.AddListener(() => onButtonClick(index));
            button[index].interactable = false;
        }

        trash.onClick.AddListener(delegate { trashEvent();});
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
    private void onButtonClick(int id)
    {
        plantid = id;
        seedClicked = true;
    }

    private void trashEvent()
    {
        plantid = -1;
        seedClicked = false;
        plantSpriteMng();
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
                    canvas.GetComponent<canvas>().setCoolTime(plantid);
                    gm.GetComponent<GameManager>().updateSun(-canvas.GetComponent<canvas>().getPlantCost(plantid));
                    button[plantid].interactable = false;
                    Sprite img = canvas.GetComponent<canvas>().getPanelChargeButtonImage(plantid);
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
         plantTemp.transform.position = new Vector3(
         Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
         Camera.main.ScreenToWorldPoint(Input.mousePosition).y + 0.2f, 0);
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

    public void setButton(int id, bool val)
    {
        button[id].interactable = val;
    }
    public int getLength()
    {
        return button.Length;
    }
    public Button getButton(int id)
    {
        return button[id];
    }
}