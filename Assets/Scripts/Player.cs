using Components;
using Model;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private SpawnComponent _pausePanelSpawn;
    [SerializeField] private LayerCheck _groundCheck;
    [SerializeField] private LayerCheck _wallCheck;
    [SerializeField] private CheckCircleOverlap _attackRange;
    [SerializeField] private CheckCircleOverlap _interactableRange;
    
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private GameSession _gameSession;
    
    private static readonly int IsMovingAnimKey = Animator.StringToHash("IsMoving");
    private static readonly int IsFallingAnimKey = Animator.StringToHash("IsFalling");
    private static readonly int IsGroundAnimKey = Animator.StringToHash("IsGround");
    private static readonly int JumpAnimKey = Animator.StringToHash("Jump");
    private static readonly int SimpleAttackAnimKey = Animator.StringToHash("SimpleAttack");
    private static readonly int HitAnimKey = Animator.StringToHash("Hit");
    private static readonly int DeathAnimKey = Animator.StringToHash("Death");

    private void Awake()
    {
        _gameSession = FindObjectOfType<GameSession>();
        
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        
        GetComponent<HealthComponent>().SetHealth(_gameSession.PlayerData.HP);
    }

    private void Update()
    {
        //Input
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) Jump();
        if (Input.GetKeyDown(KeyCode.F)) Attack();
        if(Input.GetKeyDown(KeyCode.E)) Interact();
        if (Input.GetKeyDown(KeyCode.Escape) && !_gameSession.PauseController.isPause)
        {
            _pausePanelSpawn.SpawnInParent();
            _gameSession.PauseController.isPause = true;
        }

        //Animator
        _animator.SetBool(IsMovingAnimKey, Input.GetAxis("Horizontal") != 0);
        _animator.SetBool(IsFallingAnimKey, _rigidbody.velocity.y < 0);
        _animator.SetBool(IsGroundAnimKey, _groundCheck.IsTouchingLayer);

        UpdateDirection();
    }

    private void FixedUpdate()
    {
        if (!_gameSession.PauseController.isPause)
        {
            var horizontalVelocity = Input.GetAxis("Horizontal") * _gameSession.PlayerStatisticModel.Speed;
            _rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);
        }
    }

    private void Jump()
    {
        if(_groundCheck.IsTouchingLayer || _wallCheck.IsTouchingLayer)
            if (!_gameSession.PauseController.isPause)
            {
                _rigidbody.AddForce(Vector2.up * _gameSession.PlayerStatisticModel.JumpSpeed, ForceMode2D.Impulse);
                _animator.SetTrigger(JumpAnimKey);
            }
    }
    
    private void UpdateDirection()
    {
        if (!_gameSession.PauseController.isPause)
        {
            if (Input.GetAxis("Horizontal") > 0)
                transform.localScale = new Vector3(5, 5, 1);
            else if(Input.GetAxis("Horizontal") < 0)
                transform.localScale = new Vector3(-5, 5, 1);
        }
    }
    
    private void Attack()
    {
        if (!_gameSession.PauseController.isPause)
        {
            _animator.SetTrigger(SimpleAttackAnimKey);
            _attackRange.Check();
        }
    }

    private void Interact()
    {
        if(!_gameSession.PauseController.isPause)
            _interactableRange.Check();
    }

    public void OnHealthChanged(int currentHealth)
    {
        if (!_gameSession.PauseController.isPause)
        {
            if(currentHealth < _gameSession.PlayerData.HP)
                _animator.SetTrigger(HitAnimKey);
        
            _gameSession.PlayerData.HP = currentHealth;
        }
    }

    public void OnDie()
    {
        _rigidbody.velocity = Vector2.zero;
        _animator.SetTrigger(DeathAnimKey);
    }
}
