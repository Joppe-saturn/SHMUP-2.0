using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletCooldown;

    private bool canShoot = true;

    private void Update()
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0) * Time.deltaTime * speed;
        if(Input.GetKey(KeyCode.Space) && canShoot)
        {
            StartCoroutine(Shoot());
        }
        if(!GetComponent<Renderer>().isVisible)
        {
            transform.position = new Vector3(transform.position.x * -0.9f, transform.position.y, 0);
        }
    }

    private IEnumerator Shoot()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
        newBullet.tag = transform.tag;
        canShoot = false;
        yield return new WaitForSeconds(bulletCooldown);
        canShoot = true;
    }
}
