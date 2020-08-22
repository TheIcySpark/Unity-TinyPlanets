using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyPlanets.Contenedores;
using UnityEngine.SceneManagement;

namespace TinyPlanets.Planetas
{
    public class MoverAleatoriamente : MonoBehaviour
    {
        [SerializeField] private LimitesPantalla limitesPantalla = null;
        [SerializeField] private float velocidad = 0.75f;
        private Vector2 posObjetivo;

        private void Start()
        {
            posObjetivo = transform.position;
        }

        private  Vector2 DefinirPosicionAleatoria()
        {
            Vector2 ret = new Vector2(
                Random.Range(limitesPantalla.minX, limitesPantalla.maxX),
                Random.Range(limitesPantalla.minY, limitesPantalla.maxY));

            return ret;
        }

        private Vector2 Mover(Vector2 posActual, Vector2 posSig)
        {
            if(posActual== posSig)
            {
                posSig = DefinirPosicionAleatoria();
            }
            transform.position = Vector2.MoveTowards(transform.position,
                posSig, velocidad * Time.deltaTime);
            return posSig;
        }

        private void Update()
        {
            posObjetivo = Mover(transform.position, posObjetivo);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Planeta")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}