using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container; // контейнер для хранения пула объектов
    [SerializeField] private int _poolSize; // размер пула

    private List<GameObject> _pool = new List<GameObject>(); // список с созданными объектами

    protected List<GameObject>[] JuggedPool;    // пул пулов 

    protected void Initialize (GameObject prefab, List<GameObject> pool)
    {
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);

            pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result, List<GameObject> pool)      // дополнительно вернет result
    {
        // подключение Linq, первый элемент с activeSelf == false
        // если использовать _pool.First(), то при отсутствии выключенного объекта быдет ошибка
        result = pool.FirstOrDefault(p => p.activeSelf == false);   
        
        return result != null;
    }
}
