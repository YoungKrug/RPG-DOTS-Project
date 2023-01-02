
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Windows;

namespace _Scripts.Systems
{
    [BurstCompile]
    public partial struct CharacterMovementSystem :ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            
        }
        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
            
        }
        public void OnUpdate(ref SystemState state)
        {
            if (Keyboard.current.wKey.isPressed)
            {
                Debug.Log("Pressed");
            }
        }
    }
}