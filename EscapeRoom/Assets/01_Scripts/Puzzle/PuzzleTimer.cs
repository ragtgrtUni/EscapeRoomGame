   using UnityEngine;

   public class PuzzleTimer : MonoBehaviour
   {
       [SerializeField] private float timeLimit = 120f;
       private float elapsed;

       private void Update()
       {
           elapsed += Time.deltaTime;

           if (elapsed >= timeLimit)
           {
               Debug.Log("Se acabó el tiempo del puzzle.");
               enabled = false;
           }
       }
   }