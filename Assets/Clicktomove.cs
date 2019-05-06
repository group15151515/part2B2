using UnityEngine;
using UnityEngine.AI;

public class Clicktomove : MonoBehaviour
{

    public Camera cam;

    public NavMeshAgent agent;

    public Animator anim;

    public float startTime, endTime;

    RaycastHit hit;



    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        startTime = 0.0f;
        endTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
    
            startTime = Time.time;

        if (Input.GetMouseButtonUp(0))

            endTime = Time.time;


        if (endTime - startTime > 0)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }

            if (endTime - startTime < 0.5f)
            {
                if (agent.remainingDistance > agent.stoppingDistance)
                {
                    anim.SetInteger("condition", 1);
                }
                else
                {
                    anim.SetInteger("condition", 0);
                }
            }

            else if (endTime - startTime > 0.5f)
            {
                if (agent.remainingDistance > agent.stoppingDistance)
                {
                    anim.SetInteger("condition", 2);
                }
                else
                {
                    anim.SetInteger("condition", 0);
                }
            }


        }

        startTime = 0;
        endTime = 0;
    }
}