namespace Kernel.Shared.Exceptions;

public sealed class AlertingException : Exception
{
    public AlertingException(
        string message,
        string details,
        AlertingExceptionType alertingExceptionType) : base(message)
    { 
        Details = details;
        Type = alertingExceptionType;
    }

    /// <summary>
    /// Детали ошибки
    /// </summary>
    public string Details { get; }

    /// <summary>
    /// Тип ошибки
    /// </summary>
    public AlertingExceptionType Type { get; }

    /// <summary>
    /// Сгенерировать ошибку, если сущность не найдена
    /// </summary>
    /// <param name="message"></param>
    /// <param name="details"></param>
    /// <returns></returns>
    public static AlertingException NotFound(string message, string details) =>
        new AlertingException(message, details, AlertingExceptionType.NotFound);
    
    /// <summary>
    /// Сгенерировать ошибку, при ошибке пользователя
    /// </summary>
    /// <param name="message"></param>
    /// <param name="details"></param>
    /// <returns></returns>
    public static AlertingException Conflict(string message, string details) =>
        new AlertingException(message, details, AlertingExceptionType.Conflict);

    /// <summary>
    /// Сгенерировать исключение при уже существующей сущности
    /// </summary>
    /// <param name="message"></param>
    /// <param name="details"></param>
    /// <returns></returns>
    public static AlertingException AlreadyExists(string message, string details) =>
        new AlertingException(message, details, AlertingExceptionType.AlreadyExists);
}

public enum AlertingExceptionType
{ 
    AlreadyExists,
    NotFound,
    Conflict,
}
