using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    [SerializeField] private GameObject lowPrefab;
    [SerializeField] private GameObject highPrefab;
    [SerializeField] private GameObject bonusPrefab;
    [SerializeField] private float spawnDelay;
    private float spawnDelayForBonus;
    private bool isFirstSpawn=true;
    private bool isBigPrefab=false;

    private void Start(){
        StartCoroutine(SpawnCoroutine());
        spawnDelayForBonus = spawnDelay / 2;
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true){
            if (Random.Range(0, 100) <= 60){//60 процентов на спавн
                Instantiate(lowPrefab, transform.position, Quaternion.identity);
                isBigPrefab = false;
            }
            else{
                Instantiate(highPrefab, transform.position, Quaternion.identity);
                isBigPrefab = true;
            }

            if (Random.Range(0, 100) <= 70&&!isFirstSpawn){//70 процентов на спавн бонуса
                yield return new WaitForSeconds(spawnDelayForBonus);
                if (isBigPrefab){
                    Instantiate(bonusPrefab, new Vector2(transform.position.x - 0.3f, transform.position.y + 1f), Quaternion.identity);
                }
                else{
                    Instantiate(bonusPrefab, new Vector2(transform.position.x - 1f, transform.position.y + 1f), Quaternion.identity);
                }
                yield return new WaitForSeconds(spawnDelayForBonus);
            }
            else{
                yield return new WaitForSeconds(spawnDelay);
            }
            isFirstSpawn = false;
           
        }
    }
}
