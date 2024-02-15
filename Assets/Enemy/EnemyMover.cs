using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    Vector3 startPosition;
    [SerializeField] [Range(0f,5f)] float speed = 1f;

    Enemy enemy;

    public void Awake() 
    {
        enemy = GetComponent<Enemy>();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    private void OnDisable()
    {
        ReturnToStart();
    }

    void FindPath()
    {
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach(Transform child in parent.transform)
        {
            Waypoint wp = child.GetComponent<Waypoint>();
            if(wp != null)
            {
                path.Add(wp);
            }
        }
        startPosition = path[0].transform.position;
    }

    void ReturnToStart()
    {
        transform.position = startPosition;
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPoisition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPoisition);

            while (travelPercent < 1f)
            {
                travelPercent += speed * Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, endPoisition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        FinishPath();
    }

    private void FinishPath() 
    {
        gameObject.SetActive(false);
        enemy.StealGold();
    }
}
