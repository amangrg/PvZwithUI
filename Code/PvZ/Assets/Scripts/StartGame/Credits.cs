using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//displays ccredit screen after credit button is pushed on startscreen
public class Credits : MonoBehaviour
{
    [SerializeField]
    private Button back = null;

    // Start is called before the first frame update

    void Start()
    {
        back.onClick.AddListener(delegate { BackButton(); });
    }

    //Back button pressed
    private void BackButton()
    {
        Debug.Log("Back button Pressed");
        SceneManager.LoadScene(0);
    }
}
