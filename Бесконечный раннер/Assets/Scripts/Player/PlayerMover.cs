using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;

    private Vector3 _targePosition;     // целевая позиция для движения

    private void Start()
    {
        _targePosition = transform.position;    // при старте целевая позиция = позиции объекта
    }

    private void Update()
    {
        if (transform.position != _targePosition)
        {   // перемещение сглажено через Time.deltaTime относитьльно частоты кадров
            transform.position = Vector3.MoveTowards(transform.position, _targePosition, _moveSpeed * Time.deltaTime);
        }
    }

    public void TryMoveUp()
    {
        if (_targePosition.y < _maxHeight)
        {
            SetNextPosition(_stepSize);
        }
    }

    public void TryMoveDown()
    {
        if(_targePosition.y > _minHeight)
        {
            SetNextPosition(-_stepSize);
        }
    }

    private void SetNextPosition(float stepSize)
    {
        _targePosition = new Vector3(_targePosition.x, _targePosition.y + stepSize, _targePosition.z);
    }
}
