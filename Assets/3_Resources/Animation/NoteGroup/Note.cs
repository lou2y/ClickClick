using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite appleSprite;
    [SerializeField] private Sprite blueberrySprite;

    private bool isApple;
    public void SetSprite(bool isApple)
    {
        this.isApple = isApple;
        spriteRenderer.sprite = isApple ? appleSprite : blueberrySprite;
    }

    public void DeleteNote()
    {
        Gamemanager.Instance.CalculateScore(isApple);

        Destroy();
    }
    public void Destroy()
    {
        GameObject.Destroy(gameObject);
    }
}