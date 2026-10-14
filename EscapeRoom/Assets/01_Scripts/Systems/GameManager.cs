using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool HasKey { get; private set; }

    private int initializeCount;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        Initialize();
        Debug.Log("Iniciando partida");
        Initialize();
    }


    public void Initialize()
    {
        initializeCount++;
        Debug.Log("Initialize ejecutado. Veces: " + initializeCount);
    }

    public void ObtainKey()
    {
        HasKey = true;
    }
}
