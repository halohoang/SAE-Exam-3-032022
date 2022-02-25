using UnityEngine;

/// <summary>
/// Grid Element
/// <para> represents Elements in the ElementGrid
/// <para> Holds the elementType (int) and the Unity visualization (the associated GameObject).
/// </summary>
public class Element
{
    /// <summary>
    /// The type of the Element as integer ID [0..n].
    /// </summary>
    public int ElementType;
    /// <summary>
    /// The Unity visualization of the Element in the ElementGrid (the associated GameObject wich represents the Element in the scene).
    /// </summary>
    public GameObject Visuals;

    /// <summary>
    /// Initializes a new instance of the <see cref="Element"/> class.
    /// </summary>
    /// <param name="visuals">The Unity visualization of the Element in the ElementGrid (the associated GameObject wich represents the Element in the scene).</param>
    /// <param name="elementType">The type of the Element [0..n].</param>
    public Element(GameObject visuals, int elementType)
    {
        this.ElementType = elementType;
        this.Visuals = visuals;
    }

    /// <summary>
    /// Updates the position of the elements visualization.
    /// </summary>
    /// <param name="position">Position (position in WorldSpace).</param>
    public void UpdateElement(Vector3 worldSpacePosition)
    {
        if (Visuals != null)
        {
            Visuals.transform.position = worldSpacePosition;
        }
        else
        {
            Debug.LogError("Element::UpdateElement -> visuals is null!");
        }
    }

    /// <summary>
    /// Destroys the element. Removes the Elements represantation from the Unity scene.
    /// </summary>
    public void DestroyElement()
    {
        if (Visuals != null)
        {
            GameObject.Destroy(Visuals);
        }
    }
}
