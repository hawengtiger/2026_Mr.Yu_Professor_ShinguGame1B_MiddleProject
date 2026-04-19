using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public GameObject white, black;
    public bool iswhite = false;

    public SpriteRenderer playerRenderer;
    public Sprite whiteSprite;
    public Sprite blackSprite;

    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            iswhite = !iswhite;

            animator.Play(iswhite ? "whitewalk" : "blackwalk");
        }

        if (!iswhite)
        {
            black.SetActive(false);
            white.SetActive(true);
        }
        else
        {
            black.SetActive(true);
            white.SetActive(false);
        }

        playerRenderer.sprite = iswhite ? whiteSprite : blackSprite;
    }
}
