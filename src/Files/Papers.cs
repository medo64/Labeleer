using System.Collections.Generic;

namespace Labeleer;

public static class Papers {

    private static List<Paper>? CachedPapers;

    private static IReadOnlyList<Paper> GetPapers() {
        if (CachedPapers == null) {
            var papers = new List<Paper>();
            var ini = new Medo.Configuration.IniFile("Templates.ini");
            foreach (var section in ini.GetSections()) {
                if (section.Length > 0) {
                    var paper = Paper.FromIniSection(ini, section);
                    papers.Add(paper);
                }
            }
            CachedPapers = papers;
        }
        return CachedPapers.AsReadOnly();
    }

    public static IEnumerable<Paper> GetAll() {
        foreach (var paper in GetPapers()) {
            yield return paper;
        }
    }

}
