using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{

    [SerializeField]
    private GameManager gameManager;
    private bool isQuitting = false;
    public int dropRate = 10;
    [SerializeField]
    private GameObject drop;

    void Awake(){
        gameManager = FindObjectOfType<GameManager>();
    }
    void OnApplicationQuit(){
        isQuitting = true;
    }
    void OnDestroy(){
        if (!isQuitting && gameManager._isOver == false) {
            if (Random.Range(0, 100) < dropRate){
                Instantiate(drop, transform.position, Quaternion.identity);
            }
        }
    }

}
