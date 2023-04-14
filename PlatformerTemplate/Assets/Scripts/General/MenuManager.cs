using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void survival(){
        SceneManager.LoadScene("Main Alex");
    }

    public void normal(){
        SceneManager.LoadScene("Map 1");
    }
    public void Quit()
    {
        Application.Quit();
    }

}
