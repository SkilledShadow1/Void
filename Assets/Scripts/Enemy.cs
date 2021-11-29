using UnityEngine;
using Pathfinding;
using System;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class Enemy : MonoBehaviour
{
    public GameObject Target;

    public float updateRate = 2f;

    private Seeker seeker;
    private Rigidbody2D rb;

    public Path path;
    public float speed = 300f;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;

    public float nextWavepointDistance = 3;

    private int currentWavepont = 0;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if (Target == null)
        {
            return;
        }

        seeker.StartPath(transform.position, Target.transform.position, OnPathComplete);

        StartCoroutine(UpdatePath());
    }

    private IEnumerator UpdatePath()
    {
        if (Target == null)
        {
            yield return false;
        }
        seeker.StartPath(transform.position, Target.transform.position, OnPathComplete);

        yield return new WaitForSeconds(1f/updateRate);

        StartCoroutine(UpdatePath());
    }

    public void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWavepont = 0;
        }

    }

    private void FixedUpdate()
    {
        if (Target == null)
        {
            return;
        }

        if (path == null)
        {
            return;
        }

        if (currentWavepont >= path.vectorPath.Count)
        {
            if (pathIsEnded)
            {
                return;
            }
            else
            {
                pathIsEnded = true;
                return;
            }
        }

        pathIsEnded = false;

        Vector3 dir = (path.vectorPath[currentWavepont] - transform.position).normalized;

        dir *= speed * Time.fixedDeltaTime;

        rb.AddForce(dir, fMode);

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWavepont]);

        if (dist < nextWavepointDistance)
        {
            currentWavepont++;
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
