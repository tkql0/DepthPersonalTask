using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public bool goLeft = false;
    public bool goRight = false;
    // 아이템이 왼쪽이나 오른쪽 방향에서 생성될지를 나타내는 bool 변수
    // 이 값에 따라 어느 쪽의 스포너가 활성화될지 결정

    public List<ObjectSO> itemDatas;
    // 아이템 프리팹을 저장하는 리스트
    // Random.Range를 사용하여 이 리스트에서 무작위로 아이템을 선택
    public List<Spawner> spawnersLeft = new List<Spawner>();
    public List<Spawner> spawnersRight = new List<Spawner>();
    // 왼쪽과 오른쪽에 위치한 스포너를 각각 담고 있는 리스트
    // 스포너는 아이템을 생성할 위치에 대한 정보와 조건을 설정하는 역할
    void Start()
    {
        int itemId1 = Random.Range(0, itemDatas.Count);
        int itemId2 = Random.Range(0, itemDatas.Count);
        // items 리스트에서 무작위로 선택한 두 아이템의 인덱스

        ObjectSO item1 = itemDatas[itemId1];
        ObjectSO item2 = itemDatas[itemId2];

        int direction = Random.Range(0, 2);
        // 무작위로 0 또는 1을 결정하여 goLeft와 goRight 값을 설정

        if (direction > 0)
        { // direction이 0이면 goLeft가 true,
            // goRight가 false가 되어 왼쪽 방향으로 스포너가 활성화
            goLeft = false; goRight = true;
        }
        else
        { // direction이 1이면 goRight가 true,
            // goLeft가 false가 되어 오른쪽 방향으로 스포너가 활성화
            goLeft = true; goRight = false;
        }

        for (int i = 0; i < spawnersLeft.Count; i++)
        { // 리스트의 각 스포너에 대해 반복문을 실행
            if (i % 2 != 0)
            { // 인덱스가 홀수이면 item1
                spawnersLeft[i].Item = item1;
            }
            else
            { // 짝수이면 item2를 해당 스포너의 아이템으로 설정
                spawnersLeft[i].Item = item2;
            }
            // 이로 인해 아이템이 번갈아 가며 배치

            spawnersLeft[i].goLeft = goLeft;
            // goLeft 값을 설정하여 왼쪽 방향 활성화 여부를 전달

            spawnersLeft[i].gameObject.SetActive(goRight);
            // goRight가 true일 때만 이 스포너를 비활성화
            // 즉, 오른쪽 방향이 활성화되면 왼쪽 스포너는 비활성화
            spawnersLeft[i].spawnLeftPos = spawnersLeft[i].transform.position.x;
            // 각 스포너의 x축 위치를 spawnLeftPos에 저장하여
            // 스포너의 초기 위치를 기록
        }

        for (int i = 0; i < spawnersRight.Count; i++)
        { // spawnersRight 리스트의 각 스포너에 대해 동일한 설정을 수행
            if (i % 2 != 0)
            {
                spawnersRight[i].Item = item1;

            }
            else
            {
                spawnersRight[i].Item = item2;

            }
            spawnersRight[i].goLeft = goLeft;
            spawnersRight[i].gameObject.SetActive(goLeft);
            spawnersRight[i].spawnLeftPos = spawnersRight[i].transform.position.x;
            // 왼쪽 스포너와 마찬가지로 인덱스에 따라 item1과 item2를 번갈아 배치하고,
            // goLeft와 goRight 값을 사용하여 스포너의 활성화 여부를 설정
            // 오른쪽 스포너는 goLeft가 true일 때만 비활성화
        }
    }
}
