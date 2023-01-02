using _Scripts.Properties;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Physics;
using Unity.Physics.Systems;
using Unity.Transforms;
using UnityEngine;

namespace _Scripts.Systems
{
    [UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
    [BurstCompile]
    public partial struct CollisionSystem : ISystem
    {
        private PhysicsWorld _physicsWorld;
        private PhysicsStep _physicsStep;
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<CharacterProperties>();
        }
        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
           
        }
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            _physicsWorld = SystemAPI.GetSingleton<PhysicsWorldSingleton>().PhysicsWorld;
            EntityQuery query = new EntityQueryBuilder(Allocator.TempJob)
                .WithAllRW<CharacterProperties>()
                .Build(state.EntityManager);
            new CollisionCheckJob
                ().Schedule(query);
        }
    }

    [BurstCompile]
    public partial struct CollisionCheckJob : IJobEntity
    {
        [BurstCompile]
        public void Execute()
        {
            
        }
    }
}