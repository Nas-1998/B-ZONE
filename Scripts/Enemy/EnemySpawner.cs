using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING};

    //VARIABLES
    [SerializeField] private Wave[] waves;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float waveCountdown = 0;

    private SpawnState state = SpawnState.COUNTING;

    private int currentWave;

    //REFERENCES

    [SerializeField] private Transform[] spawners;
    [SerializeField] private List<CharacterStats> enemyList;

    private void Start()
    {
        waveCountdown = timeBetweenWaves;
        currentWave = 0;
    }

    private void Update()
    {
        if (waveCountdown <= 0)
        {
            if(state == SpawnState.WAITING)
            {
                if(!EnemiesAreDead())
                {
                    return;
                }
                else
                {
                    CompleteWave();
                }
            }

            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[currentWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        state = SpawnState.SPAWNING;
        for(int i = 0; i < wave.enemiesAmount; i++)
        {
            SpawnZombie(wave.enemy);
            yield return new WaitForSeconds(wave.delay);

        }
        
        state = SpawnState.WAITING;

        yield break;
    }

    private void SpawnZombie(GameObject enemy)
    {
        int randomInt = Random.Range(0, spawners.Length);
        Transform randomSpawner = spawners[randomInt];

        GameObject newEnemy = Instantiate(enemy, spawners[randomInt].position, spawners[randomInt].rotation);
        CharacterStats newEnemyStats = newEnemy.GetComponent<CharacterStats>();

        enemyList.Add(newEnemyStats);
    }

    private bool EnemiesAreDead()
    {
        int i = 0;
        foreach(CharacterStats enemy in enemyList)
        {
            if(enemy.IsDead())
            {
                i++;
            }
            else
            {
                return false;
            }
        }
        return true;
    }

    private void CompleteWave()
    {
        ///wave compelted
        
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(currentWave + 1 > waves.Length - 1)
        {
            SceneManager.LoadScene(2);
        }
        
        else
        {
            currentWave++;
            PlayerHud.instance.UpdateWaveAmount();
        }
        
    }

    public int ReturnWave()
    {
        return currentWave;
    }

}
