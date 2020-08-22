using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyPlanets.Contenedores
{
    [CreateAssetMenu(fileName = "LimitesPantalla", menuName = "LimitesPantalla")]
    public class LimitesPantalla : ScriptableObject
    {
        public float minX;
        public float minY;
        public float maxX;
        public float maxY;
    }
}