using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace HUDExamples
{
    [RequireComponent(typeof(CharacterMotor))]
    public class Player : MonoBehaviour
    {
        public UnityEvent OnPlayerJump;

        #region Player stats
        public FractionProperty Health;
        public FractionProperty Mana;
        public FractionProperty Fatigue;

        public float JumpFatigueCost = 5f;
        public float FatigueRegen = 1f;

        [Header("HUD References")]
        public UIBar HealthBar;
        public UIBar ManaBar;
        public UIBar FatigueBar;
        #endregion

        private CharacterMotor characterMotor;
        private bool jumped;
        
        void Awake()
        {
            characterMotor = GetComponent<CharacterMotor>();
        }

        void Start()
        {
            HealthBar.Value = Health;
            ManaBar.Value = Mana;
            FatigueBar.Value = Fatigue;

            StartCoroutine(RegenerateFatigue());
        }

        void Update()
        {
            Movement();
        }

        void Movement()
        {
            #region Other Stuff
            // Get the input vector from keyboard or analog stick
            var directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            if (directionVector != Vector3.zero)
            {
                // Get the length of the directon vector and then normalize it
                // Dividing by the length is cheaper than normalizing when we already have the length anyway
                var directionLength = directionVector.magnitude;
                directionVector = directionVector / directionLength;

                // Make sure the length is no bigger than 1
                directionLength = Mathf.Min(1, directionLength);

                // Make the input vector more sensitive towards the extremes and less sensitive in the middle
                // This makes it easier to control slow speeds when using analog sticks
                directionLength = directionLength * directionLength;

                // Multiply the normalized direction vector by the modified length
                directionVector = directionVector * directionLength;
            }

            // Apply the direction to the CharacterMotor
            characterMotor.inputMoveDirection = transform.rotation * directionVector;
            #endregion

            characterMotor.jumping.enabled = Fatigue.Value >= JumpFatigueCost;

            jumped = Input.GetButtonDown("Jump") && characterMotor.IsGrounded() && characterMotor.jumping.enabled;
            if (jumped)
            {
                Fatigue.Value -= JumpFatigueCost;
                OnPlayerJump.Invoke();
            }

            characterMotor.inputJump = Input.GetButton("Jump");
        }

        IEnumerator RegenerateFatigue()
        {
            while (true)
            {
                Fatigue.Value += FatigueRegen * Time.deltaTime;
                yield return null;
            }
        }
    }
}