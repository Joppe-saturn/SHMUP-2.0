using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;

    private void Update()
    {
        transform.position += transform.up * 10 * Time.deltaTime * bulletSpeed;
        if(!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null && transform.tag != collision.transform.tag)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
        }
    }
}
