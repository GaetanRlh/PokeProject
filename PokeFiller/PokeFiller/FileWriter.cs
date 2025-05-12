using PokeFiller.API;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeFiller
{
    public class FileWriter
    {
        public static async void Writer()
        {
            string filePath = "output.txt";
            int max = 151;
            Data data = new Data();
            string line;

            for (int i = 1; i <= max; i++)
            {
                data = await APIProcessor.Load(i);
                line = @$"
                CALL ajouter_pokemon(
                {data.Id}, 
                '{data.Cries.Latest}', 
                '{data.Sprites.Front_default}', 
                '{data.Name}');
                ";

                using (StreamWriter writer = new StreamWriter(filePath, append: true))
                {
                    writer.WriteLine(line);
                    writer.WriteLine();
                }

                Thread.Sleep(100);
            }
        }
    }
}
