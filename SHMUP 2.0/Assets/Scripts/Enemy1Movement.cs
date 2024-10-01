using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Start()
    {
        StartCoroutine(MoveTo());
    }

    private void Update()
    {

    }

    private IEnumerator MoveTo()
    {
        Vector3 position = transform.position;
        int multiplier = 1;
        for (float i = 0; i < 1; i += speed / 250)
        {
            transform.position = Vector3.Lerp(position, new Vector3(8 * multiplier, 4, 0), i);
            yield return new WaitForSeconds(0.01f);
        }
        position = transform.position;
        multiplier *= -1;
        while (true)
        {
            for(float i = 0; i < 1; i += speed / 500)
            {
                transform.position = Vector3.Lerp(position, new Vector3(8 * multiplier, 4, 0), i);
                yield return new WaitForSeconds(0.01f);
            }
            position = transform.position;
            multiplier *= -1;
        }
    }
}
