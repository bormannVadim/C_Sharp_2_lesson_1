using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace C_sharp_lesson_one
{
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        public Game()
        {

        }

        public Game(int _windth, int _height)
        {
            if (_windth > 1000 )
                throw new ArgumentOutOfRangeException("Width", "More than 1000.");
            else if(_height>1000)
                throw new ArgumentOutOfRangeException("Height", "More than 1000");
            else
            {
                Width = _windth;
                Height = _height;
            }
        }

        public static void Init(Form form)
        {
            Graphics g;
             _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            form.Width = Width;
            form.Height = Height;
            Load();
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;

        }

        public static BaseObject[] _objs;

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Load()
        {
            // загружаем базовые объекты
            _objs = new BaseObject[20];
           // половина объектов это круги, половина - звёды
            // загружаем звёзды
            for (int i = 0; i < _objs.Length/2; i++)
                _objs[i] = new Star(new Point(600, i * 30), new Point(-i, 0), new Size(10, 10));

            // My object
            for (int i = _objs.Length / 2; i < _objs.Length; i++)
                _objs[i] = new MyObject(new Point(600, i * 30), new Point(-i, +i), new Size(10, 10));
        }


        public static void Draw()
        {
            // Проверяем вывод графики
            Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }

    }

}
