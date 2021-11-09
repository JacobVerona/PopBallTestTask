using System.Collections.Generic;
using UnityEngine;

namespace PopBall.Core.Balls
{
    [CreateAssetMenu]
    public class BallsContainer : ScriptableObject
    {
        [SerializeField] private List<Ball> _ballPrefabs;

        public Ball GetRandomPrefab()
        {
            return _ballPrefabs[Random.Range(0, _ballPrefabs.Count)];
        }
    } 
}