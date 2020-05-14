using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Node startWaypoint;
    [SerializeField] Node endWaypoint;
    private Node currentNode;
    private Queue<Node> queue = new Queue<Node>();
    private Dictionary<Vector2Int, Node> allNodes = new Dictionary<Vector2Int, Node>();
    private List<Node> path = new List<Node>();


    private Vector2Int[] directions =
   {
       Vector2Int.up,
       Vector2Int.right,
       Vector2Int.left,
       Vector2Int.down
    };


    private void CreatePath()
    {
        //the currentNode is not the end node
        while (currentNode.exploredFrom != null)
        {
            path.Add(currentNode);
            currentNode = currentNode.exploredFrom;
            
        }
        //don't forget to add the first node
        path.Add(startWaypoint);
        path.Reverse();
       
       
    }

    public List<Node> GetPath()
    {
        if (path.Count == 0)
        {
            CalculatePath();
        }
        return path;
    }

    private void CalculatePath()
    {
        LoadWaypoints();
        BreadthSearch();
        CreatePath();
    }

    private void BreadthSearch()
    {
      
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0)
        {    

             currentNode = queue.Dequeue();
            if (!IsEndFound())
            {
                ExploreNeighbours();
                currentNode.SetExplored();
                currentNode.SetTopColor(Color.grey);
            }else
            {
               return;
            }     
        }
        
    }

    private bool IsEndFound()
    {
        return currentNode == endWaypoint;
    }

    private void ExploreNeighbours()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourGridPosition = (direction + currentNode.GetGridPosition());
            if (allNodes.ContainsKey(neighbourGridPosition))
            {
                EnqueueNeighbour(allNodes[neighbourGridPosition]);

            }
        }
    }

    private void EnqueueNeighbour(Node neighbour)
    {
        //neighbour is a pointer 
        //so every action will affect
        //think about java
        if (!neighbour.IsExplored() && !queue.Contains(neighbour))
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = currentNode;
            
        }
    }

   


    public void LoadWaypoints()
    {
        var waypoints = FindObjectsOfType<Node>();
        foreach (Node waypoint in waypoints)
        {
            if (!allNodes.ContainsKey(waypoint.GetGridPosition()))
            {
                allNodes.Add(waypoint.GetGridPosition(), waypoint);
               
            }
            else
            {
                Debug.LogWarning("Duplicate block " + waypoint.GetGridPosition());
            }
        }
      
    }

   
}
