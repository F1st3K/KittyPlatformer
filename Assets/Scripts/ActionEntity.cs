public abstract class ActionEntity : IInteractional
{
    protected ActionEntity()
    {
        IsActivate = false;
    }

    public bool IsActivate { get; private set; }
    
    public void Activate()
    {
        IsActivate = true;
        Action();
    }

    public void DeActivate()
    {
        IsActivate = false;
    }

    private protected virtual void Action()
    {
        
    }
}