public abstract class Pedal
{
    public struct PedalState
    {
        public bool IsPressed;
        public float PushValue;
    }

    public PedalState State = new PedalState();

    float deactivatingThreshold = 0.1f;

    public Pedal()
    {

    }

    public void Push(float threshold)
    {
        if(threshold <= deactivatingThreshold)
        {
            Release();
            return;
        }

        State.PushValue = threshold;
        State.IsPressed = true;
    }

    public void Release()
    {
        State.PushValue = 0;
        State.IsPressed = false;
    }
}