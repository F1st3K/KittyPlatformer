using KittyPlatformer.Base;

namespace KittyPlatformer.Objects
{
    public class Finish : StateVariableEntity
    {
        private protected override void OnActivate()
        {
            Navigation.Instance.Finish();
            DeActivate();
        }
    }
}