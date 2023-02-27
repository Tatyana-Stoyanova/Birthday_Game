using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public void LoadScene(int i) 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(i);
    } 
    public void QuitApp()
    {
        Application.Quit();
    }
}
