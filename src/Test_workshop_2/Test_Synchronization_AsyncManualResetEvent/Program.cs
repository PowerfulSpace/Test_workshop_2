public class AsyncManualResetEvent
{
    private TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

    public Task WaitAsync() => tcs.Task;

    public void Set() => tcs.TrySetResult(true);

    public void Reset()
    {
        if (tcs.Task.IsCompleted)
        {
            tcs = new TaskCompletionSource<bool>();
        }
    }
}
