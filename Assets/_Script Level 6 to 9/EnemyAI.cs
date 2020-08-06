using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Rigidbody _rigidbody;
    public Animator _animator;
    public enum enemyState {Walk,Attack};
    public  bool lookleft;
    public  bool lookright;
    public float speed;
    public int state;

    public enemyState _enemyState;
    //public EnemyAI _Enemy;

    private static EnemyAI instance;

    public static EnemyAI Instance
    {
        get { return instance; }
        set { instance = value; }
    }
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        SetAnimatorState(state);
        lookleft = false;
        lookright = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemyState == enemyState.Walk)
        {
            if (lookright)
            {
                this.transform.position = new Vector3(this.transform.position.x - (Time.deltaTime * speed), this.transform.position.y, this.transform.position.z);
                this.transform.localRotation = Quaternion.Euler(transform.localRotation.x,-90,transform.localRotation.z);
                //SetAnimatorState(0);
            }
            else if (lookleft)
            {
                this.transform.position = new Vector3(this.transform.position.x + (Time.deltaTime * speed), this.transform.position.y, this.transform.position.z);
                this.transform.localRotation = Quaternion.Euler(transform.localRotation.x, 90, transform.localRotation.z);
               // SetAnimatorState(0);
            }
        }
    }

  public  void SetAnimatorState(int state)
    {
        if (state == 0)
        {
            _enemyState = enemyState.Walk;
            _animator.SetTrigger("Walk");
        }
        if (state == 1)
        {
            _enemyState = enemyState.Attack;
            _animator.SetTrigger("Attack");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PoliceLeft")
        {
            Debug.Log("Police will move Left");
            lookleft = false;
            lookright = true;
            SetAnimatorState(0);
        }
        else if (other.gameObject.tag == "PoliceRight")
        {
            Debug.Log("Police will move Right");
            lookright = false;
            lookleft = true;
            SetAnimatorState(0);
        }
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {

    //            SetAnimatorState(0);

    //    }
    //}
    /*  private void OnCollisionEnter(Collision collision)
      {
          if (collision.gameObject.tag == "PoliceLeft")
          {
              Debug.Log("Police will move Left");
              lookleft = false;
              lookright = true;
              SetAnimatorState(0);
          }
          else if (collision.gameObject.tag == "PoliceRight")
          {
              Debug.Log("Police will move Right");
              lookright = false;
              lookleft = true;
              SetAnimatorState(0);
          }

      }*/
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SetAnimatorState(1);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SetAnimatorState(0);
        }

    }
}
