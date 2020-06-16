using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : ObjectPool
{
    [Tooltip("Массив префабов всех возмжных врагов, первый - стандартный, остальные соответственно порядку в магазине")]
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private int _purchasedEnemySpawnChance;

    private List<bool> _isBoughtPurchasedEnemies = new List<bool>();   //// список, куплены ли враги в магазине
    private List<int> _purchasedEnemyIndexes;   // массив индексов купленных врагов
    private float _elapsedTime = 0;     // время с последнего спавна

    private void Start()
    {
        _isBoughtPurchasedEnemies.AddRange(GameManager.Instance.IsBoughtEnemies);
        JuggedPool = new List<GameObject>[_isBoughtPurchasedEnemies.Count + 1];     // +1 - стандартный враг
        _purchasedEnemyIndexes = GetAllIndexOf(_isBoughtPurchasedEnemies, true);

        // инициализация списков в JuggedPool
        for (int i = 0; i < JuggedPool.Length; i++)
        {
            JuggedPool[i] = new List<GameObject>();
        }

        // инициализация пулов для стандартного врага и купленных
        for (int i = 0; i < JuggedPool.Length; i++)
        {
            if (i == 0 || _purchasedEnemyIndexes.Contains(i - 1))
                Initialize(_enemyPrefabs[i], JuggedPool[i]);
        }
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            int indexPoolForSpawn = 0;

            if (_isBoughtPurchasedEnemies.Contains(true) && (Random.Range(0, 101) <= _purchasedEnemySpawnChance))
                    indexPoolForSpawn = 1 + GetRandomInt(_purchasedEnemyIndexes);

            if (TryGetObject(out GameObject enemy, JuggedPool[indexPoolForSpawn]))
            {
                _elapsedTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
                
                SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
            }
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        int enemyOrder = enemy.GetComponent<SpriteRenderer>().sortingOrder;

        if (spawnPoint.y == 0)
            enemyOrder = 5;
        else if (spawnPoint.y == -3)
            enemyOrder = 7;
        else if (spawnPoint.y == 3)
            enemyOrder = 3;

        enemy.GetComponent<SpriteRenderer>().sortingOrder = enemyOrder;

        enemy.transform.position = spawnPoint;
        enemy.SetActive(true);
    }

    private List<int> GetAllIndexOf(List<bool> list, bool item)
    {
        List<int> result = new List<int>();

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == item)
                result.Add(i);
        }

        return result;
    }

    /// <summary>
    /// Генератор одного случайного числа из списка. 
    /// </summary>
    private int GetRandomInt(List<int> list)
    {
        if (list == null)
            return -1;

        var r = Random.Range(0, list.Count);
        int result = list[r];

        return result;
    }
}
