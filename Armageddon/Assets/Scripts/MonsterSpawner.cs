using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// 몬스터 스폰을 관리하는 스크립트
public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public List<Transform> pathWaypoints;

    public int monsterCount = 5;
    public float spawnInterval = 2f;
    private int spawnedCount = 0;

    private Vector2 spawnPosition = new Vector2(-2.24f, -1.5f);
    public float startDelay = 10f;

    // UI에 현재 생성된 수 / 총 수를 보여줄 텍스트
    public TextMeshProUGUI monsterCountText;

    private void Start()
    {
        UpdateMonsterCountUI(); // 시작 시 UI 초기화
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

            spawnedCount++;
            UpdateMonsterCountUI();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void UpdateMonsterCountUI()
    {
        if (monsterCountText != null)
        {
            monsterCountText.text = $"{spawnedCount}/{monsterCount}";
        }
    }
}
