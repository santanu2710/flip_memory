using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mobileback : MonoBehaviour
{
    public string where_to_back;
    void Update()
    {
        // Detect if the back button is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Define your desired back button action here
            HandleBackButton();
        }
    }

    void HandleBackButton()
    {
        if (where_to_back == "null")
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(where_to_back);
        }
        
    }
}
