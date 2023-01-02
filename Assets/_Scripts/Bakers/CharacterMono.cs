using System;
using _Scripts.Properties;
using _Scripts.ScriptableObjects;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace _Scripts.Bakers
{
    public class CharacterMono : MonoBehaviour
    {
        public CharacterScriptableObjects character;

        private void Awake()
        {
            character.character.AddComponent<PlayerInputMono>();
        }
    }

    public class CharacterMonoBaker : Baker<CharacterMono>
    {
        public override void Bake(CharacterMono authoring)
        {
            AddComponent(new CharacterProperties
            {
                BaseDamage = authoring.character.baseDamage,
                Health = authoring.character.health,
                Character = GetEntity(authoring.character.character),
                Dexterity = authoring.character.dexterity,
                Intellect = authoring.character.intellect,
                Vitality = authoring.character.vitality
            });
            AddComponent(new CharacterMovementProperties
            {
                Forward = new MovementInputVectors{Key = authoring.character.Forward,  Direction = new float3(0,0,1)},
                Backwards = new MovementInputVectors{Key = authoring.character.Backwards,  Direction = new float3(0,0,-1)},
                Right = new MovementInputVectors{Key = authoring.character.Right,  Direction = new float3(1,0,0)},
                Left = new MovementInputVectors{Key = authoring.character.Left,  Direction = new float3(-1,0,0)},
                SprintSpeed = authoring.character.sprintSpeed,
                Speed = authoring.character.speed,
                GravitySpeed = authoring.character.gravitySpeed
            });
        }
    }
}