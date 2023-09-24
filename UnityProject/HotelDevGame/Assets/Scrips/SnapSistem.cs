using UnityEngine;

public class SnapSistem : MonoBehaviour
{
    public Grid objectsGrid;

    void Update()
    {
        Vector3Int cp = objectsGrid.LocalToCell(transform.localPosition);
        transform.localPosition = objectsGrid.GetCellCenterLocal(cp);
    }
}
