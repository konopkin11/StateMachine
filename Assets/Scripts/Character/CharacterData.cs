using UnityEngine;

namespace Character
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "Game Data/Character Data")]
    public class CharacterData : ScriptableObject
    {
   
        public float movementSpeed = 200f;
        public float crouchSpeed = 100f;
        public float crouchColliderHeight = 2.5f;
        public float normalColliderHeight = 3f;
        public float rotationSpeed = 180f;
        public float crouchRotationSpeed = 70f;
        public float jumpForce = 10f;
        public float diveForce = 30f;
    
    }
}