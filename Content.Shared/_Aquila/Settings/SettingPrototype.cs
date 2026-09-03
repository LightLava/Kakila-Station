using Robust.Shared.Prototypes;

namespace Content.Shared.Aquila.Settings;

[Prototype]
public sealed partial class AQSettingPrototype : IPrototype
{
    [IdDataField]
    public string ID { get; private set; } = string.Empty;

    /// <summary>
    /// Имя сеттинга
    /// </summary>
    [DataField(required: true)]
    public LocId Name = string.Empty;

    /// <summary>
    /// Вес сеттинга. Чем больше тем выше в меню.
    /// </summary>
    [DataField]
    public int Weight { get; private set; }
}

public sealed class SettingUIComparer : IComparer<AQSettingPrototype>
{
    public static readonly SettingUIComparer Instance = new();

    public int Compare(AQSettingPrototype? x, AQSettingPrototype? y)
    {
        if (ReferenceEquals(x, y))
            return 0;

        if (ReferenceEquals(null, y))
            return 1;

        if (ReferenceEquals(null, x))
            return -1;

        var cmp = -x.Weight.CompareTo(y.Weight);
        return cmp != 0 ? cmp : string.Compare(x.ID, y.ID, StringComparison.Ordinal);
    }
}