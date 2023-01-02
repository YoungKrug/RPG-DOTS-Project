using _Scripts.Properties;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Systems
{
    [BurstCompile]
    public partial struct CreateCharacterSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            
        }
        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
            
        }
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var ecbSingleton = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>();
            var ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged);
            new CreateCharacter
            {
                ECB = ecb
            }.Schedule();
            state.Enabled = false;
        }
    }
    [BurstCompile]
    public partial struct CreateCharacter: IJobEntity 
    {
        public EntityCommandBuffer ECB;
        [BurstCompile]
        public void Execute(CharacterAspect aspect)
        {
            var entity = ECB.Instantiate(aspect.CharacterProperties.ValueRO.Character);
            UniformScaleTransform transform = new UniformScaleTransform
            {
                Position = new float3(0, 0, 0),
                Rotation = quaternion.identity,
                Scale = 10f
            };
            ECB.SetComponent(entity, new Translation
            {
                Value = transform.Position
            });
            Debug.Log("Created");
        }
    }
}