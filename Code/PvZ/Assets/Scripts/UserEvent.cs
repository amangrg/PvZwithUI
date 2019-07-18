using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserEvent : MonoBehaviour
{
    int plantid = -1;
    //private int SunCost = 25;
    //private bool seedClicked = false;
  //  public GameObject plantTemp;
    public GameObject gm;
    public GameObject[] Plants;
    public Button[] button;
 //   public Sprite[] plantSprites;

    void Start()
    {
        for (int i = 0; i < button.Length; i++)
        {
            int index = i;
            button[index].GetComponent<Button>().onClick.AddListener(() => onButtonClick(index));

        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))             //Make a Event handler class for this function
        {
            mouseClicked();

        }
    }
    public void onButtonClick(int id)
    {
        plantid = id;
        //seedClicked = true;
    }

    //Modularise this function

    private void mouseClicked()
    {
        Ray ray;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (plantid > -1 && hit.transform.gameObject.tag == "tile")
            {
                hit.transform.gameObject.GetComponent<Tile>().plant(Plants[plantid]);
                plantid = -1;
            }
            else if (hit.transform.gameObject.tag == "sun")
            {
                //gm.GetComponent<"GameManager">()
                Destroy(hit.transform.gameObject);
            }
          }
    }

}