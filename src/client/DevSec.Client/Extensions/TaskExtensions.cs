namespace DevSec.Client.Extensions;

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
}
