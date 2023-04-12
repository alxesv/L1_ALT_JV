using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rigidBod;
    private bool hit;
    private float duration;
    private float direction;

    void Awake() {
        boxCollider = GetComponent<BoxCollider2D>();
        rigidBod = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hit) return;
        float movespeed = speed * Time.deltaTime * direction;
        transform.Translate(movespeed, 0, 0);
        rigidBod.velocity = new Vector2(movespeed, rigidBod.velocity.y);
        duration += Time.deltaTime;
        if (duration > 3) Deactivate();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "NotHit" ) return;
        if(collision.gameObject.tag == "Enemy"){
            collision.gameObject.GetComponent<EnemyHealth>().LoseHealth(1);
        }
        hit = true;
        boxCollider.enabled = false;
        Deactivate();
    }

    public void SetDirection (float _direction){
        duration = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if(Mathf.Sign(localScaleX) != _direction){
            localScaleX = -localScaleX;
        }
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate(){
        gameObject.SetActive(false);
    }
}
