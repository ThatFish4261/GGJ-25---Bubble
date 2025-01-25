using System.Collections;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public Transform[] path;
    public float speed = 2.5f;
    public float reachDist = 1.0f;
    public int currentPoint = 0;
    private bool isWaiting = false;

    void Start()
    {
    }

    void Update()
    {
        if (!isWaiting)
        {
            float dist = Vector3.Distance(path[currentPoint].position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, path[currentPoint].position, Time.deltaTime * speed);

            if (dist <= reachDist)
            {
                StartCoroutine(WaitAtPoint());
            }
        }
    }

    IEnumerator WaitAtPoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(1.5f);

        currentPoint++;
        
        if (currentPoint >= path.Length)
        {
            currentPoint = 0; 
        }

        isWaiting = false;
    }

    void OnDrawGizmos()
    {
        if (path.Length > 0)
        {
            for (int i = 0; i < path.Length; i++)
            {
                if (path[i] != null)
                {
                    Gizmos.DrawSphere(path[i].position, reachDist);
                }
            }
        }
    }
}
