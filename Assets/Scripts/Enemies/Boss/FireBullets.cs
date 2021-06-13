using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour
{

    public int fireCase = 0;
    public bool startShooting = false;
    public bool endOfStage = false;
    [SerializeField]
    public int bulletsAmount = 10;

    [SerializeField] //Fire1
    private float startAngle = 90f, endAngle = 270;


    //Fire2
    private float angle = 0;

    private Vector2 bulletMoveDirection;
    // Start is called before the first frame update
    void Update()
    {
        if (startShooting) 
        {
            startShooting = false;
            Debug.Log("Case" + fireCase);
            switch (fireCase)
            {
                case 0:
                    CancelInvoke();
                    break;

                case 1: //At least 10 projectiles in boss object
                    InvokeRepeating("Fire", 10f, 1f);
                    break;

                case 2: //Needs to have only 1 projectiles in boss object
                    InvokeRepeating("Fire2", 10f, 0.1f);
                    break;

                case 3://Needs to have only 1 projectiles in boss object
                    InvokeRepeating("Fire3", 10f, 0.1f);
                    break;
            }
        }
    }

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for(int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;


            GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<BossProjectile>().SetMoveDirection(bulDir);

            angle += angleStep;
        }
    }

    private void Fire2()
    {
        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;


            GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<BossProjectile>().SetMoveDirection(bulDir);

            angle += 10f;
        }
    }

    private void Fire3()
    {
        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;


            GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<BossProjectile>().SetMoveDirection(bulDir);

            angle += 10f;

            if(angle >= 360f)
            {
                angle = 0f;
            }
        }
    }
}
