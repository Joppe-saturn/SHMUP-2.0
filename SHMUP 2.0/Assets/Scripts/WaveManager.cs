using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [System.Serializable]
    public class Group
    {
        public List<GameObject> enemies = new List<GameObject>();
    }

    [System.Serializable]
    public class Wave
    {
        public List<Group> groups;
        public float spawnInterval = 30;
    }

    [SerializeField] private List<Wave> waves = new List<Wave>();
    public int currentWave = 0;

    private int waveIndex = 0;
    private bool waveDone = true;

    private List<GameObject> currentEnemies = new List<GameObject>();

    private void Update()
    {
        if(waveDone)
        {
            waveDone = false;
            StartCoroutine(SpawnWave());
        }
    }

    private IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(waves[waveIndex].spawnInterval);
        for (int i = 0; i < waves[waveIndex].groups.Count; i++)
        {
            for (int j = 0; j < waves[waveIndex].groups[i].enemies.Count; j++)
            {
                currentEnemies.Add(Instantiate(waves[waveIndex].groups[i].enemies[j], transform.position, Quaternion.identity));
            }
            yield return new WaitForSeconds(waves[waveIndex].spawnInterval);
        }
        while(currentEnemies.Count > 0)
        {
            for(int i = 0; i < currentEnemies.Count; i++)
            {
                if(currentEnemies[i] == null)
                {
                    currentEnemies.Remove(currentEnemies[i]);
                }
            }
            yield return null;
        }
        waveDone = true;
    }
}
