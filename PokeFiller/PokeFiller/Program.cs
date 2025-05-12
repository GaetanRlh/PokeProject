using PokeFiller.API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace PokeFiller
{
    public class Program
    {
        public static void Main()
        {
            APIHelper.Initialize();
            FileWriter.Writer();
        }
    }
}