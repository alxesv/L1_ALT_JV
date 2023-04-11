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
    private float invulnFrameDuration = 0.5f;


    void Start() {
        _playerHealth = 3;
        _maxHealth = 10;
    }
    
    public IEnumerator invulnFrame(){
        _isImmune = true;
        yield return new WaitForSeconds(invulnFrameDuration);
        _isImmune = false;
    }

    public void LoseHealth(int damage){
        if(_isImmune){
            return;
        }

        _playerHealth -= damage;

        if (_playerHealth == 0){
            FindObjectOfType<GameManager>().GameOver();
        }
        
        StartCoroutine(invulnFrame());
    }

    public void GainHealth(int healing){
        if(_playerHealth < _maxHealth){
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
