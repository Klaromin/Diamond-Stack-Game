using UnityEngine;

namespace StackGame.Data
{
    [CreateAssetMenu(menuName = "Collectables/Gem", fileName = "New Gem Data")]
    public class GemData : ScriptableObject
    {
        public string GemName;
        public GemType GemType;
        public int GemInintialPrice;
        public Sprite GemIcon;
        public MeshFilter GemModel;
        public Material GemMaterial;
    }
}
