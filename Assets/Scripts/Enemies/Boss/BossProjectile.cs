using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public float speed;
    private Vector2 moveDirection;
    private Health_Manager healthMan;
    public int damageToGive;

    private void OnEnabled()
    {
        Invoke("DestroyProjectile", 3f);
    }

    // Start is called before the first frame update
    void Start()
    {
        healthMan = FindObjectOfType<Health_Manager>();
        speed = 5f;

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(moveDirection * speed * Time.deltaTime);

    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            healthMan.HurtPlayer(damageToGive);
            DestroyProjectile();
        }
        else if (other.CompareTag("Enemy") || other.CompareTag("WallCollider"))
        {
            DestroyProjectile();
        }
    }

    void OnDisable()
    {
        CancelInvoke();
    }
    void DestroyProjectile()
    {
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }
}
