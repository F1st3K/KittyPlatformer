using KittyPlatformer.Base;
using UnityEngine;

namespace KittyPlatformer.Objects
{
    public class Finish : StateVariableEntity
    {
        private protected override void OnActivate()
        {
            Debug.Log("FINISH");
        }
        
        private protected override void OnDeActivate()
        {
            Debug.Log("...Un? unfinished???");
        }
    }
}