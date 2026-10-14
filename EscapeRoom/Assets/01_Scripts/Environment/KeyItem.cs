using UnityEngine;
 
public class KeyItem : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        GameManager.Instance.ObtainKey();
        gameObject.SetActive(false);
        Debug.Log("Llave obtenida.");
    }
}
