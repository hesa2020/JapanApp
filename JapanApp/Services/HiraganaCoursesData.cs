using System.Collections.Generic;
namespace JapanApp.Services
{
    public class HiraganaCourseDataItem
    {
        public string JapanCharacter { get; set; }
        public string EnglishCharacter { get; set; }
        public string SoundName { get; set; }
        public bool Learned { get; set; }
        public bool MustReview { get; set; }

        public HiraganaCourseDataItem(string japanCharacter, string englishCharacter, string soundName, bool learned, bool mustReview)
        {
            JapanCharacter = japanCharacter;
            EnglishCharacter = englishCharacter;
            SoundName = soundName;
            Learned = learned;
            MustReview = mustReview;
        }
    }

    public class HiraganaCourseData
    {
        public string Next { get; set; }
        public List<HiraganaCourseDataItem> Items { get; set; }

        public HiraganaCourseData(string next, List<HiraganaCourseDataItem> items)
        {
            Next = next;
            Items = items;
        }
    }

    public static class HiraganaCoursesData
    {
        public static Dictionary<string, HiraganaCourseData> Courses = new Dictionary<string, HiraganaCourseData>()
        {
            {
                "Hiragana_Course_1",
                new HiraganaCourseData("", 
                    new List<HiraganaCourseDataItem>
                    {
                        new HiraganaCourseDataItem("あ", "a", "a.mp3", false, false),
                        new HiraganaCourseDataItem("い", "i", "i.mp3", false, false),
                        new HiraganaCourseDataItem("う", "u", "u.mp3", false, false),
                        new HiraganaCourseDataItem("え", "e", "e.mp3", false, false),
                        new HiraganaCourseDataItem("お", "o", "o.mp3", false, false)
                    }
                )
            },
            {
                "Hiragana_Course_2",
                new HiraganaCourseData("Hiragana_Exam_1", 
                    new List<HiraganaCourseDataItem>
                    {
                        new HiraganaCourseDataItem("か", "ka", "ka.mp3", false, false),
                        new HiraganaCourseDataItem("き", "ki", "ki.mp3", false, false),
                        new HiraganaCourseDataItem("く", "ku", "ku.mp3", false, false),
                        new HiraganaCourseDataItem("け", "ke", "ke.mp3", false, false),
                        new HiraganaCourseDataItem("こ", "ko", "ko.mp3", false, false)
                    }
                )
            },
            {
                "Hiragana_Course_3",
                new HiraganaCourseData("Hiragana_Course_4",
                    new List<HiraganaCourseDataItem>
                    {
                        new HiraganaCourseDataItem("さ", "sa", "sa.mp3", false, false),
                        new HiraganaCourseDataItem("し", "shi", "shi.mp3", false, false),
                        new HiraganaCourseDataItem("す", "su", "su.mp3", false, false),
                        new HiraganaCourseDataItem("せ", "se", "se.mp3", false, false),
                        new HiraganaCourseDataItem("そ", "so", "so.mp3", false, false)
                    }
                )
            },
            {
                "Hiragana_Course_4",
                new HiraganaCourseData("Hiragana_Exam_2",
                    new List<HiraganaCourseDataItem>
                    {
                        new HiraganaCourseDataItem("た", "ta", "ta.mp3", false, false),
                        new HiraganaCourseDataItem("ち", "chi", "chi.mp3", false, false),
                        new HiraganaCourseDataItem("つ", "tsu", "tsu.mp3", false, false),
                        new HiraganaCourseDataItem("て", "te", "te.mp3", false, false),
                        new HiraganaCourseDataItem("と", "to", "to.mp3", false, false)
                    }
                )
            },
            {
                "Hiragana_Course_5",
                new HiraganaCourseData("Hiragana_Course_6",
                    new List<HiraganaCourseDataItem>//な, に, ぬ, ね, の
                    {
                        new HiraganaCourseDataItem("な", "na", "na.mp3", false, false),
                        new HiraganaCourseDataItem("に", "ni", "ni.mp3", false, false),
                        new HiraganaCourseDataItem("ぬ", "nu", "nu.mp3", false, false),
                        new HiraganaCourseDataItem("ね", "ne", "ne.mp3", false, false),
                        new HiraganaCourseDataItem("の", "no", "no.mp3", false, false)
                    }
                )
            },
            {
                "Hiragana_Course_6",
                new HiraganaCourseData("Hiragana_Course_7",
                    new List<HiraganaCourseDataItem>//は, ひ, ふ, へ, ほ
                    {
                        new HiraganaCourseDataItem("は", "ha", "ha.mp3", false, false),
                        new HiraganaCourseDataItem("ひ", "hi", "hi.mp3", false, false),
                        new HiraganaCourseDataItem("ふ", "fu", "fu.mp3", false, false),
                        new HiraganaCourseDataItem("へ", "he", "he.mp3", false, false),
                        new HiraganaCourseDataItem("ほ", "ho", "ho.mp3", false, false)
                    }
                )
            },
            {
                "Hiragana_Course_7",
                new HiraganaCourseData("Hiragana_Exam_3",
                    new List<HiraganaCourseDataItem>//ま, み, む, め, も
                    {
                        new HiraganaCourseDataItem("ま", "ma", "ma.mp3", false, false),
                        new HiraganaCourseDataItem("み", "mi", "mi.mp3", false, false),
                        new HiraganaCourseDataItem("む", "mu", "mu.mp3", false, false),
                        new HiraganaCourseDataItem("め", "me", "me.mp3", false, false),
                        new HiraganaCourseDataItem("も", "mo", "mo.mp3", false, false)
                    }
                )
            },
            {
                "Hiragana_Course_8",
                new HiraganaCourseData("Hiragana_Course_9",
                    new List<HiraganaCourseDataItem>//ら, り, る, れ, ろ
                    {
                        new HiraganaCourseDataItem("ま", "ra", "ra.mp3", false, false),
                        new HiraganaCourseDataItem("り", "ri", "ri.mp3", false, false),
                        new HiraganaCourseDataItem("る", "ru", "ru.mp3", false, false),
                        new HiraganaCourseDataItem("れ", "re", "re.mp3", false, false),
                        new HiraganaCourseDataItem("ろ", "ro", "ro.mp3", false, false)
                    }
                )
            },
            {
                "Hiragana_Course_9",
                new HiraganaCourseData("Hiragana_Exam_4",
                    new List<HiraganaCourseDataItem>//や, ゆ, よ, わ, を, ん
                    {
                        new HiraganaCourseDataItem("や", "ya", "ya.mp3", false, false),
                        new HiraganaCourseDataItem("ゆ", "yu", "yu.mp3", false, false),
                        new HiraganaCourseDataItem("よ", "yo", "yo.mp3", false, false),
                        new HiraganaCourseDataItem("わ", "wa", "wa.mp3", false, false),
                        new HiraganaCourseDataItem("を", "wo", "wo.mp3", false, false),
                        new HiraganaCourseDataItem("ん", "n", "n.mp3", false, false)
                    }
                )
            },
            {
                "Hiragana_Course_10",
                new HiraganaCourseData("Hiragana_Course_11",
                    new List<HiraganaCourseDataItem>//が, ぎ, ぐ, げ, ご
                    {
                        new HiraganaCourseDataItem("が", "ga", "ga.mp3", false, false),
                        new HiraganaCourseDataItem("ぎ", "gi", "gi.mp3", false, false),
                        new HiraganaCourseDataItem("ぐ", "gu", "gu.mp3", false, false),
                        new HiraganaCourseDataItem("げ", "ge", "ge.mp3", false, false),
                        new HiraganaCourseDataItem("ご", "go", "go.mp3", false, false)
                    }
                )
            },
            {
                "Hiragana_Course_11",
                new HiraganaCourseData("Hiragana_Course_12",
                    new List<HiraganaCourseDataItem>//ざ, じ, ず, ぜ, ぞ
                    {
                        new HiraganaCourseDataItem("ざ", "za", "za.mp3", false, false),
                        new HiraganaCourseDataItem("じ", "ji", "ji.mp3", false, false),
                        new HiraganaCourseDataItem("ず", "zu", "zu.mp3", false, false),
                        new HiraganaCourseDataItem("ぜ", "ze", "ze.mp3", false, false),
                        new HiraganaCourseDataItem("ぞ", "zo", "zo.mp3", false, false)
                    }
                )
            },
            {
                "Hiragana_Course_12",
                new HiraganaCourseData("Hiragana_Course_13",
                    new List<HiraganaCourseDataItem>//だ, ぢ, づ, で, ど
                    {
                        new HiraganaCourseDataItem("だ", "da", "da.mp3", false, false),
                        new HiraganaCourseDataItem("ぢ", "ji", "ji.mp3", false, false),
                        new HiraganaCourseDataItem("づ", "zu", "zu.mp3", false, false),
                        new HiraganaCourseDataItem("で", "de", "de.mp3", false, false),
                        new HiraganaCourseDataItem("ど", "do", "do.mp3", false, false)
                    }
                )
            },
            {
                "Hiragana_Course_13",
                new HiraganaCourseData("Hiragana_Course_14",
                    new List<HiraganaCourseDataItem>//ば, び, ぶ, べ, ぼ
                    {
                        new HiraganaCourseDataItem("ば", "ba", "ba.mp3", false, false),
                        new HiraganaCourseDataItem("び", "bi", "bi.mp3", false, false),
                        new HiraganaCourseDataItem("ぶ", "bu", "bu.mp3", false, false),
                        new HiraganaCourseDataItem("べ", "be", "be.mp3", false, false),
                        new HiraganaCourseDataItem("ぼ", "bo", "bo.mp3", false, false)
                    }
                )
            },
            {
                "Hiragana_Course_14",
                new HiraganaCourseData("Hiragana_Exam_5",
                    new List<HiraganaCourseDataItem>//ぱ, ぴ, ぷ, ぺ, ぽ
                    {
                        new HiraganaCourseDataItem("ぱ", "pa", "pa.mp3", false, false),
                        new HiraganaCourseDataItem("ぴ", "pi", "pi.mp3", false, false),
                        new HiraganaCourseDataItem("ぷ", "pu", "pu.mp3", false, false),
                        new HiraganaCourseDataItem("ぺ", "pe", "pe.mp3", false, false),
                        new HiraganaCourseDataItem("ぽ", "po", "po.mp3", false, false)
                    }
                )
            }
        };
    }
}
