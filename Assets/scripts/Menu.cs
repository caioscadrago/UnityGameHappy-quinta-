using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Onplay()
    {
        SceneManager.LoadScene("Level1");
    }
    public void OnQuit()
    {
        Application.Quit();
    }
}
