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
        SceneManager.LoadScene("Main Kevin");
    }
    public void Quit()
    {
        Application.Quit();
    }

}
