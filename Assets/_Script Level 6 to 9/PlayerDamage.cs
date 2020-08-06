using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int playerpower;
    Vector3 originalPos;
    public int state;
    public Animator _animator;
    public enum PlayerState { Death };
    public PlayerState _playerState;
    public int temp;
    public EnemyAI[] enemyAI;
    public bool isdead;
    public Rigidbody _rigidbody;
    public Collider _collider;
    public GameObject damagepanel;
    public bool hight;
    public float posy;
    private static PlayerDamage instance;

    public static PlayerDamage Instance
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
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
        enemyAI = FindObjectsOfType<EnemyAI>();
        temp = playerpower;
        _animator = GetComponent<Animator>();
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (hight)
        {
            if (transform.position.y < posy)
            {
                gameObject.transform.position = originalPos;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Spikes")
        {
            _rigidbody.isKinematic = true;
            _collider.enabled = false;
            SetAnimatorState(0);
            Invoke("OriginalPos", 3.5f);
            playerpower = 0;
            damagepanel.SetActive(true);
            Invoke("StopDamageimg", 0.2f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PoliceAI")
        {
            if (playerpower > 0)
            {
                for(int i=0; i<enemyAI.Length;i++)
                enemyAI[i].SetAnimatorState(1);
                // EnemyAI.Instance.SetAnimatorState(1);
                damagepanel.SetActive(true);
                Invoke("StopDamageimg", 0.1f);
                Invoke("PoliceIdle", 0.1f);
                playerpower--;
                isdead = true;
            }
            else if(playerpower==0)
            {
                if(isdead)
                {
                    for (int i = 0; i < enemyAI.Length; i++)
                    {
                        enemyAI[i].SetAnimatorState(0);
                    }
                    _rigidbody.isKinematic = true;
                    Invoke("PoliceIdle", 0.1f);
                    // _collider.enabled = false;
                    SetAnimatorState(0);
                    Invoke("OriginalPos", 3.5f);
                    isdead = false;
                }

                //gameObject.transform.position = originalPos;
                
            }
        }

       else if(collision.gameObject.tag == "Dog")
        {
            _rigidbody.isKinematic = true;
            _collider.enabled = false;
            SetAnimatorState(0);
            Invoke("OriginalPos", 3.5f);
            playerpower = 0;
            damagepanel.SetActive(true);
            Invoke("StopDamageimg", 0.1f);
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "PoliceAI")
        {
            for (int i = 0; i < enemyAI.Length; i++)
                enemyAI[i].SetAnimatorState(0);
        }
    }
    void SetAnimatorState(int state)
    {
        if (state == 0)
        {
            _playerState = PlayerState.Death;
            _animator.SetTrigger("Death");
        }
    }
    void OriginalPos()
    {
        _rigidbody.isKinematic = false;
        _collider.enabled = true;
        gameObject.transform.position = originalPos;
        playerpower = temp;
    }
    void StopDamageimg()
    {
        damagepanel.SetActive(false);
    }

    void PoliceIdle()
    {
        for (int i = 0; i < enemyAI.Length; i++)
            enemyAI[i].SetAnimatorState(0);
    }


}
