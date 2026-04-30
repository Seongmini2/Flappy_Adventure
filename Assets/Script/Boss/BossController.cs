using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BossController : MonoBehaviour
{
    public GameObject BulletPrefab;    
    float StartAngle = -30f; 
    float anglestep = 15f; 
    void Start()
    {   
        StartCoroutine(BossPattern());
    }

    IEnumerator BossPattern() //패턴 랜덤 뽑기
    {
        while (true)
        {   
            yield return new WaitForSeconds(2.0f);

            int randomPattern = Random.Range(0,2);

            if (randomPattern == 0)
            {
                Bullet();
            }

             else if (randomPattern ==1)
            {
                StartCoroutine(RushAttack());
            }
        }
    }  

    IEnumerator RushAttack() //돌진 공격
    {   
        Vector3 StartPosition = transform.position;

        Vector3 Playertarget = GameObject.FindWithTag("Player").transform.position;
        
        float Rushtime = 0.7f;
        float timer = 0f;

        yield return new WaitForSeconds(0.5f);

        while(timer<Rushtime)
        {
            timer += Time.deltaTime;

            transform.position = Vector3.Lerp(StartPosition, Playertarget, timer/Rushtime);

            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        float returnDuration = 1.0f;

        timer = 0f;

        Vector3 currentPosition = transform.position;

        while (timer < returnDuration)
        {
            timer += Time.deltaTime;

            transform.position = Vector3.Lerp(currentPosition, StartPosition, timer / returnDuration);

            yield return null;
        }
    }
    
    void Bullet() //총알 공격
    { 
        {
            float currentBossRotation = transform.eulerAngles.z;

            for (int i = 0; i<5; i++)
            {
                float targetAngle = currentBossRotation + StartAngle + (anglestep * i );

                Quaternion BulletRotation = Quaternion.Euler(0,0,targetAngle);

                Instantiate(BulletPrefab , transform.position,BulletRotation);
            }
        }
    }
}
