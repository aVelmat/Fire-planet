using UnityEngine;

/// <summary>
/// Class is responsible for additional rendering of units in game
/// </summary>
public class UnitObject : MonoBehaviour
{
    [SerializeField]
    private Renderer bodyRenderer;

    public void SetMaterial(Material material)
    {
        bodyRenderer.material = material;
    }
}
