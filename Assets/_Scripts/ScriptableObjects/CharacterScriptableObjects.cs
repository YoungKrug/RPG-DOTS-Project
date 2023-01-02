using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace _Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/CharacterObject")]
    public class CharacterScriptableObjects : ScriptableObject
    {
        public float health;
        public float intellect;
        public float dexterity;
        public float vitality;
        public float baseDamage;
        public GameObject character;
        public float speed;
        public float gravitySpeed;
        public float sprintSpeed;
        public Key Forward; //WASD
        public Key Backwards;
        public Key Right;
        public Key Left;
    }
}