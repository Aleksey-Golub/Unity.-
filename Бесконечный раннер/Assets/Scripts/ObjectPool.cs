using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container; // контейнер для хранения пула объектов
    [SerializeField] private int _quantity; // размер пула

    private List<GameObject> _pool = new List<GameObject>(); // список с созданными объектами

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _quantity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)      // дополнительно вернет result
    {
        // подключение Linq, первый элемент с activeSelf == false
        // если использовать _pool.First(), то при отсутствии выключенного объекта быдет ошибка
        result = _pool.FirstOrDefault(p => p.activeSelf == false);   
        
        return result != null;
    }
}
