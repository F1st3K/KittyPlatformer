using UnityEngine;

public sealed class Finish : ActionEntity
{
    [SerializeField] private Navigation navigation;
    [SerializeField] private Canvas finishMenu;
    
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Hero hero) &&
            hero.action)
        {
            Activate();
            DeActivate();
            hero.action = false;
        }
        
    }

    private protected override void Action()
    {
        navigation.Pause();
        finishMenu.enabled = true;
    }
}