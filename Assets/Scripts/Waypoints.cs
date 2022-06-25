using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;

    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }


    void OnMouseDown() 
    {
        if(isPlaceable)
        {
            isPlaceable = false;
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
        }
    }
}
