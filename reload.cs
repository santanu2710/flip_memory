using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reload : MonoBehaviour
{
    public void LoadScence(string scence_name)
    {
        SceneManager.LoadScene(scence_name);
    }
}

