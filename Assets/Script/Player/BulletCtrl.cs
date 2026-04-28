using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BulletPrefab;
    public float BulletSpeed = 30f;
     void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BulletControl();
    }
    void BulletControl() /// 총알 담당 함수
    {
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
}
