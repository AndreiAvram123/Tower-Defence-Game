using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (AudioSource))]
public class Turret : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange =10f;
    [SerializeField] ParticleSystem gun;
    [SerializeField] AudioClip shootSFX;


    private ParticleSystem.EmissionModule emissionModule;
    private float emissionRateOverTime;
    private Transform enemyToShoot;
    public TurretLocation turretLocation;
    private AudioSource shootSound;

    private void Start()
    {
        shootSound = GetComponent<AudioSource>();
        ConfigureParticleSystem();
       
    }

    private void ConfigureParticleSystem()
    {
        emissionModule = gun.emission;
        StopShooting();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GetClosestEnemy()!=null)
        {
            enemyToShoot = GetClosestEnemy().transform;
            FireAtEnemy();
        }
        else
        {
            StopShooting();
        }
    }

    private Enemy GetClosestEnemy()
    {
        Enemy closestEnemy = null;
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        if (enemies.Length != 0)
        {
            closestEnemy = enemies[0];
            foreach (Enemy enemy in enemies)
            {
                if (GetDistanceFromObjects(enemy.transform,gameObject.transform) < 
                    GetDistanceFromObjects(closestEnemy.transform,gameObject.transform))
                {
                    closestEnemy = enemy;
                }
            }
        }
        return closestEnemy;
    }

    private void FireAtEnemy()
    {
        objectToPan.LookAt(enemyToShoot);
        float distanceToEnemy = GetDistanceFromObjects(enemyToShoot.transform,gameObject.transform);
        if (distanceToEnemy <= attackRange)
        {
            Shoot();
        }
      
    }

    private float GetDistanceFromObjects(Transform firstObject, Transform secondObject)
    {
        return Vector3.Distance(firstObject.position, secondObject.position);
    }

    private void StopShooting()
    {
        emissionModule.enabled = false;
        if (shootSound.isPlaying)
        {
            shootSound.Pause();
        }
    }

    private void Shoot()
    { 
        emissionModule.enabled = true;
        if (!shootSound.isPlaying)
        {
            shootSound.PlayOneShot(shootSFX);
        }
       
    }
    
   
}
