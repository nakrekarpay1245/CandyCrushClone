using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]
    private int entityType = 0;

    public void ChangeColor()
    {
        Color startColor = GetComponent<SpriteRenderer>().color;
        startColor = new Color(startColor.r, startColor.g, startColor.b, 0.25f);
        GetComponent<SpriteRenderer>().color = startColor;
    }

    public int GetEntityType()
    {
        return entityType;
    }
}
