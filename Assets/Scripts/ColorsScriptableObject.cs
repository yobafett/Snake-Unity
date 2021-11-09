using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ColorsScriptableObject", order = 1)]
public class ColorsScriptableObject : ScriptableObject
{
    [SerializeField] private Color[] colors;

    public Color GetColorById(int id)
    {
        if (id < colors.Length && id >= 0) return colors[id];
        else return colors[0];
    }

    public int GetRandomColorId(int previousColorId)
    {
        var newId = Random.Range(0, colors.Length);
        while (newId == previousColorId)
        {
            newId = Random.Range(0, colors.Length);
        }

        return newId;
    }
}