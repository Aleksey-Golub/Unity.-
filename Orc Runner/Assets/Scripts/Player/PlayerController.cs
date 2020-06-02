using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMover), typeof(Player))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Button _upButton;
    [SerializeField] private Button _downButton;
    [SerializeField] private Button _runButton;

    private PlayerMover _mover;
    private Player _player;
    private float _savedTimeScale;

#if UNITY_EDITOR
    private bool isPaused = false;
#endif

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _upButton.onClick.AddListener(_mover.TryMoveUp);
        _downButton.onClick.AddListener(_mover.TryMoveDown);
        _runButton.onClick.AddListener(OnRunButtonClick);
    }

    private void OnDisable()
    {
        _upButton.onClick.RemoveListener(_mover.TryMoveUp);
        _downButton.onClick.RemoveListener(_mover.TryMoveDown);
        _runButton.onClick.RemoveListener(OnRunButtonClick);
    }

#if UNITY_ANDROID && !UNITY_EDITOR

#else
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

        if (Input.GetKeyDown(KeyCode.D))
        {
            OnRunButtonClick();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isPaused == false)
        {
            _savedTimeScale = Time.timeScale;
            Time.timeScale = 0;
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isPaused == true)
        {
            Time.timeScale = _savedTimeScale;
            isPaused = false;
        }
    }
#endif

    public void OnRunButtonClick()
    {
        StartCoroutine(RunCoroutine());
    }

    private IEnumerator RunCoroutine()
    {
        _savedTimeScale = Time.timeScale;
        Time.timeScale *= 2;
        _runButton.interactable = false;

        yield return new WaitForSeconds(4f);

        _savedTimeScale = GameManager.Instance.SavedTimeScale > _savedTimeScale ? GameManager.Instance.SavedTimeScale : _savedTimeScale;
        _runButton.interactable = true;
        Time.timeScale = _player.IsDied ? 0 : _savedTimeScale;
    }
}