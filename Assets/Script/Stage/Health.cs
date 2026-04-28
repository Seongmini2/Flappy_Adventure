using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp = 3;
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("아야");
            hp--;
            Destroy(other.gameObject);

            if(hp<=0)
            {
                Destroy(gameObject);
            }

        }
    }
}
