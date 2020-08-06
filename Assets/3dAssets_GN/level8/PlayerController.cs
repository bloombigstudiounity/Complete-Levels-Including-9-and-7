using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public bool stopMovement = false;
    private static PlayerController instance;
    public Animator ninjaAnimator;
    public GameObject SprayParticles;

    public float maxValueHorizontal = -3f;
    public float minValueHorizontal = -7.5f;

    public float maxValueVertical = 6f;
    public float minValueVertical = -1f;
    public Vector3 newPos;
    public static PlayerController Instance
    {
        get { return instance; }
        set { instance = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (stopMovement)
            return;
        //GetComponent<Rigidbody>().MovePosition(movePoint.position);
        //maaaaaovePoint.position = new Vector3(movePoint.position.x-.39f, movePoint.position.y-1.1f, movePoint.position.z);move

         newPos = Vector3.MoveTowards(transform.position, new Vector3(movePoint.position.x, movePoint.position.y, movePoint.position.z), moveSpeed * Time.deltaTime);
        if (newPos.x > minValueHorizontal && newPos.x < maxValueHorizontal)
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(movePoint.position.x , movePoint.position.y , movePoint.position.z), moveSpeed * Time.deltaTime);
            if (newPos.y > minValueVertical && newPos.y < maxValueVertical)
                transform.position = newPos;
            else
            {
                movePoint.position = transform.position;
                return;
            }
        else
        {
            movePoint.position = transform.position;

            return;
        }
        //transform.position = Vector3a.MoveTowards(transform.position, new Vector3(movePoint.position.x - .39f, movePoint.position.y - 1.1f, movePoint.position.z), moveSpeed * Time.deltaTime);
        print("Distance: "+ Vector3.Distance(transform.position, movePoint.position));
        // if (Vector3.Distance(transform.position, movePoint.position) <= 1.168f)
        if (Vector3.Distance(transform.position, movePoint.position) <= 1f)//if(transform.position.x - movePoint.position.x==-.39f && transform.position.y - movePoint.position.y== -1.153f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            }
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            }
        }

    }
    public void PressedSpray()
    {
        ninjaAnimator.SetTrigger("SprayStencil");
        SprayParticles.SetActive(true);
    }
    public void StoppedSpray()
    {
        ninjaAnimator.SetTrigger("idle");
        SprayParticles.SetActive(false);

    }
}
