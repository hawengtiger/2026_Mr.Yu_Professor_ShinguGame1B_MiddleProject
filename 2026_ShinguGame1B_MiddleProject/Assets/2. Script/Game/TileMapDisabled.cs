using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapDisabled : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<TilemapRenderer>().enabled = false;
    }
}
