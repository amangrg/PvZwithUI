using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{   
    [SerializeField]
    private InputField userName;
    [SerializeField]
    private InputField passWord;
    [SerializeField]
    private InputField confirmPassword;
    private string form;
    private string username;
    private string password;
    private string confirmpassword;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void RegisterButton()
    {
        bool UN = false;
        bool PW = false;
        bool CPW = false;
        if (!System.IO.Directory.Exists("C:/unitydata/"))
        {
            System.IO.Directory.CreateDirectory("C:/unitydata/");
        }
        if (username != ""){
            if (System.IO.File.Exists(@"C:/unitydata" + username + ".txt")){
                Debug.LogWarning("Username Taken");
            }
            else {
                UN = true;
            }
        } else{
            Debug.LogWarning("Username field Empty");
        }
        if (password != ""){
            PW = true;
            
        }
        else{
            Debug.LogWarning("Password field Empty");
        }
        if (confirmpassword == password){
            CPW = true;

        }
        else{
            Debug.LogWarning("Passwords don't match");
        }
        if(UN && PW && CPW){
            form = (username + "\r\n" + password);
            System.IO.File.WriteAllText(@"C:/unitydata/" + username + ".txt", form);
            userName.text = "";
            passWord.text = "";
            confirmPassword.text = "";
            print("Registration Successful");
        }
    }
    // Update is called once per frame
    void Update()
    {   
        if(userName.isFocused)
            username = userName.text;
        if(passWord.isFocused)
            password = passWord.text;
        if(confirmPassword.isFocused)
            confirmpassword = confirmPassword.text;
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (username != "" && password != "" && confirmpassword != "")
                RegisterButton();
        }
        
    }
}
