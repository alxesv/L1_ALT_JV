using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Firetrap : MonoBehaviour
{
    [SerializeField] private int damage;

    [Header ("Firetrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool triggered; // When trap is triggered
    private bool active; // When trap is active and damaging player

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Debug.Log("Player entered firetrap");
            if (!triggered)
            {
                StartCoroutine(ActivateFireTrap());
                // Debug.Log("Firetrap triggered");
            }
            // Debug.Log(active);
            if (active)
            {
                collision.GetComponent<PlayerHealth>().LoseHealth(damage);
                // Debug.Log("Player damaged by firetrap");
            }
        }
    }

    private IEnumerator ActivateFireTrap()
    {
        // Turn sprite red to notify
        triggered = true;
        spriteRend.color = Color.red; // Turn red when triggered

        // Wait for delay then activate trap turn on animationm return color back to normal
        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white; // Turn red when triggered
        active = true;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = true;
        anim.SetBool("activated", true);

        // Wait until X seconds, desactivate trap and reset all variable and animator
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
}
