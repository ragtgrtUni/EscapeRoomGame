using UnityEngine;

public class DoorController : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator animator;

    public void Interact()
    {
        if (!GameManager.Instance.HasKey)
        {
            Debug.Log("Necesitas la llave.");
            return;
        }

        if (animator != null)
        {
            animator.SetTrigger("Open");
        }

        Debug.Log("Puerta abierta. ¡Escape completado!");
    }
}
