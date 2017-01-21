public class Buff
{
    protected float _Modifier;
    public float Modifier
    {
        get
        {
            return _Modifier;
        }
    }

    public Buff(float modifier)
    {
        _Modifier = modifier;
    }

    public void SetModifier(float modifier)
    {
        _Modifier = modifier;
    }

    public virtual float Modify(float value)
    {
        return value * _Modifier;
    }
}
