using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        GreenGem,
        PurpleGem,
        BlueGem,
        Snowflake,
        Star,
        Banana,
        Medkit
    }

    public ItemType type;
    public int value;

    public int GetValue()
    {
        return value;
    }
}

