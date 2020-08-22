using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TinyPlanets.Planetas
{
    public class ControladorInput : MonoBehaviour
    {
        private bool MoverPermitido;
        private GameObject planeta;

        private void ManejoToquePantalla()
        {
            if (Input.touchCount > 0)
            {
                Touch toque = Input.GetTouch(0);
                Vector2 posicionTocada = Camera.main.ScreenToWorldPoint(toque.position);
                if(toque.phase == TouchPhase.Began)
                {
                    Collider2D colisionTocada = Physics2D.OverlapPoint(posicionTocada);
                    if(colisionTocada.tag == "Planeta")
                    {
                        MoverPermitido = true;
                        planeta = colisionTocada.gameObject;
                    }
                }
                if(toque.phase == TouchPhase.Moved)
                {
                    if (MoverPermitido)
                    {
                        planeta.transform.position = 
                            new Vector2(posicionTocada.x, posicionTocada.y);
                    }
                }
                if(toque.phase == TouchPhase.Ended)
                {
                    MoverPermitido = false;
                }
            }
        }
        private void Update()
        {
            ManejoToquePantalla();
        }
    }
}