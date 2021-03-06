﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_sharp_lesson_one
{/// <summary>
///  Савенко Вадим -  добавил свой объект в виде прямоугольника
///  сделал 2 и 4 
/// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
     
            Game g1;
            try
            {
                g1 = new Game(1200,900);
            }
            catch(ArgumentOutOfRangeException er)
            {
                MessageBox.Show(er.Message);
            }
            finally
            {
                g1 = new Game(750, 600);
            }

            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);

        }
    }
}
