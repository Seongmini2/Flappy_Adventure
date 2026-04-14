using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.WSA;

public class BulletControl : MonoBehaviour
{
    public GameObject BulletPrefab;

    public float BulletSpeed = 30f;

    private float lifetime = 5f;

    private float spawnTime;
    
    void Start()
    {
       spawnTime = Time.time; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 
			Input.mousePosition.y, -Camera.main.transform.position.z)); //마우스 좌표

            GameObject Bullet = Instantiate(BulletPrefab,transform.position,transform.rotation);
            

            Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();

            Vector3 speed = (point - transform.position).normalized; // 총알 속도 normalized

            rb.AddForce(speed * BulletSpeed , ForceMode2D.Impulse);

        
        }

       
    }

            
}