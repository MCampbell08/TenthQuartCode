﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkArchitect
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MainController mainController = new MainController();

            mainController.ReadFile();

        }
    }
}
