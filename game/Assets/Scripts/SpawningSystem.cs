using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningSystem : MonoBehaviour
{
    [SerializeField] float spawningTime = 3f;
    [SerializeField] GameObject enemyPrefab;
   
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        Instantiate(enemyPrefab,
            transform.position,
            Quaternion.identity,
            transform);   

        yield return new WaitForSeconds(spawningTime);  
            StartCoroutine(SpawnEnemy());
      
    }
}
