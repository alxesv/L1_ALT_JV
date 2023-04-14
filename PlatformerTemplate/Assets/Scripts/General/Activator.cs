using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{

    [SerializeField]
    private float timeToActivate;
    public GameObject[] objectsToActivate;
    private TimerScript timerScript;
    private bool activated = false;

    void Awake(){
        timerScript = FindObjectOfType<TimerScript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!activated){
            if(timerScript.currentTime >= timeToActivate){
                ActivateObjects();
                activated = true;
            }
        }
        
    }

    private void ActivateObjects(){
        for (int i = 0; i < objectsToActivate.Length; i++){
            objectsToActivate[i].SetActive(true);
        }
    }
}
