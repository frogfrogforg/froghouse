using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace Frog2009
{
    public class FlyBehaviour : MonoBehaviour
    {
        public Vector2 position;
        public Vector2 bias;
        public float speed;
        public float biasStrength;
        public float randomStrength;
        public float randomSpeed;
        public GameObject model;

        private float randomSeed;
        private float randomPos = 0;

        private Vector3 right => Vector3.right;
        private Vector3 up => Vector3.up;

        private Vector3 modelBaseScale;
        float animTime = 0;

        // Start is called before the first frame update
        void Start()
        {
            randomSeed = Random.value;
            modelBaseScale = model.transform.localScale;
            animTime = randomSeed;
        }

        // Update is called once per frame
        void Update()
        {
            randomPos += Time.deltaTime * randomSpeed;
            var randomAngle = Mathf.Lerp(
                0, Mathf.PI * 2,
                Mathf.PerlinNoise(randomSeed, randomPos)
            );
            var randomDirection = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
            var velocity = (randomStrength * randomDirection + biasStrength * bias.normalized) / (biasStrength + randomStrength);
            position += speed * velocity * Time.deltaTime;
            transform.localPosition = right * position.x + up * position.y;

            animTime += Time.deltaTime;
            model.transform.localScale = modelBaseScale * Mathf.Lerp(0.9f, 1.1f, (Mathf.Sin(animTime * 3.0f) + 1) * 0.5f);
            var rot = model.transform.localRotation.eulerAngles;
            rot.x = 20 * Mathf.Sin(animTime * 9.0f);
            model.transform.localRotation = Quaternion.Euler(rot);
        }

        void Pause(bool shouldPause)
        {

        }
    }
}