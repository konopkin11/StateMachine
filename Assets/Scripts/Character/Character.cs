using Character.States;
using UnityEngine;

namespace Character
{
    public class Character : MonoBehaviour
    {
        public StateMachineCharacter movementSM;
        public DuckingState ducking;
        public StandingState standing;
        public JumpingState jumping;
        [SerializeField]
        private CharacterData data;
        [SerializeField]
        private float collisionOverlapRadius = 0.0005f;
        [SerializeField]
        private LayerMask whatIsGround;
        private int horizonalMoveParam = Animator.StringToHash("H_Speed");
        private int verticalMoveParam = Animator.StringToHash("V_Speed");
        [SerializeField] private Animator anim;
        #region Properties

        public float NormalColliderHeight => data.normalColliderHeight;
        public float CrouchColliderHeight => data.crouchColliderHeight;
        public float DiveForce => data.diveForce;
        public float JumpForce => data.jumpForce;
        
        public float MovementSpeed => data.movementSpeed;
        public float CrouchSpeed => data.crouchSpeed;
        public float RotationSpeed => data.rotationSpeed;
        public float CrouchRotationSpeed => data.crouchRotationSpeed;
        public float CollisionOverlapRadius => collisionOverlapRadius;
        public int crouchParam => Animator.StringToHash("Crouch");
        public float ColliderSize
        {
            get => GetComponent<CapsuleCollider>().height;

            set
            {
                GetComponent<CapsuleCollider>().height = value;
                Vector3 center = GetComponent<CapsuleCollider>().center;
                center.y = value / 2f;
                GetComponent<CapsuleCollider>().center = center;
            }
        }

        #endregion
        public void Move(float speed, float rotationSpeed)
        {
            Vector3 targetVelocity = speed * transform.forward * Time.deltaTime;
            targetVelocity.y = GetComponent<Rigidbody>().velocity.y;
            GetComponent<Rigidbody>().velocity = targetVelocity;

            GetComponent<Rigidbody>().angularVelocity = rotationSpeed * Vector3.up * Time.deltaTime;

            anim.SetFloat(horizonalMoveParam, GetComponent<Rigidbody>().angularVelocity.y);
            anim.SetFloat(verticalMoveParam, speed * Time.deltaTime);
            
        }
        public bool CheckCollisionOverlap(Vector3 point)
        {
            return Physics.OverlapSphere(point, CollisionOverlapRadius, whatIsGround).Length > 0;
        }
        public void ApplyImpulse(Vector3 force)
        {
            GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        }
        public void ResetMoveParams()
        {
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            anim.SetFloat(horizonalMoveParam, 0f);
            anim.SetFloat(verticalMoveParam, 0f);
        }
        public void SetAnimationBool(int param, bool value)
        {
            anim.SetBool(param, value);
        }

        public void TriggerAnimation(int param)
        {
            anim.SetTrigger(param);
        }
        #region MonoBehaviour Callbacks
        private void Start()
        {
            movementSM = new StateMachineCharacter();

            standing = new StandingState(this, movementSM);
            ducking = new DuckingState(this, movementSM);
            jumping = new JumpingState(this, movementSM);

            movementSM.Initialize(standing);
        }

        private void Update()
        {
            movementSM.CurrentState.HandleInput();

            movementSM.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            movementSM.CurrentState.PhysicsUpdate();
        }

        #endregion
    }
}
