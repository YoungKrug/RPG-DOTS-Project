
using _Scripts.Properties;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Windows;

namespace _Scripts.Systems
{
    [BurstCompile]
    [UpdateAfter(typeof(CreateCharacterSystem))]
    public partial struct CharacterMovementSystem :ISystem
    {
        private Entity _player;
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<ControllablePlayerProperties>();
        }
        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
            
        }
        public void OnUpdate(ref SystemState state)
        {
            float3 direction = new float3();
            EntityQuery query = new EntityQueryBuilder(Allocator.TempJob)
                .WithAllRW<ControllablePlayerProperties>()
                .Build(state.EntityManager);
            var ecbSingleton = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>();
            var ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged);
            if (Keyboard.current.wKey.isPressed)
            {
                direction.z += 1;
            }
            if (Keyboard.current.aKey.isPressed)
            {
                direction.x -=1;
            }
            if (Keyboard.current.sKey.isPressed)
            {
                direction.z -= 1;
            }
            if (Keyboard.current.dKey.isPressed)
            {
                direction.x += 1;
            }

            float timeDelta = SystemAPI.Time.DeltaTime;
            new MoveCharacterJob{Direction = direction, ECB = ecb, TimeDelta = timeDelta}.Schedule(query);
        }
       
    }
[BurstCompile]
    public partial struct MoveCharacterJob : IJobEntity
    {
        public float3 Direction;
        public EntityCommandBuffer ECB;
        public float TimeDelta;
        [BurstCompile]
        public void Execute(ref Translation translation, ref CharacterMovementProperties aspect)
        {
            translation.Value += (Direction * aspect.Speed * TimeDelta);
        }
    }
    
}