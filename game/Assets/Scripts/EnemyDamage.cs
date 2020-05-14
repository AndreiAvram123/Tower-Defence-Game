using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int health =10;
    [SerializeField] int scorePerKill =30;
    [SerializeField] ParticleSystem damageParticles;
    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] AudioClip deathSFX;
    private ScoreBoard scoreBoard;
    

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
     
    }

  

    private void OnParticleCollision(GameObject other)
    {
        DecreateHeath();
        PlayHitParticles();
    }
    private void PlayHitParticles()
    {
        damageParticles.Play();
    }
    private void PlayDeathParticles()
    {
        var particleVfx =Instantiate(deathParticles,
            transform.position,
            Quaternion.identity
            );
        particleVfx.Play();
        Destroy(particleVfx.gameObject, particleVfx.main.duration);
    }

    public void KillEnemy()
    {
        AudioSource.PlayClipAtPoint(deathSFX,
            Camera.main.transform.position
            ,0.5f
           );
        PlayDeathParticles();
        Destroy(gameObject);
    }


    private void DecreateHeath()
    {
        health--;
        if (health <= 0)
        {
            KillEnemy();
            scoreBoard.IncreaseScore(scorePerKill);

        }
    }
    
}
