using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]         // обяжет Unity добавить на объект PlayerMover и не даст удалить его
public class PlayerController : MonoBehaviour
{
    private PlayerMover _mover;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();   // возьмет при Старте компонент PlayerMover
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _mover.TryMoveUp();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _mover.TryMoveDown();
        }
    }
}
