using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D _rigBod;

    [SerializeField]
    private LayerMask m_GroundLayer;
    [SerializeField]
    private LayerMask m_EnemyLayer;

    [SerializeField]
    private float m_JumpForce;

    [SerializeField]
    private float m_MoveSpeed;

    private float _movement;
    private bool _isJump;
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _rigBod = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_gameManager._isOver)
        {
            return;
        }
        if (Physics2D.Raycast(transform.position, Vector2.down, 1f, m_GroundLayer))
        {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                _isJump = true;
            }
        }

        _movement = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if (_isJump)
        {
            _isJump = false;

            _rigBod.AddForce(Vector2.up * m_JumpForce, ForceMode2D.Impulse);
        }

        _rigBod.velocity = new Vector2(m_MoveSpeed * _movement, _rigBod.velocity.y);

        if (_movement > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (_movement < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void Stop()
    {
        _rigBod.velocity = new Vector2(0, _rigBod.velocity.y);
        enabled = false;
    }
}
