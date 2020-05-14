using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private const int gridSize = 10;
    private bool explored = false;
    public Node exploredFrom;
   

    public bool IsExplored()
    {
        return explored;
    }
    public void SetExplored()
    {
        explored = true;
    }

    public Vector2Int GetGridPosition()
    {
        return new Vector2Int(
          Mathf.RoundToInt(transform.position.x / gridSize),
          Mathf.RoundToInt(transform.position.z / gridSize));
    }

  
    public int GetGridSize()
    {
        return gridSize;
    }
    public void SetTopColor(Color color)
    {
        
        MeshRenderer meshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        meshRenderer.material.color = color;
    }
}
