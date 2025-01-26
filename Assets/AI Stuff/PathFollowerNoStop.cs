using System.Collections;
using UnityEngine;

public class PathFollowerNoStop : MonoBehaviour
{
    public Transform[] path;
    public float speed = 2.5f;
    public float reachDist = 1.0f;
    public int currentPoint = 0;
    private bool isWaiting = false;

    [SerializeField] Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (!isWaiting){
            animator.speed = 1f;
            float dist = Vector3.Distance (path [currentPoint].position, transform.position);
            transform.position = Vector3.MoveTowards (transform.position,path [currentPoint].position,Time.deltaTime*speed);
            
            // Rotate based on velocity (direction of movement)
            Vector3 direction = (path[currentPoint].position - transform.position).normalized;
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
            }

            
            if (dist <= reachDist){
                currentPoint++;
            }
            if(currentPoint >= path.Length){
                currentPoint = 0;
            }
        }

        else{
            animator.speed = 0f;
        }

    }

    IEnumerator WaitAtPoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(0f);

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
