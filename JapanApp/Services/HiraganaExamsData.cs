using System;
using System.Collections.Generic;

namespace JapanApp
{
    public enum HiraganaExamType
    {
        SoundToCharacter,
        CharacterToSound,
        JapanToEnglish,
        EnglishToJapan
    }

    public class HiraganaExamsDataItem
    {
        public string JapanCharacter { get; set; }
        public string EnglishCharacter { get; set; }
        public string SoundName { get; set; }
        public HiraganaExamType Type { get; set; }

        public HiraganaExamsDataItem(string japanCharacter, string englishCharacter, string soundName)
        {
            JapanCharacter = japanCharacter;
            EnglishCharacter = englishCharacter;
            SoundName = soundName;
        }

        public HiraganaExamsDataItem(HiraganaExamsDataItem item)
        {
            JapanCharacter = item.JapanCharacter;
            EnglishCharacter = item.EnglishCharacter;
            SoundName = item.SoundName;
        }
    }

    public class HiraganaExamData
    {
        public string Next { get; set; }
        public List<string> PreviousExams { get; set; }
        public List<HiraganaExamsDataItem> Items { get; set; }

        public HiraganaExamData(string next, List<string> previousExams, List<HiraganaExamsDataItem> items)
        {
            Next = next;
            PreviousExams = previousExams;
            Items = items;
        }
    }

    public static class HiraganaExamsData
    {
        public static Dictionary<string, HiraganaExamData> Exams = new Dictionary<string, HiraganaExamData>()
        {
            {
                "Hiragana_Exam_1",
                new HiraganaExamData("Hiragana_Course_3",
                    new List<string>
                    {
                    },
                    new List<HiraganaExamsDataItem>
                    {
                        new HiraganaExamsDataItem("あ", "a", "a.mp3"),
                        new HiraganaExamsDataItem("い", "i", "i.mp3"),
                        new HiraganaExamsDataItem("う", "u", "u.mp3"),
                        new HiraganaExamsDataItem("え", "e", "e.mp3"),
                        new HiraganaExamsDataItem("お", "o", "o.mp3"),
                        new HiraganaExamsDataItem("か", "ka", "ka.mp3"),
                        new HiraganaExamsDataItem("き", "ki", "ki.mp3"),
                        new HiraganaExamsDataItem("く", "ku", "ku.mp3"),
                        new HiraganaExamsDataItem("け", "ke", "ke.mp3"),
                        new HiraganaExamsDataItem("こ", "ko", "ko.mp3")
                    }
                )
            },
            {
                "Hiragana_Exam_2",
                new HiraganaExamData("Hiragana_Course_5",
                    new List<string>
                    {
                        "Hiragana_Exam_1"
                    },
                    new List<HiraganaExamsDataItem>
                    {
                        new HiraganaExamsDataItem("あ", "a", "a.mp3"),
                        new HiraganaExamsDataItem("い", "i", "i.mp3"),
                        new HiraganaExamsDataItem("う", "u", "u.mp3"),
                        new HiraganaExamsDataItem("え", "e", "e.mp3"),
                        new HiraganaExamsDataItem("お", "o", "o.mp3"),
                        new HiraganaExamsDataItem("か", "ka", "ka.mp3"),
                        new HiraganaExamsDataItem("き", "ki", "ki.mp3"),
                        new HiraganaExamsDataItem("く", "ku", "ku.mp3"),
                        new HiraganaExamsDataItem("け", "ke", "ke.mp3"),
                        new HiraganaExamsDataItem("こ", "ko", "ko.mp3"),
                        new HiraganaExamsDataItem("さ", "sa", "sa.mp3"),
                        new HiraganaExamsDataItem("し", "shi", "shi.mp3"),
                        new HiraganaExamsDataItem("す", "su", "su.mp3"),
                        new HiraganaExamsDataItem("せ", "se", "se.mp3"),
                        new HiraganaExamsDataItem("そ", "so", "so.mp3"),
                        new HiraganaExamsDataItem("た", "ta", "ta.mp3"),
                        new HiraganaExamsDataItem("ち", "chi", "chi.mp3"),
                        new HiraganaExamsDataItem("つ", "tsu", "tsu.mp3"),
                        new HiraganaExamsDataItem("て", "te", "te.mp3"),
                        new HiraganaExamsDataItem("と", "to", "to.mp3")
                    }
                )
            },
            {
                "Hiragana_Exam_3",
                new HiraganaExamData("Hiragana_Course_8",
                    new List<string>
                    {
                        "Hiragana_Exam_2"
                    },
                    new List<HiraganaExamsDataItem>
                    {
                        new HiraganaExamsDataItem("あ", "a", "a.mp3"),
                        new HiraganaExamsDataItem("い", "i", "i.mp3"),
                        new HiraganaExamsDataItem("う", "u", "u.mp3"),
                        new HiraganaExamsDataItem("え", "e", "e.mp3"),
                        new HiraganaExamsDataItem("お", "o", "o.mp3"),
                        new HiraganaExamsDataItem("か", "ka", "ka.mp3"),
                        new HiraganaExamsDataItem("き", "ki", "ki.mp3"),
                        new HiraganaExamsDataItem("く", "ku", "ku.mp3"),
                        new HiraganaExamsDataItem("け", "ke", "ke.mp3"),
                        new HiraganaExamsDataItem("こ", "ko", "ko.mp3"),
                        new HiraganaExamsDataItem("さ", "sa", "sa.mp3"),
                        new HiraganaExamsDataItem("し", "shi", "shi.mp3"),
                        new HiraganaExamsDataItem("す", "su", "su.mp3"),
                        new HiraganaExamsDataItem("せ", "se", "se.mp3"),
                        new HiraganaExamsDataItem("そ", "so", "so.mp3"),
                        new HiraganaExamsDataItem("た", "ta", "ta.mp3"),
                        new HiraganaExamsDataItem("ち", "chi", "chi.mp3"),
                        new HiraganaExamsDataItem("つ", "tsu", "tsu.mp3"),
                        new HiraganaExamsDataItem("て", "te", "te.mp3"),
                        new HiraganaExamsDataItem("と", "to", "to.mp3"),
                        new HiraganaExamsDataItem("な", "na", "na.mp3"),
                        new HiraganaExamsDataItem("に", "ni", "ni.mp3"),
                        new HiraganaExamsDataItem("ぬ", "nu", "nu.mp3"),
                        new HiraganaExamsDataItem("ね", "ne", "ne.mp3"),
                        new HiraganaExamsDataItem("の", "no", "no.mp3"),
                        new HiraganaExamsDataItem("は", "ha", "ha.mp3"),
                        new HiraganaExamsDataItem("ひ", "hi", "hi.mp3"),
                        new HiraganaExamsDataItem("ふ", "fu", "fu.mp3"),
                        new HiraganaExamsDataItem("へ", "he", "he.mp3"),
                        new HiraganaExamsDataItem("ほ", "ho", "ho.mp3"),
                        new HiraganaExamsDataItem("ま", "ma", "ma.mp3"),
                        new HiraganaExamsDataItem("み", "mi", "mi.mp3"),
                        new HiraganaExamsDataItem("む", "mu", "mu.mp3"),
                        new HiraganaExamsDataItem("め", "me", "me.mp3"),
                        new HiraganaExamsDataItem("も", "mo", "mo.mp3")
                    }
                )
            },
            {
                "Hiragana_Exam_4",
                new HiraganaExamData("Hiragana_Course_10",
                    new List<string>
                    {
                        "Hiragana_Exam_3"
                    },
                    new List<HiraganaExamsDataItem>
                    {
                        new HiraganaExamsDataItem("あ", "a", "a.mp3"),
                        new HiraganaExamsDataItem("い", "i", "i.mp3"),
                        new HiraganaExamsDataItem("う", "u", "u.mp3"),
                        new HiraganaExamsDataItem("え", "e", "e.mp3"),
                        new HiraganaExamsDataItem("お", "o", "o.mp3"),
                        new HiraganaExamsDataItem("か", "ka", "ka.mp3"),
                        new HiraganaExamsDataItem("き", "ki", "ki.mp3"),
                        new HiraganaExamsDataItem("く", "ku", "ku.mp3"),
                        new HiraganaExamsDataItem("け", "ke", "ke.mp3"),
                        new HiraganaExamsDataItem("こ", "ko", "ko.mp3"),
                        new HiraganaExamsDataItem("さ", "sa", "sa.mp3"),
                        new HiraganaExamsDataItem("し", "shi", "shi.mp3"),
                        new HiraganaExamsDataItem("す", "su", "su.mp3"),
                        new HiraganaExamsDataItem("せ", "se", "se.mp3"),
                        new HiraganaExamsDataItem("そ", "so", "so.mp3"),
                        new HiraganaExamsDataItem("た", "ta", "ta.mp3"),
                        new HiraganaExamsDataItem("ち", "chi", "chi.mp3"),
                        new HiraganaExamsDataItem("つ", "tsu", "tsu.mp3"),
                        new HiraganaExamsDataItem("て", "te", "te.mp3"),
                        new HiraganaExamsDataItem("と", "to", "to.mp3"),
                        new HiraganaExamsDataItem("な", "na", "na.mp3"),
                        new HiraganaExamsDataItem("に", "ni", "ni.mp3"),
                        new HiraganaExamsDataItem("ぬ", "nu", "nu.mp3"),
                        new HiraganaExamsDataItem("ね", "ne", "ne.mp3"),
                        new HiraganaExamsDataItem("の", "no", "no.mp3"),
                        new HiraganaExamsDataItem("は", "ha", "ha.mp3"),
                        new HiraganaExamsDataItem("ひ", "hi", "hi.mp3"),
                        new HiraganaExamsDataItem("ふ", "fu", "fu.mp3"),
                        new HiraganaExamsDataItem("へ", "he", "he.mp3"),
                        new HiraganaExamsDataItem("ほ", "ho", "ho.mp3"),
                        new HiraganaExamsDataItem("ま", "ma", "ma.mp3"),
                        new HiraganaExamsDataItem("み", "mi", "mi.mp3"),
                        new HiraganaExamsDataItem("む", "mu", "mu.mp3"),
                        new HiraganaExamsDataItem("め", "me", "me.mp3"),
                        new HiraganaExamsDataItem("も", "mo", "mo.mp3"),
                        new HiraganaExamsDataItem("ま", "ra", "ra.mp3"),
                        new HiraganaExamsDataItem("り", "ri", "ri.mp3"),
                        new HiraganaExamsDataItem("る", "ru", "ru.mp3"),
                        new HiraganaExamsDataItem("れ", "re", "re.mp3"),
                        new HiraganaExamsDataItem("ろ", "ro", "ro.mp3"),
                        new HiraganaExamsDataItem("や", "ya", "ya.mp3"),
                        new HiraganaExamsDataItem("ゆ", "yu", "yu.mp3"),
                        new HiraganaExamsDataItem("よ", "yo", "yo.mp3"),
                        new HiraganaExamsDataItem("わ", "wa", "wa.mp3"),
                        new HiraganaExamsDataItem("を", "wo", "wo.mp3"),
                        new HiraganaExamsDataItem("ん", "n", "n.mp3")
                    }
                )
            },
            {
                "Hiragana_Exam_5",
                new HiraganaExamData("",
                    new List<string>
                    {
                        "Hiragana_Exam_4"
                    },
                    new List<HiraganaExamsDataItem>
                    {
                        new HiraganaExamsDataItem("あ", "a", "a.mp3"),
                        new HiraganaExamsDataItem("い", "i", "i.mp3"),
                        new HiraganaExamsDataItem("う", "u", "u.mp3"),
                        new HiraganaExamsDataItem("え", "e", "e.mp3"),
                        new HiraganaExamsDataItem("お", "o", "o.mp3"),
                        new HiraganaExamsDataItem("か", "ka", "ka.mp3"),
                        new HiraganaExamsDataItem("き", "ki", "ki.mp3"),
                        new HiraganaExamsDataItem("く", "ku", "ku.mp3"),
                        new HiraganaExamsDataItem("け", "ke", "ke.mp3"),
                        new HiraganaExamsDataItem("こ", "ko", "ko.mp3"),
                        new HiraganaExamsDataItem("さ", "sa", "sa.mp3"),
                        new HiraganaExamsDataItem("し", "shi", "shi.mp3"),
                        new HiraganaExamsDataItem("す", "su", "su.mp3"),
                        new HiraganaExamsDataItem("せ", "se", "se.mp3"),
                        new HiraganaExamsDataItem("そ", "so", "so.mp3"),
                        new HiraganaExamsDataItem("た", "ta", "ta.mp3"),
                        new HiraganaExamsDataItem("ち", "chi", "chi.mp3"),
                        new HiraganaExamsDataItem("つ", "tsu", "tsu.mp3"),
                        new HiraganaExamsDataItem("て", "te", "te.mp3"),
                        new HiraganaExamsDataItem("と", "to", "to.mp3"),
                        new HiraganaExamsDataItem("な", "na", "na.mp3"),
                        new HiraganaExamsDataItem("に", "ni", "ni.mp3"),
                        new HiraganaExamsDataItem("ぬ", "nu", "nu.mp3"),
                        new HiraganaExamsDataItem("ね", "ne", "ne.mp3"),
                        new HiraganaExamsDataItem("の", "no", "no.mp3"),
                        new HiraganaExamsDataItem("は", "ha", "ha.mp3"),
                        new HiraganaExamsDataItem("ひ", "hi", "hi.mp3"),
                        new HiraganaExamsDataItem("ふ", "fu", "fu.mp3"),
                        new HiraganaExamsDataItem("へ", "he", "he.mp3"),
                        new HiraganaExamsDataItem("ほ", "ho", "ho.mp3"),
                        new HiraganaExamsDataItem("ま", "ma", "ma.mp3"),
                        new HiraganaExamsDataItem("み", "mi", "mi.mp3"),
                        new HiraganaExamsDataItem("む", "mu", "mu.mp3"),
                        new HiraganaExamsDataItem("め", "me", "me.mp3"),
                        new HiraganaExamsDataItem("も", "mo", "mo.mp3"),
                        new HiraganaExamsDataItem("ま", "ra", "ra.mp3"),
                        new HiraganaExamsDataItem("り", "ri", "ri.mp3"),
                        new HiraganaExamsDataItem("る", "ru", "ru.mp3"),
                        new HiraganaExamsDataItem("れ", "re", "re.mp3"),
                        new HiraganaExamsDataItem("ろ", "ro", "ro.mp3"),
                        new HiraganaExamsDataItem("や", "ya", "ya.mp3"),
                        new HiraganaExamsDataItem("ゆ", "yu", "yu.mp3"),
                        new HiraganaExamsDataItem("よ", "yo", "yo.mp3"),
                        new HiraganaExamsDataItem("わ", "wa", "wa.mp3"),
                        new HiraganaExamsDataItem("を", "wo", "wo.mp3"),
                        new HiraganaExamsDataItem("ん", "n", "n.mp3"),
                        new HiraganaExamsDataItem("が", "ga", "ga.mp3"),
                        new HiraganaExamsDataItem("ぎ", "gi", "gi.mp3"),
                        new HiraganaExamsDataItem("ぐ", "gu", "gu.mp3"),
                        new HiraganaExamsDataItem("げ", "ge", "ge.mp3"),
                        new HiraganaExamsDataItem("ご", "go", "go.mp3"),
                        new HiraganaExamsDataItem("ざ", "za", "za.mp3"),
                        new HiraganaExamsDataItem("じ", "ji", "ji.mp3"),
                        new HiraganaExamsDataItem("ず", "zu", "zu.mp3"),
                        new HiraganaExamsDataItem("ぜ", "ze", "ze.mp3"),
                        new HiraganaExamsDataItem("ぞ", "zo", "zo.mp3"),
                        new HiraganaExamsDataItem("だ", "da", "da.mp3"),
                        new HiraganaExamsDataItem("ぢ", "ji", "ji.mp3"),
                        new HiraganaExamsDataItem("づ", "zu", "zu.mp3"),
                        new HiraganaExamsDataItem("で", "de", "de.mp3"),
                        new HiraganaExamsDataItem("ど", "do", "do.mp3"),
                        new HiraganaExamsDataItem("ば", "ba", "ba.mp3"),
                        new HiraganaExamsDataItem("び", "bi", "bi.mp3"),
                        new HiraganaExamsDataItem("ぶ", "bu", "bu.mp3"),
                        new HiraganaExamsDataItem("べ", "be", "be.mp3"),
                        new HiraganaExamsDataItem("ぼ", "bo", "bo.mp3"),
                        new HiraganaExamsDataItem("ぱ", "pa", "pa.mp3"),
                        new HiraganaExamsDataItem("ぴ", "pi", "pi.mp3"),
                        new HiraganaExamsDataItem("ぷ", "pu", "pu.mp3"),
                        new HiraganaExamsDataItem("ぺ", "pe", "pe.mp3"),
                        new HiraganaExamsDataItem("ぽ", "po", "po.mp3")
                    }
                )
            }
        };
    }
}
