using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public List<Transform> pathWaypoints;
    public int monsterCount = 5;
    public float spawnInterval = 1f;

    private Vector2 spawnPosition = new Vector2(-2.24f, -1.5f);

    public float startDelay = 10f;

    private void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        yield return new WaitForSeconds(startDelay);

        for (int i = 0; i < monsterCount; i++)
        {
            GameObject monster = Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
            MonsterMovement movement = monster.GetComponent<MonsterMovement>();
            movement.waypoints = pathWaypoints;
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
