using System;
using UnityEngine;
using Random = System.Random;

namespace KittyPlatformer.Objects
{
    public class LootDropper : MonoBehaviour
    {
        [SerializeField] private GameObject[] prefabs;
        [SerializeField] private int[] probabilities;
        [SerializeField] private int countItems;
        [SerializeField] private float dispersion;

        private Random _random;
        private int[] pullProbabilities;

        public void Drop(Vector3 position)
        {
            for (int i = 0; i < countItems; i++)
                Instantiate(
                    ChooseCurrentGameObject(),
                    GenerateScatteredPosition(position),
                    Quaternion.identity);
        }

        private void Awake()
        {
            _random = new Random();
            countItems = countItems < 0 ? 0 : countItems;
            int[] userData = probabilities;
            probabilities = new int[prefabs.Length];
            for (int i = 0; i < probabilities.Length; i++)
                try
                {
                    if (userData[i] < 0)
                        probabilities[i] = 0;
                    else probabilities[i] = userData[i];
                }
                catch (Exception)
                {
                    probabilities[i] = 0;
                }

            CreatePull();
        }

        private void CreatePull()
        {
            int length = 0;
            foreach (var count in probabilities)
                length += count;
            pullProbabilities = new int[length];
            for (int i = 0, k = 0; i < probabilities.Length; i++)
            for (int j = 0; j < probabilities[i]; j++, k++)
                pullProbabilities[k] = i;
        }

        private GameObject ChooseCurrentGameObject()
        {
            int next = _random.Next(pullProbabilities.Length);
            return prefabs[pullProbabilities[next]];
        }

        private Vector3 GenerateScatteredPosition(Vector3 position)
        {
            var pos = (float) (_random.NextDouble() * dispersion);
            pos *= _random.Next(1, 2) == 1 ? -1 : 1;
            position.x += pos;
            position.y += (float) (_random.NextDouble() * dispersion);
            return position;
        }
    }
}