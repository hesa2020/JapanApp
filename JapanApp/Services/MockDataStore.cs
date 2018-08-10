using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JapanApp
{
    public class MockDataStore
    {
        List<Item> items;
        List<Item> HiraganaCourses;

        public MockDataStore()
        {
            items = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description.", State = "Not yet learned.", StateColor = Color.FromHex("#D53F3E"), ImgBackColor = Color.FromHex("#0594d6") },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description.", State = "Locked", StateColor = Color.FromHex("#AAA"), ImgBackColor = Color.FromHex("#CCC") },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description.", State = "Locked", StateColor = Color.FromHex("#AAA"), ImgBackColor = Color.FromHex("#CCC") },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description.", State = "Locked", StateColor = Color.FromHex("#AAA"), ImgBackColor = Color.FromHex("#CCC") },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description.", State = "Locked", StateColor = Color.FromHex("#AAA"), ImgBackColor = Color.FromHex("#CCC") },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description.", State = "Locked", StateColor = Color.FromHex("#AAA"), ImgBackColor = Color.FromHex("#CCC") },
            };
            RefreshHiraganaList();
        }

        public void RefreshHiraganaList()
        {
            //Hiragana Courses
            LearningProgression hiraganaCourse1 = Settings.GetHiraganaProgression("Hiragana_Course_1");
            LearningProgression hiraganaCourse2 = Settings.GetHiraganaProgression("Hiragana_Course_2");
            ExamProgression hiraganaExam1 = Settings.GetHiraganaExamProgression("Hiragana_Exam_1");
            LearningProgression hiraganaCourse3 = Settings.GetHiraganaProgression("Hiragana_Course_3");
            LearningProgression hiraganaCourse4 = Settings.GetHiraganaProgression("Hiragana_Course_4");
            ExamProgression hiraganaExam2 = Settings.GetHiraganaExamProgression("Hiragana_Exam_2");
            LearningProgression hiraganaCourse5 = Settings.GetHiraganaProgression("Hiragana_Course_5");
            LearningProgression hiraganaCourse6 = Settings.GetHiraganaProgression("Hiragana_Course_6");
            LearningProgression hiraganaCourse7 = Settings.GetHiraganaProgression("Hiragana_Course_7");
            ExamProgression hiraganaExam3 = Settings.GetHiraganaExamProgression("Hiragana_Exam_3");
            LearningProgression hiraganaCourse8 = Settings.GetHiraganaProgression("Hiragana_Course_8");
            LearningProgression hiraganaCourse9 = Settings.GetHiraganaProgression("Hiragana_Course_9");
            ExamProgression hiraganaExam4 = Settings.GetHiraganaExamProgression("Hiragana_Exam_4");
            LearningProgression hiraganaCourse10 = Settings.GetHiraganaProgression("Hiragana_Course_10");
            LearningProgression hiraganaCourse11 = Settings.GetHiraganaProgression("Hiragana_Course_11");
            LearningProgression hiraganaCourse12 = Settings.GetHiraganaProgression("Hiragana_Course_12");
            LearningProgression hiraganaCourse13 = Settings.GetHiraganaProgression("Hiragana_Course_13");
            LearningProgression hiraganaCourse14 = Settings.GetHiraganaProgression("Hiragana_Course_14");
            ExamProgression hiraganaExam5 = Settings.GetHiraganaExamProgression("Hiragana_Exam_5");
            //HiraganaCourses.Clear();
            HiraganaCourses = new List<Item>
            {
                new Item { Id = "Hiragana_Theory_1", Text = "Theory", Description="Overview of the Hiragana", Icon = "説", State = "", StateColor = Color.FromHex("#0594d6"), ImgBackColor = Color.FromHex("#0594d6")},
                new Item { Id = "Hiragana_Course_1", Text = "Vowels 1", Description="あ, い, う, え, お", Icon = "え", State = Settings.ProgressionToState(hiraganaCourse1), StateColor = Settings.ProgressionToColor(hiraganaCourse1), ImgBackColor = Color.FromHex(hiraganaCourse1 == LearningProgression.Locked ? "#2f2f2f" : "#0594d6") },
                new Item { Id = "Hiragana_Course_2", Text = "Vowels 2", Description="か, き, く, け, こ", Icon = "き", State = Settings.ProgressionToState(hiraganaCourse2), StateColor = Settings.ProgressionToColor(hiraganaCourse2), ImgBackColor = Color.FromHex(hiraganaCourse2 == LearningProgression.Locked ? "#2f2f2f" : "#0594d6") },
                new Item { Id = "Hiragana_Exam_1", Text = "Exam 1", Description="This is your first review exam.", Icon="葉", State = Settings.ProgressionExamToState(hiraganaExam1), StateColor = Settings.ProgressionExamToColor(hiraganaExam1), ImgBackColor = Color.FromHex(hiraganaExam1 == ExamProgression.Locked ? "#2f2f2f" : "#0594d6") },
                new Item { Id = "Hiragana_Course_3", Text = "Vowels 3", Description="さ, し, す, せ, そ", Icon = "そ", State = Settings.ProgressionToState(hiraganaCourse3), StateColor = Settings.ProgressionToColor(hiraganaCourse3), ImgBackColor = Color.FromHex(hiraganaCourse3 == LearningProgression.Locked ? "#2f2f2f" : "#0594d6") },
                new Item { Id = "Hiragana_Course_4", Text = "Vowels 4", Description="た, ち, つ, て, と", Icon = "ち", State = Settings.ProgressionToState(hiraganaCourse4), StateColor = Settings.ProgressionToColor(hiraganaCourse4), ImgBackColor = Color.FromHex(hiraganaCourse4 == LearningProgression.Locked ? "#2f2f2f" : "#0594d6") },
                new Item { Id = "Hiragana_Exam_2", Text = "Exam 2", Description="This is your second review exam.", Icon="葉", State = Settings.ProgressionExamToState(hiraganaExam2), StateColor = Settings.ProgressionExamToColor(hiraganaExam2), ImgBackColor = Color.FromHex(hiraganaExam2 == ExamProgression.Locked ? "#2f2f2f" : "#0594d6") },
                new Item { Id = "Hiragana_Course_5", Text = "Vowels 5", Description="な, に, ぬ, ね, の", Icon = "ぬ", State = Settings.ProgressionToState(hiraganaCourse5), StateColor = Settings.ProgressionToColor(hiraganaCourse5), ImgBackColor = Color.FromHex(hiraganaCourse5 == LearningProgression.Locked ? "#2f2f2f" : "#0594d6") },
                new Item { Id = "Hiragana_Course_6", Text = "Vowels 6", Description="は, ひ, ふ, へ, ほ", Icon = "ほ", State = Settings.ProgressionToState(hiraganaCourse6), StateColor = Settings.ProgressionToColor(hiraganaCourse6), ImgBackColor = Color.FromHex(hiraganaCourse6 == LearningProgression.Locked ? "#2f2f2f" : "#0594d6") },
                new Item { Id = "Hiragana_Course_7", Text = "Vowels 7", Description="ま, み, む, め, も", Icon = "み", State = Settings.ProgressionToState(hiraganaCourse7), StateColor = Settings.ProgressionToColor(hiraganaCourse7), ImgBackColor = Color.FromHex(hiraganaCourse7 == LearningProgression.Locked ? "#2f2f2f" : "#0594d6") },
                new Item { Id = "Hiragana_Exam_3", Text = "Exam 3", Description="This is your third review exam.", Icon="葉", State = Settings.ProgressionExamToState(hiraganaExam3), StateColor = Settings.ProgressionExamToColor(hiraganaExam3), ImgBackColor = Color.FromHex(hiraganaExam3 == ExamProgression.Locked ? "#2f2f2f" : "#0594d6") },
                new Item { Id = "Hiragana_Course_8", Text = "Vowels 8", Description="ら, り, る, れ, ろ", Icon = "よ", State = Settings.ProgressionToState(hiraganaCourse8), StateColor = Settings.ProgressionToColor(hiraganaCourse8), ImgBackColor = Color.FromHex(hiraganaCourse8 == LearningProgression.Locked ? "#2f2f2f" : "#0594d6") },
                new Item { Id = "Hiragana_Course_9", Text = "Vowels 9", Description="や, ゆ, よ, わ, を, ん", Icon = "れ", State = Settings.ProgressionToState(hiraganaCourse9), StateColor = Settings.ProgressionToColor(hiraganaCourse9), ImgBackColor = Color.FromHex(hiraganaCourse9 == LearningProgression.Locked ? "#2f2f2f" : "#0594d6") },
                new Item { Id = "Hiragana_Exam_4", Text = "Exam 4", Description="This is your fourth review exam.", Icon="葉", State = Settings.ProgressionExamToState(hiraganaExam4), StateColor = Settings.ProgressionExamToColor(hiraganaExam4), ImgBackColor = Color.FromHex(hiraganaExam4 == ExamProgression.Locked ? "#2f2f2f" : "#0594d6") },
                new Item { Id = "Hiragana_Course_10", Text = "Dakuten 1", Description="が, ぎ, ぐ, げ, ご", Icon = "ご", State = Settings.ProgressionToState(hiraganaCourse10), StateColor = Settings.ProgressionToColor(hiraganaCourse10), ImgBackColor = Color.FromHex(hiraganaCourse10 == LearningProgression.Locked ? "#2f2f2f" : "#0594d6") },
                new Item { Id = "Hiragana_Course_11", Text = "Dakuten 2", Description="ざ, じ, ず, ぜ, ぞ", Icon = "ぜ", State = Settings.ProgressionToState(hiraganaCourse11), StateColor = Settings.ProgressionToColor(hiraganaCourse11), ImgBackColor = Color.FromHex(hiraganaCourse11 == LearningProgression.Locked ? "#2f2f2f" : "#0594d6") },
                new Item { Id = "Hiragana_Course_12", Text = "Dakuten 3", Description="だ, ぢ, づ, で, ど", Icon = "だ", State = Settings.ProgressionToState(hiraganaCourse12), StateColor = Settings.ProgressionToColor(hiraganaCourse12), ImgBackColor = Color.FromHex(hiraganaCourse12 == LearningProgression.Locked ? "#2f2f2f" : "#0594d6") },
                new Item { Id = "Hiragana_Course_13", Text = "Dakuten 4", Description="ば, び, ぶ, べ, ぼ", Icon = "ぶ", State = Settings.ProgressionToState(hiraganaCourse13), StateColor = Settings.ProgressionToColor(hiraganaCourse13), ImgBackColor = Color.FromHex(hiraganaCourse13 == LearningProgression.Locked ? "#2f2f2f" : "#0594d6") },
                new Item { Id = "Hiragana_Course_14", Text = "Handakuten", Description="ぱ, ぴ, ぷ, ぺ, ぽ", Icon = "ぽ", State = Settings.ProgressionToState(hiraganaCourse14), StateColor = Settings.ProgressionToColor(hiraganaCourse14), ImgBackColor = Color.FromHex(hiraganaCourse14 == LearningProgression.Locked ? "#2f2f2f" : "#0594d6") },
                new Item { Id = "Hiragana_Exam_5", Text = "Exam 5", Description="This is your final review exam.", Icon="葉", State = Settings.ProgressionExamToState(hiraganaExam5), StateColor = Settings.ProgressionExamToColor(hiraganaExam5), ImgBackColor = Color.FromHex(hiraganaExam5 == ExamProgression.Locked ? "#2f2f2f" : "#0594d6") },
            };
        }

        //Hiragana
        public async Task<bool> AddHiraganaCourseAsync(Item item)
        {
            HiraganaCourses.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateHiraganaCourseAsync(Item item)
        {
            var _item = HiraganaCourses.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            HiraganaCourses.Remove(_item);
            HiraganaCourses.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteHiraganaCourseAsync(string id)
        {
            var _item = HiraganaCourses.Where((Item arg) => arg.Id == id).FirstOrDefault();
            HiraganaCourses.Remove(_item);
            return await Task.FromResult(true);
        }

        public async Task<Item> GetHiraganaCourseAsync(string id)
        {
            return await Task.FromResult(HiraganaCourses.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetHiraganaCoursesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(HiraganaCourses);
        }

        //

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
