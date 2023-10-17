using Microsoft.VisualBasic;
using System.Data;
using System.Globalization;

namespace ConsoleApp1
{
    class NotesList
    {
        private Dictionary<DateTime, List<Note>> DateList;
        private int currentNoteIndex;
        private DateTime currentDate;
        public NotesList()
        {
            DateList = new Dictionary<DateTime, List<Note>>();
            currentDate = DateTime.Today;
        }
        public void NoteDate(Note note, DateTime date)
        {
            if (DateList.ContainsKey(date))
            {
                DateList[date].Add(note);
            }
            else
            {
                List<Note> notes = new() {note};
                DateList.Add(date, notes);
            }
        }
        public void CreateNote()
        {
            Console.Clear();
            Console.WriteLine("Создание новой заметки");
            Console.Write("Название: ");
            string title = Console.ReadLine();
            Console.Write("Описание: ");
            string content = Console.ReadLine();
            Console.Write("Дата выполнения (в формате ДД.ММ.ГГ): ");
            bool datatest = false;
            DateTime duedate_date = default;
            while (datatest == false)
            {
                string duedate = Console.ReadLine();
                try
                {
                    duedate_date = DateTime.ParseExact(duedate, "dd.MM.yy", CultureInfo.InvariantCulture);
                    datatest = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введена некорректная дата");
                    Console.Write("Дата выполнения (в формате ДД.ММ.ГГ): ");
                }
            }
            Note newNote = new Note { Title = title, Content = content, Date = currentDate, DueDate = duedate_date };
            NoteDate(newNote, currentDate);
            Console.WriteLine("Новая заметка добавлена.");
            do
            {
                ConsoleKeyInfo keyexit = Console.ReadKey(true);
                if (keyexit.Key == ConsoleKey.Escape)
                {
                    break;
                }
            } while (true);
        }
        public void SwitchDate(bool move)
        {
            if (move)
            {
                currentDate = currentDate.AddDays(1);
            }
            else
            {
                currentDate = currentDate.AddDays(-1);
            }
            currentNoteIndex = 0;
        }
        public void Particulars()
        {
            Console.Clear();
            if (DateList.ContainsKey(currentDate))
            {
                Note currentNote = DateList[currentDate][currentNoteIndex];
                Console.WriteLine($"Заметка: {currentNote.Title}");
                Console.WriteLine($"Описание: {currentNote.Content}");
                Console.WriteLine($"Крайняя дата выполнения: {currentNote.DueDate:dd.MM.yy}");
            }
            else
            {
                return;
            }
            do
            {
                ConsoleKeyInfo keyexit = Console.ReadKey(true);
                if (keyexit.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }while (true);
        }
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine($"Дела на {currentDate.Date:dd.MM.yy}");
        }
        public void Arrows()
        {
            if (DateList.ContainsKey(currentDate))
            {
                List<Note> notes = DateList[currentDate];

                for (int i = 0; i < notes.Count; i++)
                {
                    string notetitle = notes[i].Title;
                    if (i == currentNoteIndex)
                    {
                        Console.WriteLine($"->{notetitle}");
                    }
                    else
                    {
                        Console.WriteLine($"  {notetitle}");
                    }
                }
            }
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (DateList.ContainsKey(currentDate))
                    {
                        currentNoteIndex--;
                        if (currentNoteIndex < 0)
                        {
                            currentNoteIndex = DateList[currentDate].Count - 1;
                        }
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (DateList.ContainsKey(currentDate))
                    {
                        currentNoteIndex++;
                        if (currentNoteIndex >= DateList[currentDate].Count)
                        {
                            currentNoteIndex = 0;
                        }
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    SwitchDate(false);
                    break;
                case ConsoleKey.RightArrow:
                    SwitchDate(true);
                    break;
                case ConsoleKey.Enter:
                    Particulars();
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                case ConsoleKey.N:
                    CreateNote();
                    break;
            }
        }
    }
    class Program
    {
        static void Main()
        {
            NotesList DayList = new();
            Note note1 = new() {Title = "Магазин", Content = "Список продуктов : молоко , хлеб , курица", Date = new DateTime(2023, 10, 16),DueDate = new DateTime(2023, 10, 18) };
            Note note2 = new() {Title = "Полить цветы", Content = "Соблюдать правильный метод полива для каждого растения", Date = new DateTime(2023, 10, 17) ,DueDate = new DateTime(2023, 10, 20) };
            Note note3 = new() {Title = "Сделать уборку", Content = "Сделать влажную уюорку всех помещений", Date = new DateTime(2023, 10, 18) ,DueDate = new DateTime(2023, 10, 19) };
            Note note4 = new() {Title = "Написать практическую", Content = "Важно , внести финальные правки", Date = new DateTime(2023, 10, 20) ,DueDate = new DateTime(2023, 10, 21) };
            Note note5 = new() {Title = "Приготовить еду на неделю", Content = "Расписать рацион и внести в бюджет расходы на продукты", Date = new DateTime(2023, 10, 19) ,DueDate = new DateTime(2023, 10, 20) };
            DayList.NoteDate(note1, note1.Date);
            DayList.NoteDate(note2, note2.Date);
            DayList.NoteDate(note3, note3.Date);
            DayList.NoteDate(note4, note4.Date);
            DayList.NoteDate(note5, note5.Date);
            while (true)
            {
                DayList.Menu();
                DayList.Arrows();
            }
        }
    }
}