using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour

{
    [SerializeField]
    private float cooldown = 0.5f;
    private float cooldownTimer = 999;
    private PlayerController playerController;
    public Transform shootingPoint;
    public GameObject[] shotPrefabs;
    public GameObject shotSoundHolder;
    public AudioSource shotSound;

    void Awake(){
        shootingPoint = GameObject.Find("ShootingPoint").transform;
        shotSoundHolder = GameObject.Find("ShootingPoint");
        shotSound = shotSoundHolder.GetComponent<AudioSource>();
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Space) && cooldownTimer > cooldown){
        Attack();
     }   
     cooldownTimer += Time.deltaTime;
    }

    private void Attack(){
        shotSound.Play();
        cooldownTimer = 0;
        shotPrefabs[FindShot()].transform.position = shootingPoint.position;
        shotPrefabs[FindShot()].GetComponent<Shot>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindShot(){
        for (int i = 0; i < shotPrefabs.Length; i++){
            if (!shotPrefabs[i].activeInHierarchy){
                return i;
            }
        }
        return 0;
    }
}
