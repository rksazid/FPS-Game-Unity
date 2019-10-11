using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    Vector3 init;
    [SerializeField]
    public float bulletSpeed = 25f;
    [SerializeField]
    public float min_distance = 10f;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        //mainCamera = Camera.main;
        init = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, init);
        if(distance>min_distance)
        {
            Destroy(gameObject);
        }
        //mainCamera = Camera.main;
        //transform.Translate(transform.forward * Time.deltaTime * bulletSpeed);
        //Rigidbody instBulletRigidbody = transform.GetComponent<Rigidbody>();
        //instBulletRigidbody.AddForce(mainCamera.transform.forward * bulletSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Shootable")
        {
            Destroy(collision.collider.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
