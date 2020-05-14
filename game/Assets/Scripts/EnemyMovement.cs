using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float enemyMovementTime = 1f;
    [SerializeField] float distanceFromCubePivor = 11f;

   
    private void Start()
    {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path)); 
    }

     

    IEnumerator FollowPath(List<Node> path)
    {
        foreach (Node waypoint in path)
        {
            transform.position = waypoint.transform.position + new Vector3(0f,distanceFromCubePivor,0f);
            //stop running and wait for a second
            yield return new WaitForSeconds(enemyMovementTime);
        }
        //the enemy has reached the base 
        GetComponent<EnemyDamage>()
            .KillEnemy();
        FindObjectOfType<PlayerHealth>().DecreaseHealth();


     
    }

   
}


