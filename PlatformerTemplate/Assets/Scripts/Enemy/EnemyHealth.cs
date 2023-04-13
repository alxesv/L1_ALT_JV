using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _enemyHealth;
    private Animator anim;
    private bool dead;
    public float delay;

    // private bool alive;

    // void Start(){
    //     alive = true;
    // }

    private void Awake()
    {
        // currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        // spriteRend = GetComponent<SpriteRenderer>();
    }

    public void LoseHealth(int damage)
    {
        _enemyHealth -= damage;
        // Debug.Log("Enemy Health: " + _enemyHealth);
        if (_enemyHealth > 0)
        {
            anim.SetTrigger("hurt");
            // StartCoroutine(invulnFrame());
        }
        else
        {
            GetComponent<Collider2D>().enabled = false;
            anim.SetTrigger("die");
        }
    }

    public void Die(){
        Destroy(gameObject);
    }
}
