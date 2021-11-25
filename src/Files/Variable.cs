using System;
using System.Diagnostics;
using System.Globalization;
using Medo.Configuration;

namespace Labeleer;

[DebuggerDisplay("{Name,nq}: {Value,nq}")]
public sealed record Variable {

    public Variable(string name, string value, bool autoIncrement) {
        Name = name;
        Value = value;
        AutoIncrement = autoIncrement;
    }

    public string Name { get; init; }
    public string Value { get; set; }
    public bool AutoIncrement { get; init; }

    public void IncrementIfNeeded() {
        if (AutoIncrement) {
            var len = Value.Trim().Length;  // remember old length
            if (len == 0) { len = 1; }

            if (long.TryParse(Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result)) {
                result += 1;
                Value = result.ToString(new string('0', len));
            }
        }
    }

    #region Static

    internal static Variable FromIniSection(IniFile ini, string section) {
        var sectionParts = section.Split(':', 2, StringSplitOptions.None);
        var name = ini.Read(section, "Name", sectionParts.Length == 2 ? sectionParts[1] : section);
        var value = ini.Read(section, "Value", "");
        var autoIncrement = ini.Read(section, "AutoIncrement", false);
        return new Variable(name, value, autoIncrement);
    }

    #endregion Static

}
