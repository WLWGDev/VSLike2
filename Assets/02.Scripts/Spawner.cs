using UnityEngine;
using UnityEngine.InputSystem; // 새로운 Input System 네임스페이스 추가

public class Spawner : MonoBehaviour
{

    public Transform[] spawnPoints;

    float timer;

    private void Awake()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
    }
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 0.2f)
        {
            Spawn();
            timer = 0;
        }

    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(Random.Range(0, 2));
        enemy.transform.position = spawnPoints[Random.Range(1, spawnPoints.Length)].position;
    }
}