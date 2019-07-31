using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
/*
 *startgame is first always called at begining or when game is opened.
it initializes start ing variables and let user navigate where to go in the game (level, pause, resume, quit)
*/
public class StartGame : MonoBehaviour
{
    private int resumeLevel = 0;           //To resume the level 
    [SerializeField]
    private Button resume = null;
    [SerializeField]
    private Button play= null;
    [SerializeField]
    private Button quit = null;
    [SerializeField]
    private Button credits = null;
    [SerializeField]
    private Button levels = null;
    [SerializeField]
    private Button help = null;
    [SerializeField]
    private GameObject helpScreen = null;
    [SerializeField]
    private Button back = null;
    [SerializeField]
    private Button profile = null;
    [SerializeField]
    private GameObject profilePanel = null;
    [SerializeField]
    private Button add = null;
    [SerializeField]
    private InputField Name;
    [SerializeField]
    private Dropdown dropdown;
    [SerializeField]
    private Button change;
    private string path = "C:/unitydata/";
    private string playername;
    private string newplayer;
    private int selection = -1;
    private int flag = 0;

    //resume.GetComponent<Button>().onClick.AddListener(() => onButtonClick(index));

    //Start Function is called at the start of the game always,it is used to initialize methods and variables needed at the start.
    void Start()
    {
        dropdown.ClearOptions();
        helpScreen.SetActive(false);
        profilePanel.SetActive(false);
        resumeLevel = PlayerPrefs.GetInt("Current Level");         //Getting the Current Level which the user was on
        if(resumeLevel == 0)
        {
            resume.interactable = false;                           //Suggesting that user was on level 0 at the start
        }
        if (!System.IO.Directory.Exists(path) || !File.Exists(path + "names.txt"))
        {
            System.IO.Directory.CreateDirectory(path);
            StreamWriter writer = new StreamWriter(path + "names.txt", true);
            writer.Close();
        }
        PopulateDropdown();

        resume.onClick.AddListener(delegate { Resume(); });
        play.onClick.AddListener(delegate { Playbutton(); });
        quit.onClick.AddListener(delegate { QuitButton(); });
        credits.onClick.AddListener(delegate { CreditsButton(); });
        levels.onClick.AddListener(delegate { LevelSelect(); });
        help.onClick.AddListener(delegate { HelpScreen(); });
        back.onClick.AddListener(delegate { Back(); });
        profile.onClick.AddListener(delegate { ProfilePanel(); });
        add.onClick.AddListener(delegate { CreateUserData(playername); });
        change.onClick.AddListener(delegate { ChangeUser(); });
        
    }
    void Update()
    {
            
        if (Name.isFocused)
            playername = Name.text;
        if(flag == 0)
        {
            selection = dropdown.value;
            newplayer = dropdown.options[selection].text;
            Debug.Log(selection);
        }
    }
    private void PopulateDropdown()
    {
        dropdown.ClearOptions();
        string []arr = File.ReadAllLines(path + "names.txt");
        if(arr.Length == 0)
        {
            flag = 1;
        } else
        {
            flag = 0;
        }
        List<string> list = new List<string>(arr);
        dropdown.AddOptions(list);
    }
    private void CreateUserData(string name)
    {
        string folderPath = path + name;
        if (!System.IO.Directory.Exists(folderPath))
        {
            System.IO.Directory.CreateDirectory(folderPath);
        } else
        {
            Debug.Log("User Already Exists");
        }
        StreamWriter writer = new StreamWriter(path + "names.txt", true);
        writer.WriteLine(name);
        writer.Close();
        PopulateDropdown();
    }
    //Resume the last played level
    private void Resume()
    {
        SceneManager.LoadScene(resumeLevel);
    }
    private void UpdatePlayer()
    {
        
    }
    private void ChangeUser()
    {
        profile.GetComponentInChildren<Text>().text = newplayer;
    }
    //Start a New game
    private void Playbutton()
    {
        //Debug.Log("Play button Pressed");
        PlayerPrefs.DeleteKey("Current Level");
        SceneManager.LoadScene(3);
    }
    //Quit the Game

    private void QuitButton()
    {
        //Debug.Log("Quit button Pressed");
        Application.Quit();
    }

    //Display Credits
    private void CreditsButton()
    {
        //Debug.Log("Credits button Pressed");
        SceneManager.LoadScene(1);
    }

    //Display LevelSelect Screen
    private void LevelSelect()
    {
        SceneManager.LoadScene(2);
    }
    private void HelpScreen()
    {
        helpScreen.SetActive(true);
    }
    private void ProfilePanel()
    {   if(profilePanel.activeSelf == false)
            profilePanel.SetActive(true);
        else
            profilePanel.SetActive(false);
    }
    private void Back()
    {
        helpScreen.SetActive(false);
    }
}