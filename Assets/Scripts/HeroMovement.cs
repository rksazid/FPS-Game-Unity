using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    [SerializeField]
    public float speed = 0.5f;
    [SerializeField]
    public Transform rot_camera;
    [SerializeField]
    public GameObject bullet;
    [SerializeField]
    public Transform bulletPosition;
    [SerializeField]
    public Transform bulletRotation;
    [SerializeField]
    public Transform explosionPosition;
    [SerializeField]
    public GameObject explosionEffect;

    Animator anim;
    Vector3 rot = Vector3.zero;
    

    // Start is called before the first frame update
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        gameObject.transform.eulerAngles = rot;
        transform.position = new Vector3(rot_camera.position.x, transform.position.y, rot_camera.position.z);
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(rot_camera.position.x, transform.position.y, rot_camera.position.z);
        gameObject.transform.eulerAngles =new Vector3(transform.eulerAngles.x, rot_camera.eulerAngles.y, transform.eulerAngles.z);
        
        
        if(Input.GetKey(KeyCode.Escape))
        {
            Cursor.visible = true;
        }

        //shoot
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.visible = false;
            SingleShoot();
            GameObject instBullet = Instantiate(bullet, bulletPosition.position, Quaternion.identity) as GameObject;
            Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
            instBulletRigidbody.AddForce(bulletRotation.forward * speed);
            Instantiate(explosionEffect, explosionPosition.position, Quaternion.identity);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Stop_singleShoot();
            Idle();
        }

        // mouse movement
        if (Input.GetAxis("Mouse X") > 0 && !anim.GetBool("walk_forward"))
        {
            WalkLeft();
            Stop_walkRight();
        }
        else if(Input.GetAxis("Mouse X") < 0 && !anim.GetBool("walk_forward"))
        {
            WalkRight();
            Stop_walkLeft();
        }
        else
        {
            Stop_walkRight();
            Stop_walkLeft();
        }
        
        //Debug.Log("X = "+ Input.GetAxis("Mouse X"));
        
        //forward
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            Run();
            Stop_walkForward();
            
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Stop_idle();
            WalkForward();
            Stop_run();

        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            Stop_run();
            Stop_walkRight();
            Stop_walkForward();
            Idle();
        }

        //left
        if (Input.GetKey(KeyCode.S))
        {
            WalkBackward();
            Stop_idle();
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            Stop_walkBackward();
            Idle();
        }

        //right
        if (Input.GetKey(KeyCode.D))
        {
            WalkRight();
            Stop_idle();
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            Stop_walkRight();
            Idle();
        }

        //left
        if (Input.GetKey(KeyCode.A))
        {
            WalkLeft();
            Stop_idle();
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            Stop_walkLeft();
            Idle();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Shootable")
        {
            Time.timeScale = 0;
        }
    }

    void Idle()
    {
        anim.SetBool("idle", true);
    }

    void Stop_idle()
    {
        anim.SetBool("idle", false);
    }

    void IdleShoot()
    {
        anim.SetBool("idle_shoot", true);
    }

    void Stop_idleShoot()
    {
        anim.SetBool("idle_shoot", false);
    }

    void Run()
    {
        anim.SetBool("run", true);
    }

    void Stop_run()
    {
        anim.SetBool("run", false);
    }

    void SingleShoot()
    {
        Stop_idle();
        Stop_idleShoot();
        Stop_run();
        Stop_walkBackward();
        Stop_walkForward();
        Stop_walkLeft();
        Stop_walkRight();
        anim.SetBool("single_shoot", true);
    }

    void Stop_singleShoot()
    {
        anim.SetBool("single_shoot", false);
    }

    void ShootAuto()
    {
        anim.SetBool("auto_shoot", true);
    }

    void Stop_shootAuto()
    {
        anim.SetBool("auto_shoot", false);
    }

    void WalkForward()
    {
        anim.SetBool("walk_forward", true);
    }

    void Stop_walkForward()
    {
        anim.SetBool("walk_forward", false);
    }

    void WalkBackward()
    {
        anim.SetBool("walk_back", true);
    }

    void Stop_walkBackward()
    {
        anim.SetBool("walk_back", false);
    }

    void WalkRight()
    {
        anim.SetBool("walk_right", true);
    }

    void Stop_walkRight()
    {
        anim.SetBool("walk_right", false);
    }

    void WalkLeft()
    {
        anim.SetBool("walk_left", true);
    }

    void Stop_walkLeft()
    {
        anim.SetBool("walk_left", false);
    }
}
