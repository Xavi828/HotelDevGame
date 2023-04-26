using UnityEngine;

public class ObjectData : MonoBehaviour
{
    public string objectName;
    public Sprite objectImage;
    public Vector2 dimensions;
    public bool isSolid;
    public ObjectType objectType;
    public Color objectColor;
    public float objectPrice;

    public enum ObjectType
    {
        Wall,
        Floor,
        Furniture,
        Toilet,
        Staff
    }
}
