using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy1Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject player;

    void Start()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            yield return null;
            GameObject newBullet = Instantiate(bullet, transform.position, quaternion.identity);
            newBullet.transform.up = player.transform.position - transform.position;
            yield return new WaitForSeconds(1);
        }
    }
}
