using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoints waypoints;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        waypoints = GetComponentInParent<Waypoints>();
        DisplayCoordinates();
    }

    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

        ColorCoordinates();
    }

    void ColorCoordinates()
    {
        if(waypoints.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(
            transform.parent.position.x / 
            UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(
            transform.parent.position.z /
            UnityEditor.EditorSnapSettings.move.z);
        
        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}