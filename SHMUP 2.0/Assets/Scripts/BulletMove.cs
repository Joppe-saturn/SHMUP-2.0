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
}
