using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] ParticleSystem particles;
    [SerializeField] GameObject start;
    [SerializeField] GameObject options;
    [SerializeField] GameObject quit;

    public void PlayStart()
    {
       ParticleSystem particlesStart = Instantiate(particles, start.transform.position, Quaternion.identity);
       
    }
    public void PlayOptions()
    {
        ParticleSystem particlesOption = Instantiate(particles, options.transform.position, Quaternion.identity);
        
    }
    public void PlayQuit()
    {
        ParticleSystem particlesExit = Instantiate(particles, quit.transform.position, Quaternion.identity);
       
    }

}
