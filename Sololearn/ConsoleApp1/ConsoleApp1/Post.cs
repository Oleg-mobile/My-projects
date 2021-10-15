using System;

namespace ConsoleApp1
{
    internal class Post
    {
        private string text;

        public Post()
        {
            Console.WriteLine("New post");
        }

        public void ShowPost()
        {
            Console.WriteLine(text);
        }

        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
            }
        }

    }
}