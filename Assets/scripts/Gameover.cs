using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    // Start is called before the first frame update
     public void OnRetry()
    {
        SceneManager.LoadScene("Menu");
        Player.vida = 10;
    }
}
