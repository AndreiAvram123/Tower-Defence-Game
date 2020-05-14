using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] GameObject turretPrefab;
    [SerializeField] int maxNumberOfTowers = 5;
    [SerializeField] float turretYOffset = 12f;

    private Queue<Turret> turretsQueue = new Queue<Turret>();
    private Vector3 turretOffsetVector;

    
    private void Start()
    {
        turretOffsetVector = new Vector3(0f, turretYOffset, 0f);
    }

    public int GetCurretNumberOfTowwers()
    {
        return turretsQueue.Count;
    }

    public int GetMaxNumbersOfTowers()
    {
        return maxNumberOfTowers;
    }

    public void CreateTower(TurretLocation turretLocation)
    {
        if (turretsQueue.Count < 5)
        {
            InstantiateTower(turretLocation);
        }else
        {
            MoveExistingTower(turretLocation);
        }
    }

 
    private void InstantiateTower(TurretLocation turretLocation)
    {
        turretLocation.hasTower = true;
        var newTurret = (Instantiate(turretPrefab,
                    new Vector3(turretLocation.transform.position.x, 
                    turretLocation.transform.position.y,
                    turretLocation.transform.position.z) + turretOffsetVector,
                    Quaternion.identity
                    )).GetComponent<Turret>();

        newTurret.turretLocation = turretLocation;
        turretsQueue.Enqueue(newTurret);
    }

    private void MoveExistingTower(TurretLocation turretLocation)
    {
        var oldTurret =  turretsQueue.Dequeue();
        oldTurret.turretLocation.hasTower = false;

        oldTurret.turretLocation = turretLocation;
        oldTurret.turretLocation.hasTower = true;
        oldTurret.transform.position = turretLocation.transform.position
            +turretOffsetVector;

        turretsQueue.Enqueue(oldTurret);
    }
}
