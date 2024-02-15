using System.ComponentModel;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable = false;

    public bool IsPlaceable
    {
        get { return isPlaceable; }
    }

    private void OnMouseDown()
    {
        if(isPlaceable)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlaceable = !isPlaced;
        }
    }
}
