using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 몬스터 스폰을 관리하는 스크립트
public class MonsterSpawner : MonoBehaviour
{
    // 몬스터 프리팹과 웨이포인트 리스트
    public GameObject monsterPrefab;
    public List<Transform> pathWaypoints;
    // 스폰할 몬스터 수와 스폰 간격
    public int monsterCount = 5;
    // 스폰 간격
    public float spawnInterval = 2f;

    // 몬스터 스폰 위치
    private Vector2 spawnPosition = new Vector2(-2.24f, -1.5f);

    // 스폰 시작 지연 시간
    public float startDelay = 10f;

    private void Start()
    {
        // 몬스터 스폰 코루틴 시작
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        // 스폰 시작 지연 시간 대기
        yield return new WaitForSeconds(startDelay);

        // 몬스터 스폰
        for (int i = 0; i < monsterCount; i++)
        {
            // 몬스터 프리팹을 스폰 위치에 인스턴스화
            GameObject monster = Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
            MonsterMovement movement = monster.GetComponent<MonsterMovement>();
            movement.waypoints = pathWaypoints;

            // 몬스터의 웨이포인트를 설정
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
