using UnityEngine;

public class EventsPlayerController : MonoBehaviour
{
    #region VARIABLES
    
    public static EventsPlayerController Instance { get; private set; }

    [SerializeField] private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Color myGreen = new Color(142f/255f, 226f/255f, 162f/255f);

    private Transform enemy;

    #endregion

    void OnEnable()
    {
        EventsGameManager.OnEnterKeyPressed += ChangeColorToGreen;
        EventsGameManager.OnEscapeKeyPressed += ChangeColorToOriginal;
    }


    void OnDisable()
    {
        EventsGameManager.OnEnterKeyPressed -= ChangeColorToGreen;
        EventsGameManager.OnEscapeKeyPressed -= ChangeColorToOriginal;
    }


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Instance");
        }

        Instance = this;

        originalColor = spriteRenderer.color;
        
    }

    private void Start()
    {
        enemy = FindObjectOfType<EventsEnemy>().gameObject.transform; // There is a unique enemy in the Scene
    }

    public float DistanceToEnemy()
    {
        return Vector3.Distance(transform.position, enemy.position);
    }

    private void ChangeColorToGreen()
    {
        spriteRenderer.color = myGreen;
    }
    
    private void ChangeColorToOriginal()
    {
        spriteRenderer.color = originalColor;
    }
}
