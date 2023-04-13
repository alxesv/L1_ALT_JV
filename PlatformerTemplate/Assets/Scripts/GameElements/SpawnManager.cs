using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemies;
    [SerializeField]
    private float _spawnRate;
    private bool _spawnEnemies;
    private GameManager _gameManager;

    void Awake(){
        _gameManager = FindObjectOfType<GameManager>();
    }

    IEnumerator SpawnEnemies(){
        while (_spawnEnemies){
            yield return new WaitForSeconds(_spawnRate);
            Instantiate(_enemies[Random.Range(0, _enemies.Length)], transform.position, Quaternion.identity);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _spawnEnemies = true;
        _spawnRate = 3f;
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        if(_gameManager._isOver){
            _spawnEnemies = false;
        }
    }
}
