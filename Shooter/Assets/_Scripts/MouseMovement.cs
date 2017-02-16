using UnityEngine;
using System.Collections;

public class MouseMovement : MonoBehaviour {

    public int smooth;  // walking speed
    public Animator anim;
    public GameObject particleMenu;

    private RaycastHit hit;
    private float eps = 0.0001f;
    private float hitdist = 0.001f;
    private bool isWalking;
    private bool isRunning;
    private Vector3 targetPosition;
    private Vector3 movementPosition;
    private int runSpeedMultiplier;   // run speed
    
	void Start ()
    {
        anim = GetComponent<Animator>();

        isWalking = false;
	    isRunning = false;

	    runSpeedMultiplier = 3;
    }

    void Update()
    {
        var playerPlane = new Plane(Vector3.up, transform.position);
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (particleMenu.active == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (playerPlane.Raycast(ray, out hitdist))
                {
                    var targetPoint = ray.GetPoint(hitdist);
                    targetPosition = ray.GetPoint(hitdist);
                    var targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
                    transform.rotation = targetRotation;
                }

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {

                    if (Mathf.Abs(Vector3.Distance(hit.point, transform.position)) > eps)
                    {
                        movementPosition = hit.point;
                        isWalking = true;
                    }
                }
            }

            if (Mathf.Abs(Vector3.Distance(movementPosition, transform.position)) < eps)
            {
                isWalking = false;   
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                isRunning = true;
            }
            else
            {
                isRunning = false;
            }

            if (isRunning)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime*smooth*runSpeedMultiplier);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * smooth);
            }
            anim.SetBool("run", isRunning);
            anim.SetBool("isWalking", isWalking);
        }
    }
}
