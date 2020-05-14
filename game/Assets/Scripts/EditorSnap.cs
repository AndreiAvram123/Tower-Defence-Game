using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
//every time we add the EditorSnap script 
//the Waypoint script is automatically added 
[RequireComponent(typeof(Node))]
public class EditorSnap : MonoBehaviour
{

 
     Node waypoint;
   


    private void Awake()
    {
        waypoint = GetComponent<Node>();
       
    }

    
    void Update()
    {   //this is automatically initialized to a new vector3
        SnapToPosition();

        UpdateLabel();

    }

    private void UpdateLabel()
    {
        TextMesh textMesh;
        //display the position on the label
        textMesh = GetComponentInChildren<TextMesh>();
        //makes it more pleasant to read  
        if (textMesh != null)
        {
            string labelText = waypoint.GetGridPosition().x
                + "," + waypoint.GetGridPosition().y;
            textMesh.text = labelText;
            gameObject.name = labelText;
        }
    }

    private void SnapToPosition()
    {
        transform.position = new Vector3(waypoint.GetGridPosition().x * waypoint.GetGridSize(), 
            transform.position.y,
            waypoint.GetGridPosition().y * waypoint.GetGridSize());
    }
}
