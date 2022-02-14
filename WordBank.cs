using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hang_Man
{
    class WordBank
    {
        public WordBank()
        {

        }
        public string EasyWords() // "EasyWords()" Function
        {
            string[] words = { "cat", "dog", "ball", "house", "man", "apple", "woman", "world", "hummer", "table",
                "chair", "window", "sea", "glass", "door", "screw", "banana", "kitchen", "cloud", "airplane", "cellphone", "glass",
                "dish", "finger", "juice", "shark", "monitor", "battery", "heart", "ocean", "freak"};
            Random random = new Random();
            return words[random.Next(words.Length)];
        }
        public string HardWords() // "HardWords()" Function
        {
            string[] words = { "processor", "defibrillator", "motorcycle", "keyboard", "magnanimous",
                "furniture", "electricity", "professor", "monocycle", "accoutrements", "circumlocution", "luminescent",
                "perfidiousness", "sesquipedalian", "superabundant", "unencumbered", "unparagoned", "concupiscent", "idiosyncratic"};
            Random random = new Random();
            return words[random.Next(words.Length)];
        }
    }
}
