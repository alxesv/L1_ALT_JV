using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int _playerHealth;
    public int _maxHealth;
    public Image[] hearts;
    public bool _isImmune = false;
    [SerializeField]
    private float invulnFrameDuration;
    public AudioSource audioSource;


    void Start() {
        _playerHealth = 3;
        _maxHealth = 10;
        audioSource = GetComponent<AudioSource>();
    }

    public IEnumerator invulnFrame(){
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        _isImmune = true;
        yield return new WaitForSeconds(invulnFrameDuration);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        _isImmune = false;
    }

    public void LoseHealth(int damage){
        if(_isImmune){
            return;
        }

        _playerHealth -= damage;

        if (_playerHealth == 0){
            GetComponent<PlayerController>().Stop();
            FindObjectOfType<GameManager>().GameOver();
        }
        
        StartCoroutine(invulnFrame());
    }

    public void GainHealth(int healing){
        if(_playerHealth < _maxHealth){
            audioSource.Play();
            _playerHealth += healing;
        }else {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < _playerHealth){
                hearts[i].enabled = true;
            }
            else {
                hearts[i].enabled = false;
            } 
        }
    }
}
