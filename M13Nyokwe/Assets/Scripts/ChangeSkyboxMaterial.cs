using UnityEngine;

/// <summary>
/// Iterates over a material list applied to the skybox
/// </summary>
public class ChangeSkyboxMaterial : Iterator<Material>
{
    // This script takes the methods and fields from Iterator class, it uses a list of Materials

    [Tooltip("Apply the first material to the skybox automatically")]
    public bool applyMaterialOnAwake;

    public void Awake()
    {
        if (applyMaterialOnAwake)
        {
            Change(0);
        }
    }


    public override void Change(int i)
    {
        RenderSettings.skybox = list[i];
        index = i;
    }

}
