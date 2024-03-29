﻿namespace DevSec.Client.Core.Entities;

public sealed class DeviceIconColor
{
    private DeviceIconColor() { }

    private DeviceIconColor(byte red, byte green, byte blue, float opacity)
    {
        if (opacity < 0 || opacity > 1)
        {
            throw new ArgumentException(
                $"{nameof(opacity)} must be greater than or equal to 0 and less than or equal to 1");
        }

        Red = red;
        Blue = blue;
        Green = green;
        Opacity = opacity;
    }

    /// <summary>
    /// Красный оттенок
    /// </summary>
    public byte Red { get; private set; }

    /// <summary>
    /// Зелёный оттенок
    /// </summary>
    public byte Green { get; private set; }

    /// <summary>
    /// Голубой оттенок
    /// </summary>
    public byte Blue { get; private set; }

    /// <summary>
    /// Прозрачность
    /// </summary>
    public float Opacity { get; private set; }

    /// <summary>
    /// Создать экземпляр класса <see cref="DeviceIconColor"/> с прозрачным цветом
    /// </summary>
    /// <returns></returns>
    public static DeviceIconColor Transparent() => new DeviceIconColor(0, 0, 0, 0);
}