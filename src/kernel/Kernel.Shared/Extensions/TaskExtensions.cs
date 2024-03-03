namespace Kernel.Shared.Extensions;

public static class TaskExtensions
{
    /// <summary>
    /// Use function after task completion
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    /// <param name="processingTask"></param>
    /// <param name="actionAfterTask"></param>
    /// <returns></returns>
    public static async Task<TOutput> ThenAsync<TInput, TOutput>(
        this Task<TInput> processingTask, Func<TInput, TOutput> actionAfterTask)
    {
        var taskProcessingResult = await processingTask.ConfigureAwait(false);
        var actionAfterTaskResult = actionAfterTask(taskProcessingResult);

        return actionAfterTaskResult;
    }

    /// <summary>
    /// Use action after task completion asynchroniously
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    /// <param name="processingTask"></param>
    /// <param name="actionAfterTask"></param>
    /// <returns></returns>
    public static async Task<TOutput> ThenAsync<TInput, TOutput>(
        this Task<TInput> processingTask, Func<TInput, Task<TOutput>> actionAfterTask)
    {
        var taskProcessingResult = await processingTask.ConfigureAwait(false);
        var actionAfterTaskResult = await actionAfterTask(taskProcessingResult);

        return actionAfterTaskResult;
    }

    /// <summary>
    /// Use action after task completion asynchroniously
    /// </summary>
    /// <typeparam name="TOutput"></typeparam>
    /// <param name="processingTask"></param>
    /// <param name="actionAfterTask"></param>
    /// <returns></returns>
    public static async Task<TOutput> ThenAsync<TOutput>(
        this Task processingTask, Func<Task<TOutput>> actionAfterTask)
    {
        await processingTask.ConfigureAwait(false);

        var actionAfterTaskResult = await actionAfterTask();

        return actionAfterTaskResult;
    }

    /// <summary>
    /// Handle error in task async
    /// </summary>
    /// <param name="processingTask"></param>
    /// <param name="catchFunction"></param>
    /// <returns></returns>
    public static async Task CatchAsync(
        this Task processingTask, Func<Exception, Task> catchFunction)
    {
        await processingTask.ContinueWith(async t =>
        {
            if ((t.IsFaulted || t.IsCanceled) && t.Exception is not null)
            {
                await catchFunction(t.Exception);
            }
        });
    }

    /// <summary>
    /// Handle error in task async
    /// </summary>
    /// <param name="processingTask"></param>
    /// <param name="catchFunction"></param>
    /// <returns></returns>
    public static async Task CatchAsync(
        this Task processingTask, Action<Exception> catchError)
    {
        await processingTask.ContinueWith(t =>
        {
            if ((t.IsFaulted || t.IsCanceled) && t.Exception is not null)
            {
                catchError(t.Exception);
            }
        });
    }
}
