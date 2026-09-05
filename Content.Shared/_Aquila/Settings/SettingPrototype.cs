// SPDX-License-Identifier: AGPL-3.0-or-later

using Robust.Shared.Prototypes;

namespace Content.Shared.Aquila.Settings;

[Prototype]
public sealed partial class AqSettingPrototype : IPrototype
{
    [IdDataField]
    public string ID { get; private set; } = string.Empty;

    /// <summary>
    /// Имя додепартамента что показывается в эдиторе
    /// </summary>
    [DataField(required: true)]
    public LocId Name = string.Empty;

    /// <summary>
    /// ТЯЖЕСТЬ 
    /// </summary>
    [DataField]
    public int Weight { get; private set; }
}

/// <summary>
/// Sorts <see cref="DepartmentPrototype"/> appropriately for display in the UI,
/// respecting their <see cref="DepartmentPrototype.Weight"/>.
/// </summary>
public sealed class SettingUIComparer : IComparer<AqSettingPrototype>
{
    public static readonly SettingUIComparer Instance = new();

    public int Compare(AqSettingPrototype? x, AqSettingPrototype? y)
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