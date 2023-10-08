using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
        public Transform target;  // Referência ao jogador ou objeto a ser seguido
        public Vector3 offset;    // Diferença de posição entre a câmera e o jogador
        public float smoothSpeed = 0.125f;  // Velocidade de interpolação para suavizar o movimento da câmera

        private void FixedUpdate()
        {
            if (target)
            {
                // A câmera segue a posição do jogador e adiciona o deslocamento definido
                transform.position = target.position + offset;
            }
        }
}

