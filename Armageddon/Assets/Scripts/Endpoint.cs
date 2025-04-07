using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 몬스터가 엔드포인트에 도달했을 때 생명을 감소시키는 스크립트
public class Endpoint : MonoBehaviour
{
    // 엔드포인트에 도달한 몬스터를 처리하는 메서드
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 충돌한 오브젝트가 몬스터인지 확인
        if (other.CompareTag("Monster"))
        {
            // 몬스터가 엔드포인트에 도달했을 때 생명 감소
            LifeManager.Instance.ReduceLife(1);
            // 몬스터 오브젝트를 파괴
            Destroy(other.gameObject);
        }
    }
}
