using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerUI : MonoBehaviour
{
    private Text numberOfTowers;
    private TowerFactory towerFactory;
   
    void Start()
    {
        numberOfTowers = GetComponent<Text>();
        towerFactory = FindObjectOfType<TowerFactory>(); 
    }

    // Update is called once per frame
    void Update()
    {
        numberOfTowers.text = string.Format("Towers {0}/{1}",
            towerFactory.GetCurretNumberOfTowwers(),
            towerFactory.GetMaxNumbersOfTowers());
       
    }
}
