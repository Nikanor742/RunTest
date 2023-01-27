using DG.Tweening;
using System;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    public event Action<Coin> OnCoinEnterEvent;
    public event Action OnFinishEnterEvent;

    [SerializeField] private PlayerSettings playerSettings;

    private PlayerInput playerInput;
    private Animator animator;

    private bool isMoving = false;
    private bool canRun = true;
    private int runHash;
    private int winHash;

    private void Start()
    {
        runHash = Animator.StringToHash("Run");
        winHash = Animator.StringToHash("Win");
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponentInChildren<Animator>();
    }
    private void Move()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x - playerInput.Move, playerSettings.leftBorder, playerSettings.rightBorder), 0, transform.position.z + (playerSettings.playerSpeed * Time.deltaTime));
    }

    private void OnFinishEnter()
    {
        canRun = false;
        animator.SetTrigger(winHash);
        transform.DORotate(new Vector3(0, 180, 0), 1f);
    }

    private void Update()
    {
        if (canRun)
        {
            if (Input.GetMouseButton(0))
            {
                Move();
                if (!isMoving)
                {
                    isMoving = true;
                    animator.SetBool(runHash, isMoving);
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                isMoving = false;
                animator.SetBool(runHash, isMoving);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Coin coin))
        {
            OnCoinEnterEvent?.Invoke(coin);
        }
        if (other.TryGetComponent(out Finish finish))
        {
            OnFinishEnterEvent?.Invoke();
            OnFinishEnter();
        }
    }
}
