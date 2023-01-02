using Unity.Entities;
using UnityEngine.InputSystem;

namespace _Scripts.Properties
{
    public partial struct CharacterMovementProperties : IComponentData
    {
        public float Speed;
        public float GravitySpeed;
        public float SprintSpeed;
        public MovementInputVectors Forward; //WASD
        public MovementInputVectors Backwards;
        public MovementInputVectors Right;
        public MovementInputVectors Left;
    }
}