using _3rdParty.git_amend.EventBus;
using Core.Input;
using UnityEngine;
using Utils;

namespace Entities.Picker
{
    public class PickerMover : MonoBehaviour
    {

        [SerializeField] private float forwardMoveSpeed;
        [SerializeField] private float slideSpeed;
        [SerializeField] private float responseTime;
        
        private PlayerInputHandler _playerInputHandler;
        private Rigidbody _rigidbody;
        
        private Vector3 _velocity = Vector3.zero;
        private Vector3 _smoothDampVelocity = Vector3.zero;
        
        private bool _canMove;
        
        private const float DAMP_MULTIPLIER = 0.2f;
        private const int DEFAULT_VELOCITY_MULTIPLIER = 250;
        
        private EventBinding<FinishLineTriggeredEvent> _finishLineTriggerBinding;
        
        private void Awake()
        {
            _playerInputHandler = new PlayerInputHandler();
            _rigidbody = GetComponent<Rigidbody>();
            _canMove = true;
        }

        private void OnEnable()
        {
            _finishLineTriggerBinding = new EventBinding<FinishLineTriggeredEvent>(OnFinishLineTriggered);
            EventBus<FinishLineTriggeredEvent>.Register(_finishLineTriggerBinding);
        }

        private void OnFinishLineTriggered(FinishLineTriggeredEvent @event)
        {
            _canMove = false;
        }

        private void OnDisable()
        {
            EventBus<FinishLineTriggeredEvent>.Deregister(_finishLineTriggerBinding);
        }

        private void Update()
        {
            _playerInputHandler.Tick();
        }

        private void FixedUpdate()
        {
            HandlePlayerMovement();
        }

        private void HandlePlayerMovement()
        {
            if (!_canMove)
            {
                if (_rigidbody.velocity != Vector3.zero) 
                {
                    _rigidbody.velocity = Vector3.zero;
                }
                return;
            }
    
            var fixedDeltaTimeMultiplier = slideSpeed * Time.fixedDeltaTime * DEFAULT_VELOCITY_MULTIPLIER;

            var inches = _playerInputHandler.TouchDelta.ConvertPixelsToInches();
            var velocityVector = new Vector3(inches.x * fixedDeltaTimeMultiplier, _rigidbody.velocity.y, forwardMoveSpeed);

            _rigidbody.velocity = velocityVector;

            SmoothDampTouchPositions();
        }

        
        private void SmoothDampTouchPositions()
        {
            _playerInputHandler.TouchBeginPos = Vector3.SmoothDamp(
                _playerInputHandler.TouchBeginPos, 
                _playerInputHandler.TouchEndPos, 
                ref _smoothDampVelocity, 
                responseTime
            );
        }
    }
}